using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechInterview;

namespace Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullIsRejected()
        {
            var calculator = new StringCalculator();

            calculator.Add(null);
        }

        [TestMethod]
        public void Add_EmptyStringEqualsZero()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(8, "1,2,5")]
        [DataRow(1, "1")]
        [DataRow(6, "4,2")]
        [DataRow(11111, "1,10,100,1000,10000")]
        public void Add_NumbersAreAddedCorrectly(int expected, string inpString)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(inpString);

            Assert.AreEqual(expected, result);
        }
        
    }
}
