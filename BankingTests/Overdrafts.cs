using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class Overdrafts
    {
        [Fact]
        public void OerdraftDoesNotDecreaseBal()
        {
            var acct = new BankAccount();
            var openingBal = acct.GetBalance();
            try
            {
                acct.Withdraw(openingBal + 1);
            }
            catch (InsufficientFundsException) {
                //oof
            }
            
            Assert.Equal(openingBal, acct.GetBalance());
     
        }
        [Fact]
        public void OverdraftThrowsAnException() {
            var acct = new BankAccount();
            var openingBal = acct.GetBalance();

            Assert.Throws<InsufficientFundsException>(() => acct.Withdraw(openingBal + 1));
        }
        [Fact]
        public void YouCanTakeItAll() {
            var acct = new BankAccount();
            var openingBal = acct.GetBalance();

            acct.Withdraw(openingBal);
            Assert.Equal(0, acct.GetBalance());
        }
    }
}
