
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.Windows;
using System.Windows.Interop;

namespace CustomBA.Models
{
    public class BootstrapperApplicationModel
    {
        private IntPtr hwnd;
        
        public BootstrapperApplicationModel(BootstrapperApplication bootstrapperApplication)
        {
            this.BootstrapperApplication = bootstrapperApplication;
            this.hwnd = IntPtr.Zero;
        }

        public BootstrapperApplication BootstrapperApplication { get; private set; }

        public int FinalResult { get; set; }

        public void SetWindowHandle(Window view)
        {
            this.hwnd = new WindowInteropHelper(view).Handle;
        }

        public void PlanAction(LaunchAction action)
        {
            this.BootstrapperApplication.Engine.Plan(action);
        }

        public void ApplyAction()
        {
            this.BootstrapperApplication.Engine.Apply(this.hwnd);
        }

        public void LogMessage(string message)
        {
            this.BootstrapperApplication.Engine.Log(LogLevel.Standard, message);
        }
    }
}
