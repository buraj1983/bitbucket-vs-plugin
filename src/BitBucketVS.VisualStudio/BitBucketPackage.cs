using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using BitBucketVS.Common.Settings;
using BitBucketVS.VisualStudio.Commands;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace BitBucketVS.VisualStudio
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(Guids.BitBucketPackageString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
        Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class BitBucketPackage : AsyncPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken,
            IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);
            
            await JoinableTaskFactory.RunAsync(VsTaskRunContext.UIThreadNormalPriority,
                async () =>
                {
                    await InitializeMenusAsync(cancellationToken);
                });
        }

        private async Task InitializeMenusAsync(CancellationToken cancellationToken)
        {
            var componentModel = (IComponentModel) await GetServiceAsync(typeof(SComponentModel));

            var vsCommands = componentModel.DefaultExportProvider.GetExportedValues<IVsCommand>();


            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            var commandServive = (IMenuCommandService) await GetServiceAsync(typeof(IMenuCommandService));

            foreach (var vsCommand in vsCommands.OfType<MenuCommand>()) commandServive?.AddCommand(vsCommand);
        }
    }
}