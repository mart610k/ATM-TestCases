using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_TestCases.Cards
{
    public class MasterCard : Card
    {
        public MasterCard(string cardNumber,decimal startingBalance,ushort pinCode,DateTime expiryDate) : base(cardNumber, startingBalance, pinCode, expiryDate)
        {

        }
    }
}
