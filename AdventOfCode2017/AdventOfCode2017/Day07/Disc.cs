using System;

namespace AdventOfCode2017.Day07
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Disc
    {
        public string name;
        public int weight;
        public List<Disc> children;

        public Disc(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
            this.children = new List<Disc>(0);
        }

        public Disc(string line)
        {
            var lineOutput = Regex.Matches(line, "[0-9a-z]+")
                .Select(x => x.ToString())
                .ToList();

            this.name = lineOutput[0];
            this.weight = int.Parse(lineOutput[1]);

            this.children = lineOutput.Skip(2).Select(x => new Disc(x, 0)).ToList();
        }

        //only finds one unbalanced disc out of a whole tree
        // returns the first one.
        public bool TryFindUnbalancedDisc(out Disc disc)
        {
            var subProgramWeightValues = this.children.GroupBy(x => x.GetWeight()).OrderByDescending(x => x.Count()).ToList();

            if (subProgramWeightValues.Count <= 1)
            {
                foreach (var child in this.children)
                {
                    if (child.TryFindUnbalancedDisc(out disc))
                    {
                        return true;
                    }
                }

                disc = null;
                return false;
            }

            disc = this;
            return true;
        }

        public int GetWeight() => this.weight + this.children.Sum(x => x.GetWeight());

        public bool TryInsertDisc(Disc disc)
        {
            for (int i = 0; i < this.children.Count; i++)
            {
                if (disc.name == this.children[i].name)
                {
                    this.children[i] = disc;
                    return true;
                }

                if (this.children[i].TryInsertDisc(disc))
                {
                    return true;
                }
            }

            return false;
        }

        public static List<Disc> Flatten(Disc disc, List<Disc> flatList)
        {
            flatList.Add(disc);
            disc.children.ForEach(newDisc => Flatten(newDisc, flatList));
            return flatList;
        }
    }
}