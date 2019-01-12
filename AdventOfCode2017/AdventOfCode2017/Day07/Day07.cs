namespace AdventOfCode2017.Day07
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
    }
}
