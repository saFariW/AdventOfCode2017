using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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

        public static List<int> GetDay05Input()
        {
            return ConfigurationManager.AppSettings["inputDay05"]
                .Split(Environment.NewLine)
                .Select(y => Convert.ToInt32(y))
                .ToList(); ;
        }
    }
}
