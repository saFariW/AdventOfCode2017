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
                if (input[i] == input[GetIndex(i, 1, input.Length)])
                {
                    sum += Convert.ToInt16(input[i].ToString());
                }
            }
            return sum;
        }

        public static int Solution02(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[GetIndex(i, (input.Length /2), input.Length)])
                {
                    sum += Convert.ToInt16(input[i].ToString());
                }
            }
            return sum;
        }

        private static int GetIndex(int currentIndex, int delta, int arrayLenght)
        {
            int newIndex;
            newIndex = currentIndex + delta;
            if (newIndex >= arrayLenght)
                newIndex -= arrayLenght;

            return newIndex;
        }
    }
}
