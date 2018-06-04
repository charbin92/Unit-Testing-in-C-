using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void debitWithValidAmountUpdateBalanceTest()
        {
            // arrange
            const double beginningBalance = 11.99;
            const double debitAmount = 4.55;
            const double expected = 7.44;

            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.debit(debitAmount);

            // assert
            double actual = account.getBalance();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void debitWhenAmountIsLessThanZeroTest()
        {
            // arrange
            const double beginningBalance = 11.99;
            const double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.debit(debitAmount);

            // assert is handled by ExpecteExeption
        }

        [TestMethod]
        public void debitWhenAmountIsMoreThanBalanceTest()
        {
            // arrange
            const double beginningBalance = 11.99;
            const double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            try
            {
                account.debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("No exception was thrown.");
        }
    }
}
