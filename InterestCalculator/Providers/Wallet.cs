using InterestCalculator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public class Wallet : IWallet,IInterestCalculator
    {
        public List<CreditCard> Cards { get; set; }

        public decimal Calculate()
        {
            decimal totalInterest = 0;
            
            foreach (var card in Cards)
            {
                totalInterest += card.InterestAccrued;
            }

            return totalInterest;
        }
    }
}
