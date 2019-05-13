namespace MyWindowsService
{
    using System;
    using System.IO;
    using System.ServiceProcess;
    using System.Threading;

    public partial class Service1 : ServiceBase
    {
        private Thread thread;
        private bool threadActive;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.threadActive = true;
            ThreadStart job = new ThreadStart(this.WriteToLog);
            this.thread = new Thread(job);
            this.thread.Start();
        }

        protected override void OnStop()
        {
            this.threadActive = false;
            this.thread.Join();
        }

        protected void WriteToLog()
        {
            while (this.threadActive)
            {
                string appDataDir = Environment.GetFolderPath(
                Environment.SpecialFolder.CommonApplicationData);

                string logDir = Path.Combine(appDataDir,
                   "TestInstallerLogs");

                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                string logFile = Path.Combine(logDir,
                   "serviceLog.txt");

                using (var sw = new StreamWriter(logFile, true))
                {
                    sw.Write("Log entry at {0}{1}",
                       DateTime.Now, Environment.NewLine);
                }

                Thread.Sleep(5000);
            }
        }
    }
}

