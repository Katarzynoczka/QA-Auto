using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSerwis.PaymentMean.PaymentCard
{
    public class Validity
    {
        private int _validityMonth;
        private int _validityYear;
        public int ValidityMonth
        {
            get
            {
                return _validityMonth;
            }
            private set
            {
                if (value <= 12 && value > 0)
                {
                    _validityMonth = value;
                }
                else
                {
                    throw new FormatException("Invalid month format");
                }
            }
        }

        public int ValidityYear
        {
            get
            {
                return _validityYear;
            }
            private set
            {
                if (value >= DateTime.Today.Year)
                {
                    _validityYear = value;
                }
                else
                {
                    throw new FormatException("Invalid year format");
                }
            }
        }
        public Validity(int validityMonth, int validityYear)
        {
            ValidityMonth = validityMonth;
            ValidityYear = validityYear;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Validity validity)
            {
                return validity.ValidityMonth == ValidityMonth &&
                    validity.ValidityYear == ValidityYear;
            }
            return false;
        }

        public override int GetHashCode() => ValidityMonth.GetHashCode() + ValidityYear.GetHashCode();
    }
}
