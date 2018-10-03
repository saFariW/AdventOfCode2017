using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day02
    {
        public static int Solution01(string input)
        {
            int sum = 0;
            var lines = ParseInput(input);

            foreach (var line in lines)
            {
                int maxValue = Int32.MinValue;
                int minValue = Int32.MaxValue;

                foreach (var cellValue in line)
                {
                    if (cellValue < minValue)
                        minValue = cellValue;
                    if (cellValue > maxValue)
                        maxValue = cellValue;
                }
                sum += (maxValue - minValue);
            }

            return sum;
        }

        public static int Solution02(string input)
        {
            int sum = 0;
            var lines = ParseInput(input);

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Count; i++)
                {
                    for (int j = 0; j < line.Count; j++)
                    {
                        if (i != j)
                        {
                            if (line[i] % line[j] == 0)
                                sum += line[i] / line[j];
                        }
                    }
                }
            }
            return sum;
        }

        private static List<List<int>> ParseInput(string input)
        {
            return input
                .Split(Environment.NewLine)
                .Select(x => x.Split('\t')
                .Select(y => Convert.ToInt32(y))
                .ToList())
                .ToList();
        }
    }
}
