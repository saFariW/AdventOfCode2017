namespace SolutionRunner
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public static class InputRepository
    {
        public static string GetDay01Input()
        {
            return Properties.Resources.InputDay01;
        }

        public static List<List<int>> GetDay02Input()
        {
            return Properties.Resources.InputDay02
                .Split(Environment.NewLine)
                .Select(x => x.Split('\t')
                .Select(y => Convert.ToInt32(y, CultureInfo.InvariantCulture))
                .ToList())
                .ToList();
        }

        public static int GetDay03Input()
        {
            return Convert.ToInt32(Properties.Resources.InputDay03, CultureInfo.InvariantCulture);
        }

        public static List<List<string>> GetDay04Input()
        {
            return Properties.Resources.InputDay04
                .Split(Environment.NewLine)
                .Select(x => x.Split(' ')
                .ToList())
                .ToList();
        }

        public static List<int> GetDay05Input()
        {
            return Properties.Resources.InputDay05
                .Split(Environment.NewLine)
                .Select(x => Convert.ToInt32(x, CultureInfo.InvariantCulture))
                .ToList();
        }

        public static List<int> GetDay06Input()
        {
            return Properties.Resources.InputDay06
                .Split('\t')
                .Select(x => Convert.ToInt32(x, CultureInfo.InvariantCulture))
                .ToList();
        }
    }
}
