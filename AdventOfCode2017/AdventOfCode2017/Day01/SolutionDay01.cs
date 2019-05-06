namespace AdventOfCode2017.Day01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDay01 : ISolution
    {
        public string GetName() => "Day 1: Inverse Captcha";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay01;

            // Changing the char's to integers
            List<int> formattedInput = input.Select(c => Convert.ToInt32(char.GetNumericValue(c))).ToList();

            // The '1' in this call specifies that the basicSolution method should compare the char with one, one position further in the input.
            yield return this.BaseSolution(formattedInput, 1);

            // Here we want to compare the char with one halfway away from the current char.
            yield return this.BaseSolution(formattedInput, input.Length / 2);
        }

        public int BaseSolution(List<int> input, int delta)
        {
            int linqIndex = 0;
            return input.Select(currentValue => GetValueIfSameAtIndex(this.GetIndex(linqIndex++, delta, input.Count), currentValue, input)).Sum();
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

        private static int GetValueIfSameAtIndex(int index, int value, List<int> list)
        {
            return list.ElementAt(index) == value ? value : 0;
        }
    }
}
