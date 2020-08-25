using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ATM_TestCases.Cards
{
    public abstract class Card : ICard
    {
        public DateTime ExpiryDate { get; }

        public string CardNumber { get; protected set; }

        protected decimal CurrentBalance { get; set; }

        public bool CheckPin(ushort pinToCheck)
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance()
        {
            return CurrentBalance;
        }

        public decimal RemoveFromBalance(decimal amountToRemove)
        {
            throw new NotImplementedException();
        }

        public Card(string cardNumber, decimal startingBalance, ushort pinCode, DateTime expiryDate)
        {
            if (Regex.IsMatch(cardNumber, "^[0-9]{16}$"))
            {
                CardNumber = cardNumber;
            }
            else
            {
                throw new ArgumentException("Value must contain 16 numbers", "CardNumber");
            }
            if(0 < startingBalance)
            {
                CurrentBalance = startingBalance;
            }
            else
            {
                throw new ArgumentException("Value must start at equal or more than 0", "StartingBalance");
            }

        }
    }
}
