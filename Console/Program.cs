using System;
using System.ServiceProcess;

namespace Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var service = new TestSevice())
            {
                ServiceBase.Run(service);
            }
        }
    }
}