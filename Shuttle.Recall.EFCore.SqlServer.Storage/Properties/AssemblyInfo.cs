using System.Reflection;
using System.Runtime.InteropServices;

#if NETSTANDARD
[assembly: AssemblyTitle(".NET Standard")]
#endif

#if NET6_0_OR_GREATER
[assembly: AssemblyTitle(".NET Unified Platform")]
#endif

[assembly: AssemblyVersion("20.0.0.0")]
[assembly: AssemblyCopyright("Copyright (c) #{Year}#, Eben Roux")]
[assembly: AssemblyProduct("Shuttle.Recall.EFCore.SqlServer.Storage")]
[assembly: AssemblyCompany("Eben Roux")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyInformationalVersion("20.0.0")]
[assembly: ComVisible(false)]