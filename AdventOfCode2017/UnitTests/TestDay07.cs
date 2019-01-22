namespace UnitTests
{
    using System.Collections.Generic;
    using AdventOfCode2017;
    using AdventOfCode2017.Day07;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDay07
    {
        [TestMethod]
        public void TestInputRun01()
        {
            var parsedInput = new List<string>();
            parsedInput.Add("pbga(66)");
            parsedInput.Add("xhth(57)");
            parsedInput.Add("ebii(61)");
            parsedInput.Add("havc(66)");
            parsedInput.Add("ktlj(57)");
            parsedInput.Add("fwft(72)->ktlj, cntj, xhth");
            parsedInput.Add("qoyq(66)");
            parsedInput.Add("padx(45)->pbga, havc, qoyq");
            parsedInput.Add("tknk(41)->ugml, padx, fwft");
            parsedInput.Add("jptl(61)");
            parsedInput.Add("ugml(68)->gyxo, ebii, jptl");
            parsedInput.Add("gyxo(61)");
            parsedInput.Add("cntj(57)");

            Assert.AreEqual("Name: tknk Weight: 770", SolutionDay07.Part01And02(parsedInput));
        }

        [TestMethod]
        public void TestProgramGetWeight()
        {
            var program =
                new Program("test", 8, new List<Program>()
            {
                new Program("sub1", 10, new List<Program>()),
                new Program("sub2", 10, new List<Program>()),
                new Program("sub3", 9, new List<Program>())
            });

            Assert.AreEqual(38, program.GetTotalWeight());
        }
    }
}
