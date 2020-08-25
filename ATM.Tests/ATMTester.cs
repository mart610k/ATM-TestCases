using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ATM_TestCases.ATMClasses;

namespace ATM.Tests
{
    class ATMTester
    {
        [Test]
        public void GetNullFromCardInserted()
        {
            IATM atm = new ATM_TestCases.ATMClasses.ATM();


            Assert.IsNull(atm.CardInserted);
        }
    }
}
