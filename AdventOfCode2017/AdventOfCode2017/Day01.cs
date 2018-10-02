using System;

namespace AdventOfCode2017
{
    public static class Day01
    {
        public static int Solution01(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((i + 1) != input.Length)
                {
                    if (input[i] == input[i + 1])
                    {
                        sum += Convert.ToInt16(input[i].ToString());
                    }
                }
                else
                {
                    if (input[i] == input[0])
                    {
                        sum += Convert.ToInt16(input[i].ToString());
                    }
                }
            }
            return sum;
        }
    }
}
