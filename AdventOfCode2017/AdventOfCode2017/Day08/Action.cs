namespace AdventOfCode2017.Day08
{
    using System.Collections.Generic;

    public class Action
    {
        public readonly string RegisterName;
        private readonly bool inc;
        private readonly int value;

        public Action(string registerName, bool inc, int value)
        {
            this.RegisterName = registerName;
            this.inc = inc;
            this.value = value;
        }

        public void Execute(ref IDictionary<string, int> existingRegisters, ref int highestHeldValueOverAllTime)
        {
            int tmpValue = 0;
            if (existingRegisters.TryGetValue(this.RegisterName, out int registerValue))
            {
                tmpValue = this.inc ? registerValue + this.value : registerValue - this.value;
                existingRegisters[this.RegisterName] = tmpValue;
            }
            else
            {
                tmpValue = this.inc ? this.value : 0 - this.value;
                existingRegisters.Add(this.RegisterName, tmpValue);
            }

            if (tmpValue > highestHeldValueOverAllTime)
                highestHeldValueOverAllTime = tmpValue;
        }
    }
}
