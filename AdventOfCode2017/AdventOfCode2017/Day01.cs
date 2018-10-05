namespace AdventOfCode2017
{
    using System;
    using System.Globalization;

    public static class Day01
    {
        public static int Solution01(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[GetIndex(i, 1, input.Length)])
                {
                    sum += Convert.ToInt16(Convert.ToString(input[i], CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                }
            }

            return sum;
        }

        public static int Solution02(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[GetIndex(i, input.Length / 2, input.Length)])
                {
                    sum += Convert.ToInt16(input[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                }
            }

            return sum;
        }

        private static int GetIndex(int currentIndex, int delta, int arrayLenght)
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
