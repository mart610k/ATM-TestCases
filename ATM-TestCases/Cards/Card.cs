using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_TestCases.Cards
{
    abstract class Card : ICard
    {
        public DateTime ExpiryDate => throw new NotImplementedException();

        public string CardNumber => throw new NotImplementedException();

        public bool CheckPin(ushort pinToCheck)
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public decimal RemoveFromBalance(decimal amountToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
