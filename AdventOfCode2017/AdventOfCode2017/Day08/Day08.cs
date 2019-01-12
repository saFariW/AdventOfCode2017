namespace AdventOfCode2017.Day08
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Day08
    {
        public static string Solution(List<string> input)
        {
            int maxValueOverAllTime = int.MinValue;
            IDictionary<string, int> registers = new Dictionary<string, int>();

            input.ForEach(x => new InputRow(x).Execute(ref registers, ref maxValueOverAllTime));

            return $"the current highest value in registers is: {registers.Values.Max()}, and the max value over time was: {maxValueOverAllTime}";
        }
    }
}