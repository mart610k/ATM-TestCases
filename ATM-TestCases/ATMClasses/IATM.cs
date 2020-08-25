using ATM_TestCases.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_TestCases.ATMClasses
{
    public interface IATM
    {
        ICard CardInserted { get; }

        bool GetPinCodeFromUser(string pinInserted);

        decimal GetAccountBalance();

        decimal RemoveFromBalance(decimal amountToRemove);

        bool InsertCard(ICard cardInserted);

        ICard RemoveCard();
    }
}
