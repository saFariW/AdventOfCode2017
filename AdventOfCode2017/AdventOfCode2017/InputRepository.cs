namespace AdventOfCode2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class InputRepository
    {
        public static List<int> GetDay06Input()
        {
            return Properties.Resources.InputDay06
                .Split('\t')
                .Select(x => Convert.ToInt32(x))
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
