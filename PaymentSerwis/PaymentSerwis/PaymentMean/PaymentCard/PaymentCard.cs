using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean.PaymentCard
{
    abstract public class PaymentCard : IPayment
    {
        public Validity Validity { get; }
        public CardNumber Number { get; }

        public PaymentCard(CardNumber number, Validity validity)
        {
            Number = number;
            Validity = validity;
        }
        public abstract bool MakePayment(float amount);
        public abstract void TopUp(float amount);

        public abstract float GetBalance();
    }
}
