using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSerwis.PaymentMean.PaymentCard;

namespace PaymentSerwisTest.PaymentMeanTest.PaymentCardTest
{
    [TestClass]
    public class DebetCardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DebetCardExceptionTest()
        {
            var debetCard = new DebetCard(null, null, -1000f);
        }

        [TestMethod]
        public void DebetCardEqualsMethodTestPositive()
        {
            var debetCard1 = new DebetCard(null, null, 1000f);
            var debetCard2 = new DebetCard(null, null, 1000f);
            Assert.AreEqual(debetCard1, debetCard2);
        }

        [TestMethod]
        public void CashBackCardEqualsMethodTestNegative()
        {
            var debetCard1 = new DebetCard(null, null, 1000f);
            var debetCard2 = new DebetCard(null, null, 100f);
            Assert.AreNotEqual(debetCard1, debetCard2);
        }

        [TestMethod]
        public void DebetCardMakePaymentMethodTestPositive()
        {
            var debetCard = new DebetCard(null, null, 1000f);
            var result = debetCard.MakePayment(1000f);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DebetCardMakePaymentMethodTestNegative()
        {
            var debetCard = new DebetCard(null, null, 1000f);
            var result = debetCard.MakePayment(5000f);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DebetCardGetBalanceMethodTestPositive()
        {
            var debetCard = new DebetCard(null, null, 1000f);
            var result = debetCard.GetBalance();
            Assert.AreEqual(1000f, result);
        }

        [TestMethod]
        public void DebetCardTopUpMethodTestPositive()
        {
            var debetCard = new DebetCard(null, null, 1000f);
            debetCard.TopUp(1000f);
            var result = debetCard.GetBalance();
            Assert.AreEqual(2000f, result);
        }

        [TestMethod]
        public void DebetCardTopUpMethodTestNegative()
        {
            var debetCard = new DebetCard(null, null, 1000f);
            debetCard.TopUp(1000f);
            var result = debetCard.GetBalance();
            Assert.AreNotEqual(1000f, result);
        }
    }
}
