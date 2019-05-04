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

            var result = calculator.Add("//,\n");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(8, "//,\n1,2,5")]
        [DataRow(1, "//,\n1")]
        [DataRow(6, "//,\n4,2")]
        [DataRow(11111, "//,\n1,10,100,1000,10000")]
        [DataRow(6, "//,\n1\n,2,3")]
        [DataRow(7, "//,\n1,\n2,4")]
        [DataRow(8, "//,\n1,2                       ,5")]
        public void Add_NumbersAreAddedCorrectly(int expected, string inpString)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(inpString);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(8, "//;\n1;3;4")]
        [DataRow(8, "//$\n1$3$4")]
        [DataRow(8, "//@\n1@3@4")]
        public void Add_CustomDelimietersSupported(int expected, string inpString)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(inpString);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_EmptyDelimiterIsRejected()
        {
            var calculator = new StringCalculator();

            calculator.Add("//\n123");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_NewLineDelimiterIsRejected()
        {
            var calculator = new StringCalculator();
            
            // To the code, this looks identical to an empty delimiter, but whatevs
            calculator.Add("//\n\n1\n2\n3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_MissingInputIsRejected()
        {
            var calculator = new StringCalculator();

            // To the code, this looks identical to an empty delimiter, but whatevs
            calculator.Add("//$");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("//,\n-1")]
        [DataRow("//,\n1,-1")]
        [DataRow("//,\n-1,1")]
        public void Add_NegativesRejected(string inpString)
        {
            var calculator = new StringCalculator();

            // To the code, this looks identical to an empty delimiter, but whatevs
            calculator.Add(inpString);
        }

        [TestMethod]
        [DataRow(0, "//,\n5000")]
        [DataRow(6, "//,\n1,5000,2,3")]
        [DataRow(7, "//,\n1,2,4,5000")]
        public void Add_LargeNumbersAreIgnored(int expected, string inpString)
        {
            var calculator = new StringCalculator();

            // To the code, this looks identical to an empty delimiter, but whatevs
            var result = calculator.Add(inpString);

            Assert.AreEqual(expected, result);
        }


    }
}
