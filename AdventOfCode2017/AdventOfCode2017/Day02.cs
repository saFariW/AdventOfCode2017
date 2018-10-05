namespace AdventOfCode2017
{
    using System.Collections.Generic;

    public static class Day02
    {
        public static int Solution01(List<List<int>> lines)
        {
            int sum = 0;

            foreach (var line in lines)
            {
                int maxValue = int.MinValue;
                int minValue = int.MaxValue;

                foreach (var cellValue in line)
                {
                    if (cellValue < minValue)
                    {
                        minValue = cellValue;
                    }

                    if (cellValue > maxValue)
                    {
                        maxValue = cellValue;
                    }
                }

                sum += maxValue - minValue;
            }

            return sum;
        }

        public static int Solution02(List<List<int>> lines)
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
