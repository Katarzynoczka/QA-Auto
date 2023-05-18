using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSerwis.PaymentMean.PaymentCard;

namespace PaymentSerwisTest.PaymentMeanTest.PaymentCardTest
{
    [TestClass]
    public class ValidityTest
    {
        [TestMethod]
        public void ValidityEqualsMethodTestPositive()
        {
            var validity1 = new Validity(12, 2023);
            var validity2 = new Validity(12, 2023);

            Assert.AreEqual(validity1, validity2);
        }

        [TestMethod]
        public void ValidityEqualsMethodTestNegative()
        {
            var validity1 = new Validity(12, 2023);
            var validity2 = new Validity(1, 2023);

            Assert.AreNotEqual(validity1, validity2);
        }

        [TestMethod]
        [DataRow(0, 2023)]
        [DataRow(1, 2022)]
        [DataRow(13, 2024)]
        [ExpectedException(typeof(FormatException))]
        public void ValidityExceptionTest(int validityDay, int validityYear)
        {
            var validity = new Validity(validityDay, validityYear);
        }
    }
}
