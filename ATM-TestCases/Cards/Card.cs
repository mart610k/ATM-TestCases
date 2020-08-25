using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_TestCases.Cards
{
    public abstract class Card : ICard
    {
        public DateTime ExpiryDate { get; }

        public string CardNumber { get; }

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

        public Card(string cardNumber, decimal startingBalance, ushort pinCode, DateTime expiryDate)
        {
            
        }
    }
}
