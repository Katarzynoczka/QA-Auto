using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean.PaymentCard
{
    public class DebetCard : PaymentCard
    {
        private float _balanceDebet;
        public float BalanceDebet
        {
            get
            {
                return _balanceDebet;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Debet balance cannot be negative");
                }
                _balanceDebet = value;
            }
        }

        public DebetCard(CardNumber number, Validity validity, float balanceDebet) : base(number, validity)
        {
            BalanceDebet = balanceDebet;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DebetCard debetCard)
            {
                return debetCard.BalanceDebet == BalanceDebet;
            }
            return false;
        }

        public override bool MakePayment(float amount)
        {
            if (BalanceDebet >= amount)
            {
                BalanceDebet -= amount;
                return true;
            }
            return false;
        }

        public override void TopUp(float amount) => BalanceDebet += amount;

        public override float GetBalance() => BalanceDebet;

        public override int GetHashCode() => BalanceDebet.GetHashCode();
    }
}
