namespace UnitTests
{
    using System;
    using System.Linq;
    using AdventOfCode2017.Day04;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDay04
    {
        private SolutionDay04 sd04;

        [TestInitialize]
        public void Init()
        {
            this.sd04 = new SolutionDay04();
        }

        [TestMethod]
        public void TestInputRun01()
        {
            // single lines
            Assert.AreEqual(1, this.sd04.Run("aa bb cc dd ee").ElementAt(0));
            Assert.AreEqual(0, this.sd04.Run("aa bb cc dd aa").ElementAt(0));
            Assert.AreEqual(1, this.sd04.Run("aa bb cc dd aaa").ElementAt(0));

            // multi line input
            Assert.AreEqual(2, this.sd04.Run("aa bb cc dd ee" + Environment.NewLine +
                                             "aa bb cc dd aa" + Environment.NewLine +
                                             "aa bb cc dd aaa").ElementAt(0));
        }

        [TestMethod]
        public void TestInputRun02()
        {
            // single lines
            Assert.AreEqual(1, this.sd04.Run("abcde fghij").ElementAt(1));
            Assert.AreEqual(0, this.sd04.Run("abcde xyz ecdab").ElementAt(1));
            Assert.AreEqual(1, this.sd04.Run("a ab abc abd abf abj").ElementAt(1));
            Assert.AreEqual(1, this.sd04.Run("iiii oiii ooii oooi oooo").ElementAt(1));
            Assert.AreEqual(0, this.sd04.Run("oiii ioii iioi iiio").ElementAt(1));

            // multi line input
            Assert.AreEqual(3, this.sd04.Run("abcde fghij" + Environment.NewLine +
                                             "abcde xyz ecdab" + Environment.NewLine +
                                             "a ab abc abd abf abj" + Environment.NewLine +
                                             "iiii oiii ooii oooi oooo" + Environment.NewLine +
                                             "oiii ioii iioi iiio").ElementAt(1));
        }

        [TestCleanup]
        public void Clean()
        {
            this.sd04 = null;
        }
    }
}
