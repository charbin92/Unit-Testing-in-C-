/*
 * AUTHOR: Cody Harbin
 * DATE: 06/03/2018
 * PURPOSE: This program is to create a bank account with errors in the code
 *          that will be fixed with Unit Testing. The error in this class is
 *          the "balance += amount" should actually have a minus not a plus
 *          sign before the epuals sign.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        private readonly string customerName;
        private double balance;
        private bool frozen = false;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds Balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";

        private BankAccount()
        {

        }

        public BankAccount(string customerName, double balance)
        {
            this.customerName = customerName;
            this.balance = balance;
        }

        public string getCustomerName()
        {
            return customerName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void debit(double amount)
        {
            if(frozen)
            {
                throw new Exception("Account Frozen");
            }

            if(amount > balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            balance -= amount; //intentionally incorrect code
        }

        public void credit(double amount)
        {
            if (frozen)
                throw new Exception("Account frozen");

            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");

            balance += amount;
        }

        private void freezeAccount()
        {
            frozen = true;
        }

        private void unfreezeAccount()
        {
            frozen = false;
        }
    }
}
