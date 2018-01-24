using InterestCalculator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public class Person : IPerson, IInterestCalculator
    {
        public List<Wallet> Wallets { get; set; }

        public decimal Calculate()
        {

            decimal totalInterest = 0;
            foreach (var wallet in Wallets)
            {
                foreach (var card in wallet.Cards)
                {
                    totalInterest += card.InterestAccrued;
                }
            }
            return totalInterest;

        }
    }
}
