namespace AdventOfCode2017.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Day08
    {
        public static string Solution01(List<string> input)
        {
            IDictionary<string, int> registers = new Dictionary<string, int>();

            input.ForEach(x => new InputRow(x).Execute(ref registers));

            return $"max value in registers is: {registers.Values.Max()}";
        }
    }
}