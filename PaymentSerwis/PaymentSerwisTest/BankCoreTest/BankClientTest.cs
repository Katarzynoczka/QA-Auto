using PaymentSerwis.PaymentMean.PaymentCard;
using PaymentSerwis.BankCore;
using PaymentSerwis.PaymentMean;


namespace PaymentSerwisTest.BankCoreTest
{
    [TestClass]
    public class BankClientTests
    {
        [TestMethod]
        public void BankClientToStringMethodTestPositive()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            string expectedResult = "Kate Bayok, Goreckogo 9";
            string actualResult = bankClient.ToString();

            Assert.IsTrue(actualResult == expectedResult);
        }

        [TestMethod]
        public void BankClientToStringMethodTestNegative()
        {

            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            string expectedResult = "Kate Bayok Goreckogo 9";
            string actualResult = bankClient.ToString();

            Assert.IsFalse(actualResult == expectedResult);
        }

        [TestMethod]
        public void BankClientEqualsMethodTestPositive()
        {
            var bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            bankClient1.AddPaymentMethod(new CashBackCard(null, null, 300f, 5f));
            var bankClient2 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient2.AddPaymentMethod(new Cash(1000f));
            bankClient2.AddPaymentMethod(new CashBackCard(null, null, 300f, 5f));

            Assert.AreEqual(bankClient1, bankClient2);
        }

        [TestMethod]
        [DataRow("K", "Bayok", "Goreckogo 9")]
        [DataRow("Kate", "B", "Goreckogo 9")]
        [DataRow("Kate", "Bayok", "G")]

        public void BankClientEqualsTestNegative(string name, string surName, string addres)
        {
            var bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            var bankClient2 = new BankClient(name, surName, addres);
            bankClient2.AddPaymentMethod(new Cash(1000f));

            Assert.AreNotEqual(bankClient1, bankClient2);
        }

        [TestMethod]
        public void BankClientEqualsMethodTestWithListNegative()
        {
            var bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            var bankClient2 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient2.AddPaymentMethod(new Cash(1000f));
            bankClient2.AddPaymentMethod(new CashBackCard(null, null, 300f, 5f));

            Assert.AreNotEqual(bankClient1, bankClient2);
        }

        [TestMethod]
        public void BankClientEqualsMethodTestWithOnePaymentMethodNegative()
        {
            var bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            var bankClient2 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient2.AddPaymentMethod(new Cash(2000f));

            Assert.AreNotEqual(bankClient1, bankClient2);
        }
        [TestMethod]
        public void BankClientAddPaymentMethodTestPositive()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            Assert.AreEqual(0, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(1, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            Assert.AreEqual(2, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new CreditCard(null, null, 13f, 2000f));
            Assert.AreEqual(3, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new DebetCard(null, null, 100f));
            Assert.AreEqual(4, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new BitCoin(100f));
            Assert.AreEqual(5, bankClient.PaymentMethods.Count);
        }

        [TestMethod]
        public void BankClientAddPaymentMethodTestNegative()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(0, bankClient.PaymentMethods.Count);
        }

        [TestMethod]
        public void BankClientAddPaymentMethodTestDuplicatePositive()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(1, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            Assert.AreEqual(2, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new CreditCard(null, null, 13f, 2000f));
            bankClient.AddPaymentMethod(new CreditCard(null, null, 13f, 2000f));
            Assert.AreEqual(3, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new DebetCard(null, null, 100f));
            bankClient.AddPaymentMethod(new DebetCard(null, null, 100f));
            Assert.AreEqual(4, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new BitCoin(100f));
            bankClient.AddPaymentMethod(new BitCoin(100f));
            Assert.AreEqual(5, bankClient.PaymentMethods.Count);
        }

        [TestMethod]
        public void BankClientAddPaymentMethodTestDuplicateNegative()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(2, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            Assert.AreNotEqual(4, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new CreditCard(null, null, 13f, 2000f));
            bankClient.AddPaymentMethod(new CreditCard(null, null, 13f, 2000f));
            Assert.AreNotEqual(6, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new DebetCard(null, null, 100f));
            bankClient.AddPaymentMethod(new DebetCard(null, null, 100f));
            Assert.AreNotEqual(8, bankClient.PaymentMethods.Count);
            bankClient.AddPaymentMethod(new BitCoin(100f));
            bankClient.AddPaymentMethod(new BitCoin(100f));
            Assert.AreNotEqual(10, bankClient.PaymentMethods.Count);
        }

        [TestMethod]
        [DataRow("", "Bayok", "Goreckogo 9")]
        [DataRow(null, "Bayok", "Goreckogo 9")]
        [DataRow("qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm", "Bayok", "Goreckogo 9")]
        [DataRow("Kate", "", "Goreckogo 9")]
        [DataRow("Kate", null, "Goreckogo 9")]
        [DataRow("Kate", "qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmBayok", "Goreckogo 9")]
        [ExpectedException(typeof(ArgumentException))]
        public void BankClientNameSurNameExceptionTest(string name, string surName, string addres)
        {
            var bankClient = new BankClient(name, surName, addres);
        }

        [TestMethod]
        [DataRow("Kate", "Bayok", "")]
        [DataRow("Kate", "Bayok", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BankClientAddresExceptionTest(string name, string surName, string addres)
        {
            var bankClient = new BankClient(name, surName, addres);
        }

        [TestMethod]
        public void BankClientPayMethodEnoughMoneyTestPositive()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CreditCard(null, null, 1000f, 2000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new DebetCard(null, null, 1000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
        }

        [TestMethod]
        public void BankClientPayMethodEnoughMoneyTestNegative()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CreditCard(null, null, 1000f, 2000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new DebetCard(null, null, 1000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
        }

        [TestMethod]
        public void BankClientPayMethodNotEnoughMoneyTestPositive()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CreditCard(null, null, 1000f, 2000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new DebetCard(null, null, 1000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
        }

        [TestMethod]
        public void BankClientPayMethodNotEnoughMoneyTestNegative()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CreditCard(null, null, 1000f, 2000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new DebetCard(null, null, 1000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
        }

        [TestMethod]
        public void BankClientPayMethodZeroPaymentMethodTest()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BankClientPayMethodNegativeSumExceptionTest()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.Pay(-1000f);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BankClientPayMethodZeroSumExceptionTest()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.Pay(0);
        }

        [TestMethod]
        public void BankClientDisplayBalanceTestPositive()
        {
            var bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, null, 1000f, 12f));
            bankClient.AddPaymentMethod(new CreditCard(null, null, 1000f, 0f));
            bankClient.AddPaymentMethod(new DebetCard(null, null, 1000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));

            var stringWriter = bankClient.DisplayBalances(bankClient.PaymentMethods);

            var expectedResult =
            "\nCurrent balances:" +
            "\nCash: 1000" +
            "\nCashBack card: 1000" +
            "\nCredit card: 1000" +
            "\nDebet card: 1000" +
            "\nBitCoin: 1000";

            var actualResult = stringWriter.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
