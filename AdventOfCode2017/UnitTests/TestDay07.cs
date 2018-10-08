namespace UnitTests
{
    using System.Collections.Generic;
    using AdventOfCode2017;
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

            Assert.AreEqual("tknk", Day07.Solution01(parsedInput));
        }
    }
}
