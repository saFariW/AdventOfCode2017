using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day06
    {
        public static int Solution01(List<int> memoryBank)
        {
            int cycles = 0;
            List<List<int>> bankDb = new List<List<int>>();

            while (!BankHasOccured(bankDb, memoryBank))
            {
                cycles++;

                // perform deep copy
                bankDb.Add(memoryBank.ConvertAll(x => x));

                int pos = GetLargestBankPos(memoryBank);
                int bankSize = memoryBank[pos];
                memoryBank[pos] = 0;

                while(bankSize > 0)
                {
                    pos = GetNextPos(pos, memoryBank);
                    memoryBank[pos]++;
                    bankSize--;
                }
            }
            return cycles;
        }

        private static int GetNextPos(int currentPos, List<int> bank)
        {
            if (currentPos + 1 < bank.Count())
                return currentPos + 1;
            return 0;
        }

        private static int GetLargestBankPos(List<int> bank)
        {
            int pos = 0;
            int banksize = int.MinValue;
            for (int i = 0; i < bank.Count; i++)
            {
                if (bank[i] > banksize)
                {
                    banksize = bank[i];
                    pos = i;
                }
            }
            return pos;
        }

        private static bool BankHasOccured(List<List<int>> bankDb, List<int> bank)
        {
            foreach (var oldBank in bankDb)
            {
                if (oldBank.SequenceEqual(bank))
                    return true;
            }
            return false;
        }


        public static int Solution02(List<int> memoryBanks)
        {

            return 0;
        }
    }
}
