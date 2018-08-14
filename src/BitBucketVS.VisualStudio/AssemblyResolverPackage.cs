using System.Runtime.InteropServices;
using BitBucketVS.Common.Settings;
using Microsoft.VisualStudio.Shell;

namespace BitBucketVS.VisualStudio
{
    [ProvideBindingPath]
    [Guid(Guids.AssemblyResolverPackageString)]
    public class AssemblyResolverPackage : AsyncPackage
    {
    }
}