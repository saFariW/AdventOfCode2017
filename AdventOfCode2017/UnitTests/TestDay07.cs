namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2017.Day07;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDay07
    {
        [TestMethod]
        public void TestInputRun01()
        {
            var parsedInput = new List<string>
            {
                "pbga(66)",
                "xhth(57)",
                "ebii(61)",
                "havc(66)",
                "ktlj(57)",
                "fwft(72)->ktlj, cntj, xhth",
                "qoyq(66)",
                "padx(45)->pbga, havc, qoyq",
                "tknk(41)->ugml, padx, fwft",
                "jptl(61)",
                "ugml(68)->gyxo, ebii, jptl",
                "gyxo(61)",
                "cntj(57)"
            };

            //Assert.AreEqual("Name: tknk Weight: 770", SolutionDay07.Part01And02(parsedInput));
        }

        [TestMethod]
        public void TestProgramGetWeight()
        {
            var disc = new Disc("ugml(68)->gyxo, ebii, jptl");
            disc.children.Add(new Disc("gyxo(61)"));

            Assert.AreEqual(129, disc.GetWeight());
        }

        [TestMethod]
        public void TestInputRun01v2()
        {
            var solution = new SolutionDay07();
            var test =
            "pbga(66)" + Environment.NewLine +
            "xhth(57)" + Environment.NewLine +
            "ebii(61)" + Environment.NewLine +
            "havc(66)" + Environment.NewLine +
            "ktlj(57)" + Environment.NewLine +
            "fwft(72) -> ktlj, cntj, xhth" + Environment.NewLine +
            "qoyq(66)" + Environment.NewLine +
            "padx(45) -> pbga, havc, qoyq" + Environment.NewLine +
            "tknk(41) -> ugml, padx, fwft" + Environment.NewLine +
            "jptl(61)" + Environment.NewLine +
            "ugml(68) -> gyxo, ebii, jptl" + Environment.NewLine +
            "gyxo(61)" + Environment.NewLine +
            "cntj(57)";

            var x = solution.Run(test).ToList();
        }

        [TestMethod]
        public void TryFindUnbalancedDiscNoChildren()
        {
            var disc = new Disc("ugml(68)");
            Assert.AreEqual(false, disc.TryFindUnbalancedDisc(out Disc disc2));
        }

        [TestMethod]
        public void TryFindUnbalancedDiscBalancedChildrenSimple()
        {
            var disc = new Disc("ugml(68) -> gyxo, ebii, jptl");
            disc.TryInsertDisc(new Disc("gyxo(61)"));
            disc.TryInsertDisc(new Disc("ebii(61)"));
            disc.TryInsertDisc(new Disc("jptl(61)"));
            Assert.AreEqual(false, disc.TryFindUnbalancedDisc(out Disc disc2));
        }

        /*
        [TestMethod]
        public void TryFindUnbalancedDiscBalancedChildrenSimple()
        {
            var disc = new Disc("ugml(68) -> gyxo, ebii, jptl");
            var disc2 = new Disc("padx(45) -> pbga, havc");
            disc2.TryInsertDisc(new Disc("pbga(10)"));
            disc2.TryInsertDisc(new Disc("havc(10)"));
            var disc3 = new Disc("jptl(45) -> fdas, yuio, lkjj");

            disc.TryInsertDisc(disc2);
            disc.TryInsertDisc(disc3);
            disc.TryInsertDisc(new Disc("jptl(61)"));
            Assert.AreEqual(false, disc.TryFindUnbalancedDisc(out Disc fdsafas));
        }

        [TestMethod]
        public void TryFindUnbalancedDiscNoChildren()
        {
            var disc = new Disc("ugml(68)");
            Assert.AreEqual(false, disc.TryFindUnbalancedDisc(out Disc disc2));
        }
        */
    }
}
