namespace AdventOfCode2017.Day07
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDay07 : ISolution
    {
        public string GetName() => "Day 7: Recursive Circus";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay07;

            List<Disc> discs = input
                .Split(Environment.NewLine)
                .Select(x => new Disc(x))
                .ToList();

            while (discs.Count() > 1)
            {
                for (int i = 0; i < discs.Count; i++)
                {
                    if (discs[i] == null)
                        continue;

                    for (int j = 0; j < discs.Count; j++)
                    {
                        if (discs[j] == null || i == j)
                            continue;

                        if (discs[i].TryInsertDisc(discs[j]))
                            discs[j] = null;
                    }
                }

                discs.RemoveAll(x => x == null);
            }

            yield return discs.First().name;

            var flatDiscs = Disc.Flatten(discs.First(), new List<Disc>());
            Disc faultyDisc = flatDiscs.Single(disc => disc.children.Select(y => y.GetWeight()).Distinct().Count() > 1);

            // TODO split this piece of code in smaller pieces of code just because kek
            int correctSubWeight = faultyDisc.children.GroupBy(x => x.GetWeight())
                .OrderByDescending(x => x.Count())
                .First().Key;

            yield return Math.Abs((correctSubWeight * faultyDisc.children.Count()) - faultyDisc.GetWeight());
        }
    }
}