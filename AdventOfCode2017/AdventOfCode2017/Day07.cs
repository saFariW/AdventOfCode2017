﻿namespace AdventOfCode2017
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    // check if tree sort might be something that would easy this solution / performance.
    public static class Day07
    {
        public static string Solution(List<string> programsInput)
        {
            List<Program> programs = new List<Program>();
            foreach (var programLine in programsInput)
            {
                programs.Add(ParseProgramInput(programLine));
            }

            while (programs.Count > 1)
            {
                for (int i = 0; i < programs.Count; i++)
                {
                    if (programs[i] == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < programs.Count; j++)
                    {
                        if (programs[j] == null)
                        {
                            continue;
                        }

                        if (programs[i].TryInsertSubProgram(programs[j]))
                        {
                            programs[j] = null;
                        }
                    }
                }

                programs.RemoveAll(x => x == null);
            }

            var program = programs.First();
            return "Name: " + program.Name + " Weight: " + program.GetTotalWeight();
        }

        private static Program ParseProgramInput(string inputLine)
        {
            var parsedInputLine = Regex.Matches(inputLine, "[0-9a-z]+")
                .Select(x => x.ToString())
                .ToList();

            List<Program> subPrograms = new List<Program>();
            for (int i = 2; i < parsedInputLine.Count; i++)
            {
                subPrograms.Add(new Program(parsedInputLine[i], 0, new List<Program>()));
            }

            return new Program(parsedInputLine[0], Convert.ToInt32(parsedInputLine[1], CultureInfo.InvariantCulture), subPrograms);
        }

        public class Program
        {
            public string Name { get; }

            public int Weight { get; }

            private readonly List<Program> subPrograms;

            public Program(string name, int weight, List<Program> subPrograms)
            {
                this.Name = name;
                this.Weight = weight;
                this.subPrograms = subPrograms;
            }

            /// <summary>
            /// retrieves the total weight of this program.
            /// </summary>
            /// <remarks>
            /// Will correct any faults in the balance of the programs sub's tree
            /// </remarks>
            /// <returns>the total weight of this program.</returns>
            public int GetTotalWeight()
            {
                if (this.subPrograms.Count() == 0)
                {
                    return this.Weight;
                }

                var subProgramWeightValues = this.subPrograms.Select(x => x).GroupBy(x => x.GetTotalWeight()).OrderByDescending(x => x.Count()).ToList();

                if (subProgramWeightValues.Count() > 1)
                {
                    // TODO MarWolt: Implement this as designed instead of this 'unintentional behavior'.
                    // there is an assumption here that there is only 1 program that has the wrong weight.
                    var unbalancedProgram = subProgramWeightValues.OrderByDescending(x => x.Count()).Last().Last();

                    var diffrence = Math.Abs(subProgramWeightValues.First().First().GetTotalWeight() - unbalancedProgram.GetTotalWeight());

                    Console.WriteLine("Unbalanced program new own weight is: " + (unbalancedProgram.Weight - diffrence));
                }

                return this.Weight + (this.subPrograms.Count() * subProgramWeightValues.First().First().GetTotalWeight());
            }

            public bool TryInsertSubProgram(Program program)
            {
                for (int i = 0; i < this.subPrograms.Count; i++)
                {
                    if (program.Name == this.subPrograms[i].Name)
                    {
                        this.subPrograms[i] = program;
                        return true;
                    }

                    if (this.subPrograms[i].TryInsertSubProgram(program))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
