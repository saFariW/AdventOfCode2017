namespace AdventOfCode2017.Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDay02 : ISolution
    {
        public string GetName() => "Day 2: Corruption Checksum";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay02;

            var formattedInput = input.Split(Environment.NewLine)
                .Select(x => x.Split('\t')
                    .Select(y => int.Parse(y))
                    .ToList())
                .ToList();

            yield return formattedInput.Sum(line =>
                line.Max() - line.Min());
            yield return formattedInput.Sum(line =>
                line.Select((t1, i) =>
                    line.Where((t, j) => i != j)
                        .Where(t => t1 % t == 0)
                        .Sum(t => t1 / t))
                    .Sum());
        }
    }
}