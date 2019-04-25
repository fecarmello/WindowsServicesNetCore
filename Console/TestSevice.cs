using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Console
{
    internal class TestSevice : ServiceBase
    {
        public TestSevice()
        {
            ServiceName = "TestService";
        }

        protected override void OnStart(string[] args)
        {
            string filename = CheckFileExists();
            File.AppendAllText(filename, $"{DateTime.Now} started.{Environment.NewLine}");

            Run();
        }

        protected override void OnStop()
        {
            string filename = CheckFileExists();
            File.AppendAllText(filename, $"{DateTime.Now} stopped.{Environment.NewLine}");
        }

        private static string CheckFileExists()
        {
            string filename = @"c:\tmp_file\NetCoreService.txt";
            if (!File.Exists(filename))
            {
                File.Create(filename);
            }

            return filename;
        }

        public Task Run()
        {
            return Task.Run(() =>
            {
                while (true)
                {
                    string filename = CheckFileExists();
                    File.AppendAllText(filename, $"{DateTime.Now} active.{Environment.NewLine}");

                    Thread.Sleep(2000);
                }
            });
        }
    }
}