namespace AdventOfCode2017.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDay04 : ISolution
    {
        public string GetName() => "Day 4: High-Entropy Passphrases";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay04;
            var formattedInput = input
                .Split(Environment.NewLine)
                .Select(x => x.Split(' ')
                    .ToList())
                .ToList();

            // 2e param is the check on witch the passPhrase needs to comply. in this case no duplicates.
            //  Thus querying the phrase for duplicates words, if there are give back false (does not comply).
            yield return BaseSolution(formattedInput, list => !list.GroupBy(word => word).Any(g => g.Count() > 1));

            // The little trick i perform here is ill sort the char's per word, and count how many same words there are in one line. If more than one it does not comply.
            yield return BaseSolution(formattedInput, list => !list.Select(y => string.Join(string.Empty, y.ToCharArray().OrderBy(x => x))).GroupBy(word => word).Any(group => group.Count() > 1));
        }

        private static int BaseSolution(List<List<string>> passPhrases, Func<List<string>, bool> passPhraseCheck)
        {
            return passPhrases.Where(passPhraseCheck).Count();
        }
    }
}
