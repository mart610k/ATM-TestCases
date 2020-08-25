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
            Assert.DoesNotThrow(() => card = new MasterCard("5555555555555555",1000M,4322,new DateTime(2030,10,5))) ;
        }


    }
}
