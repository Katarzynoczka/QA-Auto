using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean.PaymentCard
{
    public class CreditCard : PaymentCard
    {
        private float _balanceCredit;
        public float BalanceCredit
        {
            get
            {
                return _balanceCredit;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Credit balance cannot be negative");
                }
                _balanceCredit = value;
            }
        }
        public float CreditLimit { get; set; }

        public CreditCard(CardNumber number, Validity validity, float balanceCredit, float creditLimit) : base(number, validity)
        {
            BalanceCredit = balanceCredit;
            CreditLimit = creditLimit;
        }

        public override bool Equals(object? obj)
        {
            if (obj is CreditCard creditCard)
            {
                return creditCard.BalanceCredit == BalanceCredit &&
                    creditCard.CreditLimit == CreditLimit;
            }
            return false;
        }

        public override bool MakePayment(float amount)
        {
            if (BalanceCredit >= amount)
            {
                BalanceCredit -= amount;
                return true;
            }
            else if (BalanceCredit + CreditLimit >= amount)
            {
                float amountToCharge = amount - BalanceCredit;
                BalanceCredit = 0;
                CreditLimit -= amountToCharge;
                return true;
            }
            return false;
        }

        public override void TopUp(float amount) => BalanceCredit += amount;

        public override float GetBalance() => BalanceCredit + CreditLimit;

        public override int GetHashCode() => BalanceCredit.GetHashCode() + CreditLimit.GetHashCode();
    }
}
