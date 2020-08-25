using ATM_TestCases.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_TestCases.ATMClasses
{
    public class ATM : IATM
    {
        public ICard CardInserted => throw new NotImplementedException();

        public decimal GetAccountBalance()
        {
            throw new NotImplementedException();
        }

        public bool GetPinCodeFromUser(string pinInserted)
        {
            throw new NotImplementedException();
        }

        public bool InsertCard(ICard cardInserted)
        {
            throw new NotImplementedException();
        }

        public ICard RemoveCard()
        {
            throw new NotImplementedException();
        }

        public decimal RemoveFromBalance(decimal amountToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
