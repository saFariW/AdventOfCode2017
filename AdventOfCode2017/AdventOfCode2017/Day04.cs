﻿namespace AdventOfCode2017
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Day04
    {
        public static int Solution01(List<List<string>> passPhrases)
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
                            if (passPhrases[x][i].Equals(passPhrases[x][j]))
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

        public static int Solution02(List<List<string>> passPhrases)
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
                            if (string.Concat(passPhrases[x][i].OrderBy(c => c)).Equals(string.Concat(passPhrases[x][j].OrderBy(c => c))))
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
    }
}
