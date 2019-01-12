namespace AdventOfCode2017.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Day04
    {
        public static int Solution01(List<List<string>> passPhrases)
        {
            return BasicSolution(passPhrases, Solution01Check);
        }

        public static int Solution02(List<List<string>> passPhrases)
        {
            return BasicSolution(passPhrases, Solution02Check);
        }

        public static int BasicSolution(List<List<string>> passPhrases, Func<List<List<string>>, int, int, int, bool> solutionCheck)
        {
            int totalCorrectPassPhrases = passPhrases.Count;

            for (int x = 0; x < passPhrases.Count; x++)
            {
                bool passPhraseIsValid = true;
                for (int i = 0; i < passPhrases[x].Count && passPhraseIsValid; i++)
                {
                    for (int j = 0; j < passPhrases[x].Count && passPhraseIsValid; j++)
                    {
                        if (j != i)
                        {
                            if (solutionCheck(passPhrases, i, j, x))
                            {
                                totalCorrectPassPhrases--;
                                passPhraseIsValid = false;
                            }
                        }
                    }
                }
            }

            return totalCorrectPassPhrases;
        }

        private static bool Solution01Check(List<List<string>> passPhrases, int i, int j, int x)
        {
            return passPhrases[x][i].Equals(passPhrases[x][j]);
        }

        private static bool Solution02Check(List<List<string>> passPhrases, int i, int j, int x)
        {
            return string.Concat(passPhrases[x][i].OrderBy(c => c)).Equals(string.Concat(passPhrases[x][j].OrderBy(c => c)));
        }
    }
}
