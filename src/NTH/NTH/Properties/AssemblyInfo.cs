using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("NTH")]
[assembly: AssemblyDescription("A library that contains nice-to-have functionality that is missing in the .NET Framework.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("NTH")]
[assembly: AssemblyCopyright("Copyright © Niklas Mollenhauer 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("b9124fce-ec06-4c00-bd70-3c3d3b978698")]

[assembly: AssemblyVersion("1.0.1.0")]
[assembly: AssemblyFileVersion("1.0.1.0")]
[assembly: NeutralResourcesLanguage("en")]

#if DEBUG // currently only test debug builds
[assembly: InternalsVisibleTo("NTH.Tests", AllInternalsVisible = true)]
#endif
