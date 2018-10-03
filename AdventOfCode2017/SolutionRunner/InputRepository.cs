using System;
using System.Configuration;

namespace SolutionRunner
{
    public static class InputRepository
    {
        public static string GetDay01Input()
        {
            return ConfigurationManager.AppSettings["inputDay01"];
        }

        public static string GetDay02Input()
        {
            return ConfigurationManager.AppSettings["inputDay02"];
        }

        public static int GetDay03Input()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings["inputDay03"]);
        }

        public static string GetDay04Input()
        {
            return ConfigurationManager.AppSettings["inputDay04"];
        }
    }
}
