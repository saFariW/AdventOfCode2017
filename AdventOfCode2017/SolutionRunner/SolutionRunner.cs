using System;
using AdventOfCode2017;

namespace SolutionRunner
{
    class SolutionRunner
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Output day01 part 01: " + Day01.Solution01(InputRepository.GetDay01Input()));
            Console.WriteLine("Output day01 part 02: " + Day01.Solution02(InputRepository.GetDay01Input()));
            Console.ReadKey();
        }
    }
}
