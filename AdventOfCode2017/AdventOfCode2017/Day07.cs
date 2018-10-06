namespace AdventOfCode2017
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    // check if treesort might be something that would easy this solution / performance.
    public static class Day07
    {
        public static string Solution01(List<string> programsInput)
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
                    for (int j = 0; j < programs.Count; j++)
                    {
                        if (programs[i] != null)
                        {
                            if (programs[j].TryInsertSubProgram(programs[i]))
                            {
                                programs[i] = null;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                programs.RemoveAll(x => x == null);
            }


            return programs.First().Name;
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

        private class Program
        {
            public readonly string Name;
            private readonly int weight;
            private readonly List<Program> subPrograms;

            public Program(string name, int weight, List<Program> subPrograms)
            {
                this.Name = name;
                this.weight = weight;
                this.subPrograms = subPrograms;
            }

            public int GetWeight()
            {
                int subProgramsWeight = 0;
                foreach (var subProgram in this.subPrograms)
                {
                    subProgramsWeight += subProgram.GetWeight();
                }

                return this.weight + subProgramsWeight;
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
