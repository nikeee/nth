using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NTH.Tests
{
    class Resources
    {
        public static byte[] GetResource(string fileName)
        {
            var man = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            string sResourceName = man.Single(x => x.EndsWith(fileName, StringComparison.InvariantCultureIgnoreCase));

            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(sResourceName))
            using (var ms = new MemoryStream((int)s.Length))
            {
                s.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
