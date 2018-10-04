using System;
using System.Collections.Generic;

namespace AdventOfCode2017
{
    public static class Day05
    {
        public static int Solution01(List<int> instructions)
        {
            int steps = 0;
            int offset = 0;
            int pos = 0;

            while (pos < instructions.Count)
            {
                offset = instructions[pos];
                instructions[pos] = offset + 1;
                pos += offset;
                steps++;
            }

            return steps;
        }

        public static int Solution02(List<int> instructions)
        {
            int steps = 0;
            int offset = 0;
            int pos = 0;

            while (pos < instructions.Count)
            {
                offset = instructions[pos];

                if(offset >= 3)
                    instructions[pos] = offset - 1;
                else
                    instructions[pos] = offset + 1;

                pos += offset;
                steps++;
            }

            return steps;
        }
    }
}
