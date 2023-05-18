using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSerwis.PaymentMean.PaymentCard;

namespace PaymentSerwisTest.PaymentMeanTest.PaymentCardTest
{
    [TestClass]
    public class CreditCardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreditCardExceptionTest()
        {
            var creditCard = new CreditCard(null, null, -1000f, 10000f);
        }

        [TestMethod]
        public void CreditCardEqualsMethodTestPositive()
        {
            var creditCard1 = new CreditCard(null, null, 1000f, 10000f);
            var creditCard2 = new CreditCard(null, null, 1000f, 10000f);
            Assert.AreEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        [DataRow(null, null, 2000f, 10000f)]
        [DataRow(null, null, 1000f, 10f)]
        public void CreditCardEqualsMethodTestNegative(CardNumber number, Validity validity, float balanceCashBack, float percentCashBack)
        {
            var creditCard1 = new CreditCard(null, null, 1000f, 10000f);
            var creditCard2 = new CreditCard(number, validity, balanceCashBack, percentCashBack);
            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardMakePaymentWithBalanceMethodTestPositive()
        {
            var creditCard = new CreditCard(null, null, 1000f, 10000f);
            var result = creditCard.MakePayment(1000f);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreditCardMakePaymentWithCreditLimitMethodTestPositive()
        {
            var creditCard = new CreditCard(null, null, 1000f, 10000f);
            var result = creditCard.MakePayment(11000f);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreditCardMakePaymentMethodTestNegative()
        {
            var creditCard = new CreditCard(null, null, 1000f, 1000f);
            var result = creditCard.MakePayment(5000f);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreditCardGetBalanceMethodTestPositive()
        {
            var сreditCard = new CreditCard(null, null, 1000f, 10000f);
            var result = сreditCard.GetBalance();
            Assert.AreEqual(11000f, result);
        }

        [TestMethod]
        public void CreditCardTopUpMethodTestPositive()
        {
            var creditCard = new CreditCard(null, null, 1000f, 10000f);
            creditCard.TopUp(1000f);
            var result = creditCard.GetBalance();
            Assert.AreEqual(12000f, result);
        }

        [TestMethod]
        public void CreditCardTopUpMethodTestNegative()
        {
            var creditCard = new CreditCard(null, null, 1000f, 10000f);
            creditCard.TopUp(1000f);
            var result = creditCard.GetBalance();
            Assert.AreNotEqual(11000f, result);
        }
    }
}
