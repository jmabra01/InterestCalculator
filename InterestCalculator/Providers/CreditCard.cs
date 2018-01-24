using InterestCalculator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public class CreditCard : ICreditCard, IInterestCalculator
    {
        public string CardName { get; set; }

        //public decimal RateOfInterest { get; set; }

        public decimal Balance { get; set; }

        public decimal InterestAccrued { get; set; }

        public CreditCard(decimal balance, string cardName)
        {
            Balance = balance;
            CardName = cardName;
            InterestAccrued = Calculate();
        }

        public decimal Calculate()
        {
            decimal roi = GetRateOfInterestByCardType(CardName);

            return Balance * roi; 
        }
        public decimal GetRateOfInterestByCardType(string CardName)
        {
            if(String.IsNullOrEmpty(CardName))
            {
                throw new NullReferenceException("CardName");
            }

            decimal roi = 0M;
            switch (CardName.ToUpper())
            {
                case "VISA":
                    roi = 0.1M;
                    break;
                case "MC":
                    roi = .05M;
                    break;
                case "DISCOVER":
                    roi = .01M;
                    break;
                default:
                    roi = 0M;
                    break;
            }

            return roi;
        }
    }
}
