using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_TestCases.Cards
{
    public interface ICard
    {
        DateTime ExpiryDate { get; }
        string CardNumber { get; }


        bool CheckPin(ushort pinToCheck);

        decimal RemoveFromBalance(decimal amountToRemove);

        decimal GetBalance();

        bool CheckCardValidity();

    }
}
