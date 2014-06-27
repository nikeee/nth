using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<string> PrereleaseIdentifier { get; set; }
        public IList<string> BuildMetadata { get; set; }

        public SemanticVersion(int major, int minor, int patch)
            : this(major, minor, patch, null, null)
        { }
        public SemanticVersion(int major, int minor, int patch, IList<string> preRelease, IList<string> build)
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

            PrereleaseIdentifier = preRelease;
            BuildMetadata = build;
        }

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

            IList<string> pre;
            if (!TryParseIdentifier(res.Groups["pre"].Value, out pre))
                throw new FormatException("Invalid pre-release identifier.");

            IList<string> build;
            if (!TryParseIdentifier(res.Groups["build"].Value, out build))
                throw new FormatException("Invalid build metadata identifier.");

            return new SemanticVersion(major, minor, patch, pre, build);
        }

        private static bool TryParseIdentifier(string identifier, out IList<string> result)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                result = null;
                return true;
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Major).Append('.').Append(Minor).Append('.').Append(Patch);

            if (PrereleaseIdentifier != null && PrereleaseIdentifier.Count > 0)
            {
                sb.Append('-');
                sb.Append(string.Join(".", PrereleaseIdentifier));
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
