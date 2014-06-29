using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace NTH
{
    /// <summary>
    /// Represents a semantic version 2.0.0 as described in <a href="http://semver.org/spec/v2.0.0.html">the SemVer specification</a>.
    /// </summary>
    public class SemanticVersion
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }

        public PreReleaseIdentifierList PreReleaseIdentifier { get; set; }
        public IList<BuildMetadata> BuildMetadata { get; set; }

        public SemanticVersion(int major, int minor, int patch)
            : this(major, minor, patch, null)
        { }
        public SemanticVersion(int major, int minor, int patch, IEnumerable<PreReleaseIdentifier> preRelease)
            : this(major, minor, patch, preRelease, null)
        { }
        public SemanticVersion(int major, int minor, int patch, IEnumerable<PreReleaseIdentifier> preRelease, IList<BuildMetadata> build)
        {
            if (major < 0)
                throw new ArgumentException("major must be greater or equal to zero");
            if (minor < 0)
                throw new ArgumentException("minor must be greater or equal to zero");
            if (patch < 0)
                throw new ArgumentException("patch must be greater or equal to zero");

            Major = major;
            Minor = minor;
            Patch = patch;

            PreReleaseIdentifier = preRelease != null ? new PreReleaseIdentifierList(preRelease) : new PreReleaseIdentifierList();
            BuildMetadata = build ?? new List<BuildMetadata>();
        }

        #region Parsing

        public static SemanticVersion Parse(string versionString)
        {
            if (string.IsNullOrWhiteSpace(versionString))
                throw new ArgumentNullException("versionString is either null, empty or white space.");

            const string end = "$";
            const string optional = "?";
            const string versionCore = @"^((?<major>\d+)\.(?<minor>\d+)\.(?<patch>\d+))";
            const string preRelease = @"(-(?<pre>[a-zA-Z0-9-.]+))" + optional;
            const string buildMetadata = @"(\+(?<build>[a-zA-Z0-9-.]+))" + optional;

            const string semVer = versionCore + preRelease + buildMetadata + end;

            var res = Regex.Match(versionString, semVer);

            int major = int.Parse(res.Groups["major"].Value);
            int minor = int.Parse(res.Groups["minor"].Value);
            int patch = int.Parse(res.Groups["patch"].Value);

            IList<PreReleaseIdentifier> pre = null;
            if (res.Groups["pre"].Value != string.Empty)
            {
                if (!TryParseDotSeparatedPreReleaseIdentifiers(res.Groups["pre"].Value, out pre))
                    throw new FormatException("Invalid pre-release identifier.");
            }

            IList<BuildMetadata> build = null;
            if (res.Groups["build"].Value != string.Empty)
            {
                if (!TryParseDotSeparatedBuildMetadata(res.Groups["build"].Value, out build))
                    throw new FormatException("Invalid build metadata identifier.");
            }
            return new SemanticVersion(major, minor, patch, pre, build);
        }

        /// <remarks>
        /// &lt;dot-separated build identifiers&lt; ::= &lt;build identifier&lt; | &lt;build identifier&lt; "." &lt;dot-separated build identifiers&lt;
        /// </remarks>
        private static bool TryParseDotSeparatedBuildMetadata(string identifiers, out IList<BuildMetadata> result)
        {
            result = null;
            if (string.IsNullOrEmpty(identifiers))
                return false;

            var ids = identifiers.Split(new[] { '.' }, StringSplitOptions.None);

            var list = new List<BuildMetadata>();

            for (int i = 0; i < ids.Length; ++i)
            {
                BuildMetadata currentMetadata;
                if (!TryParseBuildMetadata(ids[i], out currentMetadata))
                    return false;
                Debug.Assert(currentMetadata != null);
                list.Add(currentMetadata);
            }
            result = list;
            return list.Count > 0 && list.Count == ids.Length;
        }

        private static bool TryParseBuildMetadata(string metadata, out BuildMetadata result)
        {
            result = null;
            if (string.IsNullOrEmpty(metadata))
                return false;
            string res;
            if (!TryParseAlphaNumericIdentifier(metadata, out res)) // check if it's alphanumeric (leading zeroes allowed?)
                return false;
            result = new BuildMetadata(res);
            return true;
        }

        /// <remarks>
        /// &lt;dot-separated pre-release identifiers&lt; ::= &lt;pre-release identifier&lt; | &lt;pre-release identifier&lt; "." &lt;dot-separated pre-release identifiers&lt;
        /// </remarks>
        private static bool TryParseDotSeparatedPreReleaseIdentifiers(string identifiers, out IList<PreReleaseIdentifier> result)
        {
            result = null;
            if (string.IsNullOrEmpty(identifiers))
                return false;


            var ids = identifiers.Split(new[] { '.' }, StringSplitOptions.None);

            var list = new List<PreReleaseIdentifier>();

            for (int i = 0; i < ids.Length; ++i)
            {
                PreReleaseIdentifier currentIdentifier;
                if (!TryParsePreReleaseIdentifier(ids[i], out currentIdentifier))
                    return false;
                Debug.Assert(currentIdentifier != null);
                list.Add(currentIdentifier);
            }
            result = list;
            return list.Count > 0 && list.Count == ids.Length;
        }

        /// <remarks>
        /// &lt;pre-release identifier&lt; ::= &lt;alphanumeric identifier&lt;| &lt;numeric identifier&lt;
        /// </remarks>
        private static bool TryParsePreReleaseIdentifier(string identifier, out PreReleaseIdentifier result)
        {
            result = null;
            if (identifier.Contains("."))
                return false;

            string res;
            if (!TryParseNumericIdentifier(identifier, out res)) // check if it's a number withour leading zeroes
                if (!TryParseAlphaNumericIdentifier(identifier, out res)) // check if it's alphanumeric (leading zeroes allowed?)
                    return false;

            if (string.IsNullOrWhiteSpace(res))
                return false;

            result = new PreReleaseIdentifier(res);
            return true;
        }


        /// <remarks>
        /// &lt;build identifier&lt; ::= &lt;alphanumeric identifier&lt; | &lt;digits&lt;
        /// </remarks>
        private static bool TryParseNumericIdentifier(string identifier, out string result)
        {
            if (identifier.Length == 0)
            {
                result = null;
                return false;
            }
            if (identifier.Length == 1 && identifier[0] == '0')
            {
                result = "0";
                return true;
            }

            for (int i = 0; i < identifier.Length; ++i) // check if every char is a digit
            {
                var c = identifier[i];
                if (!('0' <= c && c <= '9'))
                {
                    result = null;
                    return false;
                }
            }
            if (identifier[0] == '0') // if there is a leading zero... it's invalid
            {
                result = null;
                return false;
            }
            result = identifier;
            return true;
        }

        /// <remarks>
        /// &lt;alphanumeric identifier&lt; ::= &lt;non-digit&lt; | &lt;non-digit&lt; &lt;identifier characters&lt; | &lt;identifier characters&lt; &lt;non-digit&lt; | &lt;identifier characters&lt; &lt;non-digit&lt; &lt;identifier characters&lt;
        /// </remarks>
        private static bool TryParseAlphaNumericIdentifier(string identifier, out string result)
        {
            for (int i = 0; i < identifier.Length; ++i)
            {
                var c = identifier[i];
                if (
                    !('0' <= c && c <= '9')
                    && !('A' <= c && c <= 'Z')
                    && !('a' <= c && c <= 'z')
                    && c != '-'
                    )
                {
                    result = null;
                    return false;
                }
            }
            result = identifier;
            return true;
        }

        #endregion
        #region operators

        #region >

        public static bool operator >(SemanticVersion a, SemanticVersion b)
        {
            if (a.Major > b.Major)
                return true;
            if (a.Major != b.Major) // major of b is greater than b
                return false;
            // if getting here, majors are the same

            if (a.Minor > b.Minor)
                return true;
            if (a.Minor != b.Minor) // minor of b is greater than b
                return false;
            // if getting here, minors are the same

            if (a.Patch > b.Patch)
                return true;
            if (a.Patch != b.Patch)
                return false;
            // if getting here, Patch are the same

            // they seem to be equal, if there are no further identifiers
            if (a.PreReleaseIdentifier.Count == 0 && b.PreReleaseIdentifier.Count == 0)
                return false;

            // it's up to the pre-release identifier
            return a.PreReleaseIdentifier > b.PreReleaseIdentifier;
        }

        #endregion
        #region <

        public static bool operator <(SemanticVersion a, SemanticVersion b)
        {
            if (a.Major < b.Major)
                return true;
            if (a.Major != b.Major) // major of b is less than a
                return false;
            // if getting here, majors are the same

            if (a.Minor < b.Minor)
                return true;
            if (a.Minor != b.Minor) // minor of b is less than a
                return false;
            // if getting here, minors are the same

            if (a.Patch < b.Patch)
                return true;
            if (a.Patch != b.Patch) // patch of b is less than a
                return false;
            // if getting here, Patch are the same

            // they seem to be equal, if there are no further identifiers
            if (a.PreReleaseIdentifier.Count == 0 && b.PreReleaseIdentifier.Count == 0)
                return false;

            // it's up to the pre-release identifier
            return a.PreReleaseIdentifier < b.PreReleaseIdentifier;
        }

        #endregion
        #region ==

        public static bool operator ==(SemanticVersion a, SemanticVersion b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;

            return a.Major == b.Major
                    && a.Minor == b.Minor
                    && a.Patch == b.Patch
                    && a.PreReleaseIdentifier == b.PreReleaseIdentifier
                    && a.BuildMetadata == b.BuildMetadata; // TODO: May ignore build metadata on equality comparison?
        }

        public static bool operator !=(SemanticVersion a, SemanticVersion b)
        {
            return !(a == b);
        }

        #endregion
        #region equals

        public override bool Equals(object obj)
        {
            var p = obj as SemanticVersion;
            if (p == null)
                return false;
            return p.Major == Major
                   && p.Minor == Minor
                   && p.Patch == Patch
                   && p.PreReleaseIdentifier == PreReleaseIdentifier
                   && p.BuildMetadata == BuildMetadata;
        }

        public bool Equals(SemanticVersion obj)
        {
            if (obj == null)
                return false;
            return obj.Major == Major
                   && obj.Minor == Minor
                   && obj.Patch == Patch
                   && obj.PreReleaseIdentifier == PreReleaseIdentifier
                   && obj.BuildMetadata == BuildMetadata; // TODO: May ignore build metadata on equality comparison?
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(); // No immutable fields available, so just call the base?
        }

        #endregion

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Major).Append('.').Append(Minor).Append('.').Append(Patch);

            if (PreReleaseIdentifier != null && PreReleaseIdentifier.Count > 0)
                sb.Append('-').Append(PreReleaseIdentifier);

            if (BuildMetadata != null && BuildMetadata.Count > 0)
            {
                sb.Append('+');
                sb.Append(string.Join(".", BuildMetadata));
            }
            return sb.ToString();
        }
    }
}
