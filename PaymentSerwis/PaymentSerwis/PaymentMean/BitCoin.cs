using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean
{
    public class BitCoin : IPayment
    {
        private float _balanceBitCoin;
        public float BalanceBitCoin
        {
            get
            {
                return _balanceBitCoin;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The BitCoin balance cannot be negative");
                }
                _balanceBitCoin = value;
            }
        }

        public BitCoin(float balanceBitCoin)
        {
            BalanceBitCoin = balanceBitCoin;
        }

        public override bool Equals(object? obj)
        {
            if (obj is BitCoin bitCoin)
            {
                return bitCoin.BalanceBitCoin == BalanceBitCoin;
            }
            return false;
        }

        public bool MakePayment(float amount)
        {
            if (BalanceBitCoin >= amount)
            {
                BalanceBitCoin -= amount;
                return true;
            }
            return false;
        }

        public void TopUp(float amount) => BalanceBitCoin += amount;

        public float GetBalance() => BalanceBitCoin;

        public override int GetHashCode() => BalanceBitCoin.GetHashCode();
    }
}
