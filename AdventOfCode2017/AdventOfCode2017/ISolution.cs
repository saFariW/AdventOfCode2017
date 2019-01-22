namespace AdventOfCode2017
{
    using System.Collections.Generic;

    public interface ISolution
    {
        string GetName();

        IEnumerable<object> Run(string input = null);
    }
}
