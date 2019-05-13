
using CustomBA.Models;
using CustomBA.ViewModels;
using CustomBA.Views;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.Windows.Threading;

namespace CustomBA
{
    public class CustomBootstrapperApplication : BootstrapperApplication
    {
        public static Dispatcher Dispatcher;
        
        protected override void Run()
        {
            Dispatcher = Dispatcher.CurrentDispatcher;

            var model = new BootstrapperApplicationModel(this);
            var viewModel = new InstallViewModel(model);
            var view = new InstallView(viewModel);

            model.SetWindowHandle(view);

            this.Engine.Detect();

            view.Show();

            Dispatcher.Run();

            this.Engine.Quit(model.FinalResult); // TODO: Use other exit codes
        }
    }
}
