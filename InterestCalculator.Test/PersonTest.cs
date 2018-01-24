using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterestCalculator;
using InterestCalculator.Contracts;
using System.Collections.Generic;

namespace InterestCalculator.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Person1CardsInterest_ReturnsExpected()
        {
            Person person = new Person();
            decimal expectedInterestCard1 = 10;
            decimal expectedInteresCard2 = 5;
            decimal expectedInterestCard3 = 1;

            var card1 = new CreditCard(100, "Visa");

            var card2 = new CreditCard(100, "MC");
            var card3 = new CreditCard(100, "Discover");

            List<CreditCard> cards = new List<CreditCard>();
            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);

            person.Wallets = new List<Wallet>();
            person.Wallets.Add(new Wallet { Cards = cards });

            decimal actualInterestForPerson = person.Calculate();
            decimal expectedInterestForPerson = 16;

            Assert.AreEqual(expectedInterestCard1, card1.InterestAccrued);
            Assert.AreEqual(expectedInteresCard2, card2.InterestAccrued);
            Assert.AreEqual(expectedInterestCard3, card3.InterestAccrued);
            Assert.AreEqual(expectedInterestForPerson, actualInterestForPerson);
        }

        [TestMethod]
        public void CalculateInterestByPersonandWallet_ReturnsExpected()
        {
            decimal expectedInterestOnWallet1 = 11;
            decimal expectedInterestonWallet2 = 5;
            Person person = new Person();

            var card1 = new CreditCard(100, "Visa");
            var card3 = new CreditCard(100, "Discover");
            List<CreditCard> cards = new List<CreditCard>();
            cards.Add(card1);
            cards.Add(card3);
            person.Wallets = new List<Wallet>();
            var wallet1 = new Wallet
            {
                Cards = cards
            };
            person.Wallets.Add(wallet1);
            var card2 = new CreditCard(100, "MC");
            var wallet2Cards = new List<CreditCard>();
            wallet2Cards.Add(card2);

            var wallet2 = new Wallet();
            wallet2.Cards = wallet2Cards;
            person.Wallets.Add(wallet2);

            decimal actualWallet1 =wallet1.Calculate();
            decimal actualWallet2 = wallet2.Calculate();
            decimal actualInterestForPerson = person.Calculate();
            decimal expectedInterestForPerson = 16;
            Assert.AreEqual(expectedInterestForPerson, actualInterestForPerson);
            Assert.AreEqual(expectedInterestOnWallet1, actualWallet1);
            Assert.AreEqual(expectedInterestonWallet2, actualWallet2);
        }
        [TestMethod]
        public void CalculateInteresByPersonWalletMultiplePeople_ReturnsExpected()
        {
            
            decimal expectedInterestForPerson1 = 15;
            decimal expectedInterestOnWalletForPerson1 = 15;
            decimal expectedInterestOnWalletForPerson2 = 15;

            Person person1 = new Person();

            var card1 = new CreditCard(100, "Visa");
            var card3 = new CreditCard(100, "MC");
            List<CreditCard> cards = new List<CreditCard>();
            cards.Add(card1);
            cards.Add(card3);
            person1.Wallets = new List<Wallet>();
            var wallet1 = new Wallet
            {
                Cards = cards
            };
            person1.Wallets.Add(wallet1);
            decimal actualInterestForPerson1 = person1.Calculate();
            decimal actualInterestOnWalletForPerson1 = wallet1.Calculate();
            Person person2 = new Person();

            var card2 = new CreditCard(100, "Visa");
            var card4 = new CreditCard(100, "MC");
            List<CreditCard> person2_cards = new List<CreditCard>();
            person2_cards.Add(card2);
            person2_cards.Add(card4);
            person2.Wallets = new List<Wallet>();
            var wallet_person2 = new Wallet
            {
                Cards = person2_cards
            };
            person2.Wallets.Add(wallet_person2);
            decimal actualInterestOnWalletForPerson2 = wallet_person2.Calculate();


            Assert.AreEqual(expectedInterestForPerson1, actualInterestForPerson1);
            Assert.AreEqual(expectedInterestOnWalletForPerson1, actualInterestOnWalletForPerson1);
            Assert.AreEqual(expectedInterestOnWalletForPerson2, actualInterestOnWalletForPerson2);
        }
    }

    
}
