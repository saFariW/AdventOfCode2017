namespace AdventOfCode2017
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class SolutionDay01 : ISolution
    {
        public string GetName() => "Inverse Captcha";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? InputRepository.GetDay01Input();
            yield return this.Part01(input);
            yield return this.Part02(input);
        }

        public int Part01(string input)
        {
            return this.BasicSolution(input, 1);
        }

        public int Part02(string input)
        {
            return this.BasicSolution(input, input.Length / 2);
        }

        public int BasicSolution(string input, int delta)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[this.GetIndex(i, delta, input.Length)])
                {
                    sum += Convert.ToInt16(input[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                }
            }

            return sum;
        }

        public int GetIndex(int currentIndex, int delta, int arrayLenght)
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
