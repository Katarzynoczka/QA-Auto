using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSerwis.PaymentMean;
using PaymentSerwis.PaymentMean.PaymentCard;

namespace PaymentSerwis.BankCore
{
    public class BankClient
    {
        private string _name;
        private string _surname;
        private string _addres;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    throw new ArgumentException("Invalid Name format");
                }
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    throw new ArgumentException("Invalid Surname format");
                }
                _surname = value;
            }

        }

        public string Addres
        {
            get
            {
                return _addres;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid Address format");
                }
                _addres = value;
            }
        }

        public List<IPayment> PaymentMethods { get; }

        public BankClient(string name, string surname, string addres)
        {
            Name = name;
            Surname = surname;
            Addres = addres;
            PaymentMethods = new List<IPayment>();
        }

        public override string ToString() => $"{Name} {Surname}, {Addres}";
        public override bool Equals(object obj)
        {
            if (obj is BankClient bankClient)
            {
                return bankClient.Name == Name &&
                    bankClient.Surname == Surname &&
                    bankClient.Addres == Addres &&
                    bankClient.PaymentMethods.Sum(x => x.GetBalance()) == PaymentMethods.Sum(x => x.GetBalance());
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() + Addres.GetHashCode() + PaymentMethods.Sum(x => x.GetBalance().GetHashCode());
        }

        public bool AddPaymentMethod(IPayment Mean)
        {
            if (PaymentMethods.Contains(Mean))
            {
                return false;
            }
            PaymentMethods.Add(Mean);
            return true;
        }

        public bool Pay(float amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid payment amount");
            }
            foreach (IPayment paymentMethod in PaymentMethods)
            {
                if (paymentMethod is Cash cash)
                {
                    if (cash.MakePayment(amount))
                    {
                        return true;
                    }
                    continue;
                }
                else if (paymentMethod is CashBackCard cashBackCard)
                {
                    if (cashBackCard.MakePayment(amount))
                    {
                        return true;
                    }
                    continue;
                }
                else if (paymentMethod is DebetCard debetCard)
                {
                    if (debetCard.MakePayment(amount))
                    {
                        return true;
                    }
                    continue;
                }
                else if (paymentMethod is CreditCard creditCard)
                {
                    if (creditCard.MakePayment(amount))
                    {
                        return true;
                    }
                    continue;
                }
                else if (paymentMethod is BitCoin bitCoin)
                {
                    if (bitCoin.MakePayment(amount))
                    {
                        return true;
                    }
                    continue;
                }
            }
            return false;
        }


        public string DisplayBalances(List<IPayment> paymentMethods)
        {
            string result = "\nCurrent balances:";
            foreach (IPayment paymentMethod in PaymentMethods)
            {
                if (paymentMethod is Cash cash)
                {
                    result += $"\nCash: {cash.GetBalance()}";
                }
                else if (paymentMethod is CashBackCard cashBackCard)
                {
                    result += $"\nCashBack card: {cashBackCard.GetBalance()}";
                }
                else if (paymentMethod is DebetCard debetCard)
                {
                    result += $"\nDebet card: {debetCard.GetBalance()}";
                }
                else if (paymentMethod is CreditCard creditCard)
                {
                    result += $"\nCredit card: {creditCard.GetBalance()}";
                }
                else if (paymentMethod is BitCoin bitCoin)
                {
                    result += $"\nBitCoin: {bitCoin.GetBalance()}";
                }
            }
            return result;
        }
    }
}
