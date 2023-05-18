using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSerwis.PaymentMean;
using PaymentSerwis.PaymentMean.PaymentCard;

namespace PaymentSerwisTest.PaymentMeanTest.PaymentCardTest
{
    [TestClass]
    public class CardNumberTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberExceptionZeroTest()
        {
            var number = new CardNumber(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberExceptionNegativeTest()
        {
            var number = new CardNumber(-1234567812345678);
        }

        [TestMethod]
        public void NumberEqualsMethodTestPositive()
        {
            var number1 = new CardNumber(1000100010001000);
            var number2 = new CardNumber(1000100010001000);
            Assert.AreEqual(number1, number2);
        }

        [TestMethod]
        public void NumberEqualsMethodTestNegative()
        {
            var number1 = new CardNumber(1000100010001000);
            var number2 = new CardNumber(2000200020002000);
            Assert.AreNotEqual(number1, number2);
        }
    }
}
