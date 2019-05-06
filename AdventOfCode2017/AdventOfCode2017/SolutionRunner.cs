namespace AdventOfCode2017
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class SolutionRunner
    {
        private static void Main(string[] args)
        {
            var tSolutions = Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.GetTypeInfo().IsClass && typeof(ISolution).IsAssignableFrom(t))
                .OrderBy(t => t.FullName)
                .Select(t => Activator.CreateInstance(t) as ISolution)
                .ToArray();

            foreach (var tSolution in tSolutions)
            {
                var solutions = tSolution.Run();
                Console.WriteLine($"Solution to {tSolution.GetName()} is: {string.Join(", ", solutions.Select(x => x.ToString()))}");
            }

            Console.ReadKey();
        }
    }
}