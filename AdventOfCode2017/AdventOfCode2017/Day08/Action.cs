namespace AdventOfCode2017.Day08
{
    using System;
    using System.Collections;
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

        public void Execute(ref IDictionary<string, int> exsistingRegisters)
        {
            if (exsistingRegisters.TryGetValue(this.RegisterName, out int registerValue))
                exsistingRegisters[this.RegisterName] =
                    this.inc ? registerValue + this.value : registerValue - this.value;
            else
                exsistingRegisters.Add(this.RegisterName, this.inc ? this.value : 0 - this.value);
        }
    }
}
