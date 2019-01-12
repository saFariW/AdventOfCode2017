namespace AdventOfCode2017.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InputRow
    {
        private readonly Action action;
        private readonly Condition condition;

        public InputRow(string stringinput)
        {
            var x = stringinput.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            this.action = new Action(x[0], x[1] == "inc", int.Parse(x[2]));
            this.condition = new Condition(x[4], this.conditionParse(x[5]), int.Parse(x[6]));
        }

        public void Execute(ref IDictionary<string, int> currentRegisters)
        {
            if (this.condition.IsTrue(currentRegisters))
                this.action.Execute(ref currentRegisters);
        }

        private ConditionType conditionParse(string stringconditon)
        {
            switch (stringconditon)
            {
                case "<":
                    return ConditionType.SmallerThen;
                case ">":
                    return ConditionType.BiggerThen;
                case "==":
                    return ConditionType.Equal;
                case "!=":
                    return ConditionType.NotEqual;
                case "<=":
                    return ConditionType.SmallerOrEqual;
                case ">=":
                    return ConditionType.BiggerorEqual;
                default:
                    throw new Exception($"String input is not a supported condition: {stringconditon}");
            }
        }
    }
}
