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
            List<List<int>> lines = input
                .Split(Environment.NewLine)
                .Select(x => x.Split('\t')
                .Select(y => Convert.ToInt32(y))
                .ToList())
                .ToList();
            
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
    }
}
