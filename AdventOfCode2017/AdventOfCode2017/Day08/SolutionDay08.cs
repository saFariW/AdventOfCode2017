namespace AdventOfCode2017.Day08
{
    using System.Collections.Generic;
    using System.Linq;

    public static class SolutionDay08
    {
        public static string Part01And02(List<string> input)
        {
            int maxValueOverAllTime = int.MinValue;
            IDictionary<string, int> registers = new Dictionary<string, int>();

            input.ForEach(x => new InputRow(x).Execute(ref registers, ref maxValueOverAllTime));

            return $"the current highest value in registers is: {registers.Values.Max()}, and the max value over time was: {maxValueOverAllTime}";
        }
    }
}