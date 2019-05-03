namespace AdventOfCode2017.Day01
{
    using System.Collections.Generic;

    public class SolutionDay01 : ISolution
    {
        public string GetName() => "Day 1: Inverse Captcha";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay01;
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
                    sum += int.Parse(input[i].ToString());
                }
            }

            return sum;
        }

        /// <summary>
        /// Gets the next indexLocation for a ''round'' array.
        /// Meaning if there would normally be an arrayOutOfBound exception, it starts counting back from the beginning.
        /// </summary>
        /// <param name="currentIndex">The current location/Index</param>
        /// <param name="delta">The amount we want to jump forward in the array</param>
        /// <param name="arrayLength">The length of the array</param>
        /// <returns>The new location/index</returns>
        public int GetIndex(int currentIndex, int delta, int arrayLength)
        {
            if (currentIndex + delta >= arrayLength)
            {
                return currentIndex + delta - arrayLength;
            }

            return currentIndex + delta;
        }
    }
}
