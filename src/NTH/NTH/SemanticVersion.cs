using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

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

        public IList<PreReleaseIdentifier> PreReleaseIdentifier { get; set; }
        public IList<BuildMetadata> BuildMetadata { get; set; }

        public SemanticVersion(int major, int minor, int patch)
            : this(major, minor, patch, null, null)
        { }
        public SemanticVersion(int major, int minor, int patch, IList<PreReleaseIdentifier> preRelease, IList<BuildMetadata> build)
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

            PreReleaseIdentifier = preRelease;
            BuildMetadata = build;
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
            return list.Count > 0 && list.Count == ids.Length;
        }

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

            // it's up to the pre-release identifier

            throw new NotImplementedException();
            //return a.PreReleaseIdentifier > b.PreReleaseIdentifier;
        }

        #endregion
        #region <

        public static bool operator <(SemanticVersion a, SemanticVersion b)
        {
            throw new NotImplementedException();
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
                    && a.PreReleaseIdentifier == b.PreReleaseIdentifier;
        }

        public static bool operator !=(SemanticVersion a, SemanticVersion b)
        {
            return !(a == b);
        }

        #endregion

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Major).Append('.').Append(Minor).Append('.').Append(Patch);

            if (PreReleaseIdentifier != null && PreReleaseIdentifier.Count > 0)
            {
                sb.Append('-');
                sb.Append(string.Join(".", PreReleaseIdentifier));
            }
            if (BuildMetadata != null && BuildMetadata.Count > 0)
            {
                sb.Append('+');
                sb.Append(string.Join(".", BuildMetadata));
            }
            return sb.ToString();
        }
    }
}
