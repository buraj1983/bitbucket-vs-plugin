using BitBucketVS.Common.Settings;
using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Shell;

namespace BitBucketVS.VisualStudio.Commands
{
    /// <summary>
    ///     Opens the login dialog to add a new connection to Team Explorer.
    /// </summary>
    [Export(typeof(IVsCommand))]
    public class AddConnectionCommand : VsCommand
    {
        public AddConnectionCommand()
            : base(Guids.BitbucketCmdSet, PkgCmdID.AddConnection)
        {
        }

        protected override void OnExecute(OleMenuCmdEventArgs args)
        {
            var ss = 3;
        }
    }
}