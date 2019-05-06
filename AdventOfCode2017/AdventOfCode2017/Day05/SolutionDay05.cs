namespace AdventOfCode2017.Day05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDay05 : ISolution
    {
        public string GetName() => "Day 5: A Maze of Twisty Trampolines, All Alike";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay05;
            var formattedInput = input
                    .Split(Environment.NewLine)
                    .Select(x => int.Parse(x))
                    .ToList();

            // WARNING: do not remove the 'extra' ToList(), this is to make an in memory copy,
            // so this method does not change the values. Otherwise this method will change the input before the next method call.
            // Ps: I love unitTests <3, and you should to!
            yield return BaseSolution(formattedInput.ToList(), (offset) => offset + 1);
            yield return BaseSolution(formattedInput.ToList(), (offset) => { if (offset >= 3) return offset - 1; else return offset + 1; });
        }

        private static int BaseSolution(List<int> instructions, Func<int, int> incrementRule)
        {
            int steps = 0, pos = 0;

            while (pos < instructions.Count)
            {
                int offset = instructions[pos];
                instructions[pos] = incrementRule(offset);
                pos += offset;
                steps++;
            }

            return steps;
        }
    }
}