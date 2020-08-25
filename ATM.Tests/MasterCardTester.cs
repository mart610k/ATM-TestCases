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
        [Test]
        public void CardNumberThrowArgumentExecptionWhenContainsLowerCaseLetters()
        {
            ICard card;
            Assert.Throws<ArgumentException>(() =>card = new MasterCard("55f5555a55555555", 1000M, 4322, new DateTime(2030, 10, 5)), "CardNumber");
        }
        [Test]
        public void CardNumberThrowArgumentExecptionWhenContainsUpperCaseLetters()
        {
            ICard card;
            Assert.Throws<ArgumentException>(() => card = new MasterCard("55F5555A55555555", 1000M, 4322, new DateTime(2030, 10, 5)), "CardNumber");
        }
        [Test]
        public void CardNumberNotLongerThan16Characters()
        {
            ICard card;
            Assert.Throws<ArgumentException>(() => card = new MasterCard("5555555555555555545688", 1000M, 4322, new DateTime(2030, 10, 5)), "CardNumber");
        }
        [Test]
        public void CardNumberNotLessThan16Characters()
        {
            ICard card;
            Assert.Throws<ArgumentException>(() => card = new MasterCard("44456842548", 1000M, 4322, new DateTime(2030, 10, 5)), "CardNumber");
        }
    }
}
