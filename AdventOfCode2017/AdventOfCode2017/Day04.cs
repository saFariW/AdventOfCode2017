using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day04
    {
        public static int Solution01(string input)
        {
            var passPhrases = input
                .Split(Environment.NewLine)
                .Select(x => x.Split(' ')
                .ToList())
                .ToList();

            int totalCorrectPassPhrases = passPhrases.Count;

            for (int x = 0; x < passPhrases.Count; x++)
            {
                bool passPhraseIsValid = true;
                for (int i = 0; i < passPhrases[x].Count && passPhraseIsValid; i++)
                {
                    for (int j = 0; j < passPhrases[x].Count && passPhraseIsValid; j++)
                    {
                        if (j != i)
                            if (passPhrases[x][i].Equals(passPhrases[x][j]))
                            {
                                totalCorrectPassPhrases--;
                                passPhraseIsValid = false;
                            }
                    }
                }
            }
            return totalCorrectPassPhrases;
        }
        public static int Solution02(string input)
        {
            var passPhrases = input
                .Split(Environment.NewLine)
                .Select(x => x.Split(' ')
                .ToList())
                .ToList();

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
                            if (String.Concat(passPhrases[x][i].OrderBy(c => c)).Equals(String.Concat(passPhrases[x][j].OrderBy(c => c))))
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
