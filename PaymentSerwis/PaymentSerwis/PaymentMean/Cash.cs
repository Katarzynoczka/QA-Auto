using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean
{
    public class Cash : IPayment
    {
        private float _balanceCash;
        public float BalanceCash
        {
            get
            {
                return _balanceCash;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Debet balance cannot be negative");
                }
                _balanceCash = value;
            }
        }

        public Cash(float balanceCash)
        {
            BalanceCash = balanceCash;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Cash cash)
            {
                return cash.BalanceCash == BalanceCash;
            }
            return false;
        }

        public bool MakePayment(float amount)
        {
            if (BalanceCash >= amount)
            {
                BalanceCash -= amount;
                return true;
            }
            return false;
        }

        public void TopUp(float amount) => BalanceCash += amount;

        public float GetBalance() => BalanceCash;

        public override int GetHashCode() => BalanceCash.GetHashCode();
    }
}
