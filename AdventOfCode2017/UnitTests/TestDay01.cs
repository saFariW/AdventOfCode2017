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
            Assert.AreEqual(3, Day01.Solution01("1122"));
            Assert.AreEqual(4, Day01.Solution01("1111"));
            Assert.AreEqual(0, Day01.Solution01("1234"));
            Assert.AreEqual(9, Day01.Solution01("91212129"));
        }

        [TestMethod]
        public void TestInputRun02()
        {
            Assert.AreEqual(6, Day01.Solution02("1212"));
            Assert.AreEqual(0, Day01.Solution02("1221"));
            Assert.AreEqual(4, Day01.Solution02("123425"));
            Assert.AreEqual(12, Day01.Solution02("123123"));
            Assert.AreEqual(4, Day01.Solution02("12131415"));
        }

        [TestMethod]
        public void TestGetIndex()
        {
            Assert.AreEqual(1, Day01.GetIndex(0, 1, 3));
            Assert.AreEqual(2, Day01.GetIndex(1, 1, 3));
            Assert.AreEqual(0, Day01.GetIndex(2, 1, 3));
        }
    }
}
