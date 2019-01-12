namespace AdventOfCode2017.Day07
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private readonly List<Program> subPrograms;

        public Program(string name, int weight, List<Program> subPrograms)
        {
            this.Name = name;
            this.Weight = weight;
            this.subPrograms = subPrograms;
        }

        public string Name { get; }

        public int Weight { get; }

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