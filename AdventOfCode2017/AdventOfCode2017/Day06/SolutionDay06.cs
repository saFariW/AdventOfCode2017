namespace AdventOfCode2017.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolutionDay06 : ISolution
    {
        public string GetName() => "Day 6: Memory Reallocation";

        public IEnumerable<object> Run(string input = null)
        {
            input = input ?? Properties.Resources.InputDay06;
            List<int> formattedInput = input
                .Split('\t')
                .Select(x => Convert.ToInt32(x))
                .ToList();

            var result = BaseSolution(formattedInput.ToList());

            yield return result.Item1;
            yield return result.Item2;
        }

        private static Tuple<int, int> BaseSolution(List<int> memoryBank)
        {
            int cycles = 0;
            List<List<int>> bankDb = new List<List<int>>();

            while (GetOccuringBankPos(bankDb, memoryBank) == -1)
            {
                cycles++;

                // Perform copy instead of ref
                bankDb.Add(memoryBank.ToList());

                // gGet the index of the largest memoryBank.
                int index = memoryBank.IndexOf(memoryBank.Max());
                int bankSize = memoryBank[index];
                memoryBank[index] = 0;

                while (bankSize > 0)
                {
                    index = GetNextIndex(index, memoryBank);
                    memoryBank[index]++;
                    bankSize--;
                }
            }

            return new Tuple<int, int>(cycles, cycles - GetOccuringBankPos(bankDb, memoryBank));
        }

        private static int GetNextIndex(int currentPos, List<int> bank)
        {
            if (currentPos + 1 < bank.Count)
                return currentPos + 1;
            return 0;
        }

        private static int GetOccuringBankPos(List<List<int>> bankDb, List<int> bank)
        {
            return bankDb.FindIndex(x => x.SequenceEqual(bank));
        }
    }
}