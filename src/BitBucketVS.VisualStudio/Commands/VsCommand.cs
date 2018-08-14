using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;

namespace BitBucketVS.VisualStudio.Commands
{
    public abstract class VsCommand : OleMenuCommand, IVsCommand
    {
        protected VsCommand(Guid menuGroup, int commandId)
            : base((EventHandler) delegate { }, (EventHandler) delegate { }, new CommandID(menuGroup, commandId))
        {
        }

        protected abstract void OnExecute(OleMenuCmdEventArgs args);

        private static void ExecuteCommand(object sender, EventArgs args)
        {
            var command = sender as VsCommand;
            command?.OnExecute(args as OleMenuCmdEventArgs);
        }
    }
}