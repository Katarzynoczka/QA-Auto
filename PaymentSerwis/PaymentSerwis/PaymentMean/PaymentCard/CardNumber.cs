using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean.PaymentCard
{
    public class CardNumber
    {
        private long _number;
        public long Number
        {
            get
            {
                return _number;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number cannot be negative");
                }
                _number = value;
            }
        }

        public CardNumber(long number)
        {
            Number = number;
        }

        public override bool Equals(object? obj)
        {
            if (obj is CardNumber cardNumber)
            {
                return cardNumber.Number == Number;
            }
            return false;
        }

        public override int GetHashCode() => Number.GetHashCode();
    }
}
