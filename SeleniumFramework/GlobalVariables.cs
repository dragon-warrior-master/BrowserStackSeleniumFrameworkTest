using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public class GlobalVariables
    {
        public const string BrowserName = "CHROME";
        public const string URL = "https://www.flipkart.com";

        public static class TimeOut
        {
            public const int Twenty = 20;
        }
        public enum Browser
        {
            CHROME,
            EDGE,
            FIREFOX
        }
    }
}
