using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ATM_TestCases.Cards;

namespace ATM.Tests
{
    class MasterCardTester
    {
        [Test]
        public void ConstructorImplemented()
        {
            ICard card;
            Assert.DoesNotThrow(() => card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5)));
        }

        [Test]
        public void CardNumberIsSetWithConstructor()
        {
            ICard card;
            string expected = "5555555555555555";
            card = new MasterCard(expected, 1000M, 4322, new DateTime(2030, 10, 5));

            Assert.AreEqual(expected, card.CardNumber);
        }
        [Test]
        public void CardNumberIsNullWhenItShouldNot()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));

            Assert.AreNotEqual(null, card.CardNumber);
        }
    }
}
