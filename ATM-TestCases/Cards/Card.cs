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

        protected int PinCode { get; set; }

        protected int AmountFailedAttempts { get; set; }

        public bool CheckPin(ushort pinToCheck)
        {
            if(AmountFailedAttempts >= 3)
            {
                throw new ArgumentException("Card have been locked after 3 failed attempts in a row", "pinToCheck");
            }
            else if(pinToCheck == PinCode)
            {
                AmountFailedAttempts = 0;
                return true;
            }
            else
            {
                AmountFailedAttempts++;
                return false;
            }
        }

        public decimal GetBalance()
        {
            return CurrentBalance;
        }

        public decimal RemoveFromBalance(decimal amountToRemove)
        {
            if(amountToRemove <= CurrentBalance)
            {
                CurrentBalance = CurrentBalance - amountToRemove;
                return amountToRemove;
            }
            else
            {
                return amountToRemove;
            }
        }

        public bool CheckCardValidity()
        {
            return true;
        }

        public Card(string cardNumber, decimal startingBalance, ushort pinCode, DateTime expiryDate)
        {
            AmountFailedAttempts = 0;
            if (Regex.IsMatch(cardNumber, "^[0-9]{16}$"))
            {
                CardNumber = cardNumber;
            }
            else
            {
                throw new ArgumentException("Value must contain 16 numbers", "CardNumber");
            }
            if(0 <= startingBalance)
            {
                CurrentBalance = startingBalance;
            }
            else
            {
                throw new ArgumentException("Value must start at equal or more than 0", "StartingBalance");
            }

            if(pinCode.ToString().Length != 4)
            {
                throw new ArgumentException("Value must be 4 characters long", "PinCode");
            }
            PinCode = pinCode;
            ExpiryDate = expiryDate;

        }
    }
}
