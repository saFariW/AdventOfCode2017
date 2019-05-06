namespace UnitTests
{
    using System;
    using System.Linq;
    using AdventOfCode2017.Day05;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDay05
    {
        private SolutionDay05 sd05;

        [TestInitialize]
        public void Init()
        {
            this.sd05 = new SolutionDay05();
        }

        [TestMethod]
        public void TestInputRun01()
        {
            string input = "0" + Environment.NewLine +
                           "3" + Environment.NewLine +
                           "0" + Environment.NewLine +
                           "1" + Environment.NewLine +
                           "-3";

            Assert.AreEqual(5, this.sd05.Run(input).ElementAt(0));
        }

        [TestMethod]
        public void TestInputRun02()
        {
            string input = "0" + Environment.NewLine +
                           "3" + Environment.NewLine +
                           "0" + Environment.NewLine +
                           "1" + Environment.NewLine +
                           "-3";

            Assert.AreEqual(10, this.sd05.Run(input).ElementAt(1));
        }

        [TestCleanup]
        public void Clean()
        {
            this.sd05 = null;
        }
    }
}
