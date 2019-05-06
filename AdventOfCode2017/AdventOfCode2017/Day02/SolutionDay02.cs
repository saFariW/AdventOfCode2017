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

            yield return this.Part01(formattedInput);
            yield return this.Part02(formattedInput);
        }

        public int Part01(List<List<int>> lines)
        {
            return lines.Sum(line => line.Max() - line.Min());
        }

        public int Part02(List<List<int>> lines)
        {
            int sum = 0;

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Count; i++)
                {
                    for (int j = 0; j < line.Count; j++)
                    {
                        if (i != j)
                        {
                            if (line[i] % line[j] == 0)
                            {
                                sum += line[i] / line[j];
                            }
                        }
                    }
                }
            }

            return sum;
        }
    }
}
