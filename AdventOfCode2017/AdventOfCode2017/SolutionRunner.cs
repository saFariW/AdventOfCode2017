namespace AdventOfCode2017
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class SolutionRunner
    {
        private static void Main(string[] args)
        {
            var tsolutions = Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.GetTypeInfo().IsClass && typeof(ISolution).IsAssignableFrom(t))
                .OrderBy(t => t.FullName)
                .Select(t => Activator.CreateInstance(t) as ISolution)
                .ToArray();

            foreach (var tsolution in tsolutions)
            {
                var solutions = tsolution.Run();
                Console.WriteLine($"Solution to {tsolution.GetName()} is: {string.Join(',', solutions.Select(x => x.ToString()))}");
            }

            Console.ReadKey();
        }
    }
}