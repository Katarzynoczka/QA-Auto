using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean.PaymentCard
{
    public class CashBackCard : PaymentCard
    {
        private float _balanceCashBack;
        public float BalanceCashBack
        {
            get
            {
                return _balanceCashBack;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The CashBack balance cannot be negative");
                }
                _balanceCashBack = value;
            }
        }
        public float PercentCashBack { get; set; }


        public CashBackCard(CardNumber number, Validity validity, float balanceCashBack, float percentCashBack) : base(number, validity)
        {
            BalanceCashBack = balanceCashBack;
            PercentCashBack = percentCashBack;
        }

        public override bool Equals(object? obj)
        {
            if (obj is CashBackCard cashBackCard)
            {
                return cashBackCard.BalanceCashBack == BalanceCashBack &&
                    cashBackCard.PercentCashBack == PercentCashBack;
            }
            return false;
        }

        public override bool MakePayment(float amount)
        {
            if (BalanceCashBack >= amount)
            {
                BalanceCashBack -= amount;
                float cashBackAmount = amount * PercentCashBack / 100;
                BalanceCashBack += cashBackAmount;
                return true;
            }
            return false;
        }

        public override void TopUp(float amount) => BalanceCashBack += amount;


        public override float GetBalance() => BalanceCashBack;

        public override int GetHashCode() => BalanceCashBack.GetHashCode();
    }
}
