using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSerwis.PaymentMean;

namespace PaymentSerwisTest.PaymentMeanTest
{
    [TestClass]
    public class BitCoinTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BitCoinExceptionTest()
        {
            var bitCoin = new BitCoin(-1000f);
        }

        [TestMethod]
        public void BitCoinEqualsMethodTestPositive()
        {
            var bitCoin1 = new BitCoin(1000f);
            var bitCoin2 = new BitCoin(1000f);
            Assert.AreEqual(bitCoin1, bitCoin2);
        }

        [TestMethod]
        public void BitCoinEqualsMethodTestNegative()
        {
            var bitCoin1 = new BitCoin(1000f);
            var bitCoin2 = new BitCoin(2000f);
            Assert.AreNotEqual(bitCoin1, bitCoin2);
        }

        [TestMethod]
        public void BitCoinMakePaymentMethodTestPositive()
        {
            var bitCoin = new BitCoin(1000f);
            var result = bitCoin.MakePayment(1000f);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BitCoinMakePaymentMethodTestNegative()
        {
            var bitCoin = new BitCoin(1000f);
            var result = bitCoin.MakePayment(5000f);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BitCoinGetBalanceMethodTestPositive()
        {
            var bitCoin = new BitCoin(1000f);
            var result = bitCoin.GetBalance();
            Assert.AreEqual(1000f, result);
        }

        [TestMethod]
        public void BitCoinTopUpMethodTestPositive()
        {
            var bitCoin = new BitCoin(1000f);
            bitCoin.TopUp(1000f);
            var result = bitCoin.GetBalance();
            Assert.AreEqual(2000f, result);
        }

        [TestMethod]
        public void BitCoinTopUpMethodTestNegative()
        {
            var bitCoin = new BitCoin(1000f);
            bitCoin.TopUp(1000f);
            var result = bitCoin.GetBalance();
            Assert.AreNotEqual(1000f, result);
        }
    }
}
