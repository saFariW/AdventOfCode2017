namespace UnitTests
{
    using AdventOfCode2017;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDay01
    {
        [TestMethod]
        public void TestInputRun01()
        {
            Assert.AreEqual(3, SolutionDay01.Part01("1122"));
            Assert.AreEqual(4, SolutionDay01.Part01("1111"));
            Assert.AreEqual(0, SolutionDay01.Part01("1234"));
            Assert.AreEqual(9, SolutionDay01.Part01("91212129"));
        }

        [TestMethod]
        public void TestInputRun02()
        {
            Assert.AreEqual(6, SolutionDay01.Part02("1212"));
            Assert.AreEqual(0, SolutionDay01.Part02("1221"));
            Assert.AreEqual(4, SolutionDay01.Part02("123425"));
            Assert.AreEqual(12, SolutionDay01.Part02("123123"));
            Assert.AreEqual(4, SolutionDay01.Part02("12131415"));
        }

        [TestMethod]
        public void TestGetIndex()
        {
            Assert.AreEqual(1, SolutionDay01.GetIndex(0, 1, 3));
            Assert.AreEqual(2, SolutionDay01.GetIndex(1, 1, 3));
            Assert.AreEqual(0, SolutionDay01.GetIndex(2, 1, 3));
        }
    }
}
