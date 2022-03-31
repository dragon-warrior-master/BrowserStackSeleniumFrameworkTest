using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [SetUpFixture]
    public static class OneTimeFixture
    {

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            //Kill any existing chromedrivers and chrome windows
            KillProcesses();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {

        }

        private static void KillProcesses()
        {
            Kill(ProcessName.Chromedriver);

        }

        public static void Kill(ProcessName processName)
        {
            string process;
            switch (processName)
            {
                case ProcessName.Chromedriver:
                    process = "chromedriver";
                    break;

                default:
                    process = "chromedriver";
                    break;
            }

            Process[] proc = Process.GetProcessesByName(process);
            foreach (var item in proc)
            {
                try
                {
                    item.Kill();
                }
                catch (Exception)
                {

                }
            }


        }
        public enum ProcessName
        {
            Chromedriver
        }
    }
}
