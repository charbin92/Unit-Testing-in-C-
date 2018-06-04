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
    }
}
