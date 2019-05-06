namespace AdventOfCode2017.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDay08 : ISolution
    {
        public string GetName() => "Day 8: I Heard You Like Registers";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay08;

            List<string> formattedInput = input
                .Split(Environment.NewLine)
                .ToList();

            int maxValueOverAllTime = int.MinValue;
            IDictionary<string, int> registers = new Dictionary<string, int>();

            formattedInput.ForEach(x => new InputRow(x).Execute(ref registers, ref maxValueOverAllTime));

            yield return registers.Values.Max();
            yield return maxValueOverAllTime;
        }
    }
}