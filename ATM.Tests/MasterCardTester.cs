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
        [Test]
        public void GetAccountBalanceDoesNotThrow()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));

            Assert.DoesNotThrow(() => card.GetBalance());
        }
        [Test]
        public void GetAccountBalanceReturnsStartingBalance()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));

            Assert.AreEqual(1000M , card.GetBalance());
        }
        [Test]
        public void StartingBalanceCanNotStartInNegativeValues()
        {
            Assert.Throws<ArgumentException>(() => new MasterCard("5555555555555555", -1000M, 4322, new DateTime(2030, 10, 5)),"StartingBalance");
        }
        [Test]
        public void StartingBalanceCanStartOnZero()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 0M, 4322, new DateTime(2030, 10, 5));

            Assert.AreEqual(0M, card.GetBalance());
        }

        [TestCase((ushort)44358)]
        [TestCase((ushort)443)]
        public void PinCodeMustContainFourNumbers(ushort pinToSet)
        {
            Assert.Throws<ArgumentException>(() => new MasterCard("5555555555555555", 0M, pinToSet, new DateTime(2030, 10, 5)), "PinCode");
        }

        [Test]
        public void CheckPinCodeDoesNotThrow()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 0M, 4322, new DateTime(2030, 10, 5));
            Assert.DoesNotThrow(() => card.CheckPin(4212));
        }

        [Test]
        public void CheckPinCodeIsWrong()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 0M, 4322, new DateTime(2030, 10, 5));
            Assert.IsFalse(card.CheckPin(4212));
        }
        [Test]
        public void CheckPinCodeIsRight()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 0M, 4322, new DateTime(2030, 10, 5));
            Assert.IsTrue(card.CheckPin(4322));
        }

        [Test]
        public void RemoveMoneyFromAccountDoesNotThrow()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));
            Assert.DoesNotThrow(() => card.RemoveFromBalance(100m));
        }
        [Test]
        public void RemoveMoneyFromAccountDoesReturnValue()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));
            Assert.AreEqual(100m,card.RemoveFromBalance(100m));
        }
        [TestCase(122)]
        [TestCase(124)]
        [TestCase(444)]
        [TestCase(666)]
        [TestCase(999)]
        public void RemoveMoneyFromAccountReturnsAmountBack(decimal expected)
        {
            ICard card;
            card = new MasterCard("5555555555555555", 1000M, 4322, new DateTime(2030, 10, 5));
            Assert.AreEqual(expected, card.RemoveFromBalance(expected));
        }
        [TestCase(122)]
        [TestCase(124)]
        [TestCase(444)]
        [TestCase(666)]
        [TestCase(999)]
        public void RemovedMoneyGetsRemovedFromAccount(decimal expectedToDraw)
        {
            ICard card;
            decimal startingBalance = 1000M;
            card = new MasterCard("5555555555555555", startingBalance, 4322, new DateTime(2030, 10, 5));
            card.RemoveFromBalance(expectedToDraw);
            decimal expectedResult = startingBalance - expectedToDraw;
            Assert.AreEqual(expectedResult, card.GetBalance()); 
        }

        [TestCase(122)]
        [TestCase(124)]
        [TestCase(444)]
        [TestCase(666)]
        [TestCase(999)]
        public void CanDrawAllMoneyOut(decimal startingAndPulled)
        {
            ICard card;
            card = new MasterCard("5555555555555555", startingAndPulled, 4322, new DateTime(2030, 10, 5));
            card.RemoveFromBalance(startingAndPulled);

            Assert.AreEqual(0, card.GetBalance());
        }
        [Test]
        public void CardLockedAfterThreeTimesOfWrongPin()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 5500m, 4322, new DateTime(2030, 10, 5));
            card.CheckPin(3124);
            card.CheckPin(3114);
            card.CheckPin(3224);
            Assert.Throws<ArgumentException>(() => card.CheckPin(4322), "pinToCheck");
        } 
        [Test]
        public void CardResetsLockAttemptWhenRightPinIsEntered()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 5500m, 4322, new DateTime(2030, 10, 5));
            card.CheckPin(3124);
            card.CheckPin(3114);
            card.CheckPin(4322);

            card.CheckPin(3124);
            card.CheckPin(3114);
            card.CheckPin(3124);

            Assert.Throws<ArgumentException>(() => card.CheckPin(4322), "pinToCheck");
        }

        /// <summary>
        /// Default behavior of Datetime is not setting null, its set to 0001-01-01 00:00:00 by standard.
        /// </summary>
        [Test]
        public void CheckCardValditityIsNotSetToDefault()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 5500m, 4322, new DateTime(2030, 10, 5));
            

            Assert.AreNotEqual(new DateTime() ,card.ExpiryDate);
        }

        [Test]
        public void CheckCardValitityIsSetnInConstructor()
        {
            DateTime expected = new DateTime(2030, 10, 5);

            ICard card;
            card = new MasterCard("5555555555555555", 5500m, 4322, expected);

            Assert.AreEqual(expected, card.ExpiryDate);
        }
        [Test]
        public void CheckCardIsValid()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 5500m, 4322, new DateTime(2030, 10, 5));

            Assert.IsTrue(card.CheckCardValidity());
        }
        [Test]
        public void CheckCardIsInValid()
        {
            ICard card;
            card = new MasterCard("5555555555555555", 5500m, 4322, new DateTime(1995, 10, 5));

            Assert.IsFalse(card.CheckCardValidity());
        }
    }
}
