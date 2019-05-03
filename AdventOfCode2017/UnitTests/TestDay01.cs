namespace UnitTests
{
    using System.Linq;
    using AdventOfCode2017.Day01;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDay01
    {
        private SolutionDay01 sd01;

        [TestInitialize]
        public void Init()
        {
            this.sd01 = new SolutionDay01();
        }

        [TestMethod]
        public void TestInputRun01()
        {
            Assert.AreEqual(3, this.sd01.Run("1122").ElementAt(0));
            Assert.AreEqual(4, this.sd01.Run("1111").ElementAt(0));
            Assert.AreEqual(0, this.sd01.Run("1234").ElementAt(0));
            Assert.AreEqual(9, this.sd01.Run("91212129").ElementAt(0));
        }

        [TestMethod]
        public void TestInputRun02()
        {
            Assert.AreEqual(6, this.sd01.Run("1212").ElementAt(1));
            Assert.AreEqual(0, this.sd01.Run("1221").ElementAt(1));
            Assert.AreEqual(4, this.sd01.Run("123425").ElementAt(1));
            Assert.AreEqual(12, this.sd01.Run("123123").ElementAt(1));
            Assert.AreEqual(4, this.sd01.Run("12131415").ElementAt(1));
        }

        [TestMethod]
        public void TestGetIndex()
        {
            Assert.AreEqual(1, this.sd01.GetIndex(0, 1, 3));
            Assert.AreEqual(2, this.sd01.GetIndex(1, 1, 3));
            Assert.AreEqual(0, this.sd01.GetIndex(2, 1, 3));
        }

        [TestCleanup]
        public void Clean()
        {
            this.sd01 = null;
        }
    }
}
