namespace AdventOfCode2017.Day08
{
    using System;
    using System.Collections.Generic;

    public class Condition
    {
        public readonly string RegisterName;
        private readonly ConditionType type;
        private readonly int value;

        public Condition(string registerName, ConditionType type, int value)
        {
            this.RegisterName = registerName;
            this.type = type;
            this.value = value;
        }

        public bool IsTrue(IDictionary<string, int> currentRegisters)
        {
            int registerValue = 0;
            if (currentRegisters.TryGetValue(this.RegisterName, out int actualRegisterValue))
                registerValue = actualRegisterValue;

            switch (this.type)
            {
                case ConditionType.SmallerThen:
                    return registerValue < this.value;
                case ConditionType.BiggerThen:
                    return registerValue > this.value;
                case ConditionType.Equal:
                    return registerValue == this.value;
                case ConditionType.NotEqual:
                    return registerValue != this.value;
                case ConditionType.SmallerOrEqual:
                    return registerValue <= this.value;
                case ConditionType.BiggerOrEqual:
                    return registerValue >= this.value;
                default:
                    throw new Exception($"Condition: {this.type.ToString()} is not supported");
            }
        }
    }
}
