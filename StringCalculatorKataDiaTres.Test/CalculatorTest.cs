using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StringCalculatorKataDiaTres.Library;

namespace StringCalculatorKataDiaTres.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void ShouldReturnZeroWhenIsEmptyString()
        {
            Assert.AreEqual(0,_calculator.Add(string.Empty));
        }

        [Test]
        public void ShouldReturnTheSameNumber()
        {
            Assert.AreEqual(1, _calculator.Add("1"));
            Assert.AreEqual(2, _calculator.Add("2"));
        }

        [Test]
        public void ShouldReturnTheSum()
        {
            Assert.AreEqual(3, _calculator.Add("1,2"));
            Assert.AreEqual(5, _calculator.Add("2,3"));
        }

        [Test]
        public void ShouldAcceptANewSeparator()
        {
            Assert.AreEqual(6, _calculator.Add("1\n2,3"));            
        }

        [Test]
        public void ShouldAddANewSeparator()
        {
            Assert.AreEqual(3, _calculator.Add("//;\n1;2"));
        }

        [Test]
        public void ShouldThrowAnExceptionWhenIsNegative()
        {
            try
            {
                _calculator.Add("-1");
            }
            catch (Exception e)
            {
                Assert.AreEqual("negatives not allowed",e.Message);                
            }
        }

        [Test]
        public void ShouldNotAddNumbersBiggerThan1000()
        {
            Assert.AreEqual(2, _calculator.Add("1001,2"));
        }

        [Test]
        public void ShouldAddANewSeparatorOfAnyLength()
        {
            Assert.AreEqual(6, _calculator.Add("//[***]\n1***2***3"));
        }

        [Test]
        public void ShouldVariousSeparators()
        {
            Assert.AreEqual(6, _calculator.Add("//[*][%]\n1*2%3"));
        }

        [Test]
        public void ShouldVariousSeparatorsOfAnyLength()
        {
            Assert.AreEqual(6, _calculator.Add("//[******][%%%]\n1******2%%%3"));
        }
    }    
}
