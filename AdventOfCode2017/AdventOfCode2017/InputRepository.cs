namespace AdventOfCode2017
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public static class InputRepository
    {
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

        public static List<string> GetDay07Input()
        {
            return Properties.Resources.InputDay07
                .Split(Environment.NewLine)
                .ToList();
        }

        public static List<string> GetDay08Input()
        {
            return Properties.Resources.InputDay08
                .Split(Environment.NewLine)
                .ToList();
        }
    }
}
