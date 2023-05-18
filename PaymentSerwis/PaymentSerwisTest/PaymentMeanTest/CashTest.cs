using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSerwis.PaymentMean;

namespace PaymentSerwisTest.PaymentMeanTest
{
    [TestClass]
    public class CashTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CashExceptionTest()
        {
            var cash = new Cash(-1000f);
        }

        [TestMethod]
        public void CashEqualsMethodTestPositive()
        {
            var cash1 = new Cash(1000f);
            var cash2 = new Cash(1000f);
            Assert.AreEqual(cash1, cash2);
        }

        [TestMethod]
        public void CashEqualsMethodTestNegative()
        {
            var cash1 = new Cash(1000f);
            var cash2 = new Cash(2000f);
            Assert.AreNotEqual(cash1, cash2);
        }

        [TestMethod]
        public void CashMakePaymentMethodTestPositive()
        {
            var cash = new Cash(1000f);
            var result = cash.MakePayment(1000f);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CashMakePaymentMethodTestNegative()
        {
            var cash = new Cash(1000f);
            var result = cash.MakePayment(5000f);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CashGetBalanceMethodTestPositive()
        {
            var cash = new Cash(1000f);
            var result = cash.GetBalance();
            Assert.AreEqual(1000f, result);
        }

        [TestMethod]
        public void CashTopUpMethodTestPositive()
        {
            var cash = new Cash(1000f);
            cash.TopUp(1000f);
            var result = cash.GetBalance();
            Assert.AreEqual(2000f, result);
        }

        [TestMethod]
        public void CashTopUpMethodTestNegative()
        {
            var cash = new Cash(1000f);
            cash.TopUp(1000f);
            var result = cash.GetBalance();
            Assert.AreNotEqual(1000f, result);
        }
    }
}
