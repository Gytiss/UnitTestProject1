using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Config
    {
        public static IEnumerable<String> BrowserToRun()
        {
            String browsers = ConfigurationManager.AppSettings["Browser"];

            yield return browsers;

        }

        public static IEnumerable<String> Environment()
        {
            String versions = ConfigurationManager.AppSettings["Environment"];

            yield return versions;

        }



    }
}
