namespace AdventOfCode2017
{
    using System;
    using System.Globalization;

    public static class Day01
    {
        public static int Solution01(string input)
        {
            return BasicSolution(input, 1);
        }

        public static int Solution02(string input)
        {
            return BasicSolution(input, input.Length / 2);
        }

        public static int BasicSolution(string input, int delta)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[GetIndex(i, delta, input.Length)])
                {
                    sum += Convert.ToInt16(input[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                }
            }

            return sum;
        }

        public static int GetIndex(int currentIndex, int delta, int arrayLenght)
        {
            int newIndex;
            newIndex = currentIndex + delta;
            if (newIndex >= arrayLenght)
            {
                newIndex -= arrayLenght;
            }

            return newIndex;
        }
    }
}
