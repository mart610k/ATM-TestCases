using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ATM_TestCases.ATMClasses;
using ATM_TestCases.Cards;

namespace ATM_Tests
{
    class ATMTester
    {
        [Test]
        public void GetNullFromCardInserted()
        {
            IATM atm = new ATM();


            Assert.IsNull(atm.CardInserted);
        }

        [Test]
        public void InsertCardDoesNotThrow()
        {
            IATM atm = new ATM();
            ICard card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));

            Assert.DoesNotThrow(() => atm.InsertCard(card));
        }
        [Test]
        public void InsertCardInEmptyATMReturnsTrue()
        {
            IATM atm = new ATM();
            ICard card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));

            Assert.IsTrue(atm.InsertCard(card));
        }

        [Test]
        public void InsertCardSavesCardInATM()
        {
            IATM atm = new ATM();
            ICard card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));
            atm.InsertCard(card);
            Assert.NotNull(atm.CardInserted);
        }

        [Test]
        public void InsertingTwoCardsShouldReturnFalse()
        {
            IATM atm = new ATM();
            ICard card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));
            atm.InsertCard(card);
            Assert.IsFalse(atm.InsertCard(new MasterCard("4219273519234215", 1000M, 4322, new DateTime(2030, 10, 5))));
        }
    }
}
