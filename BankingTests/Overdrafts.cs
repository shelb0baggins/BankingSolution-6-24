using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class Overdrafts
    {

        private decimal _openingBal;
        private BankAccount _acct;

        public Overdrafts()
        {
            _acct = new BankAccount(new Mock<ICalculateBonuses>().Object, new Mock<INarcOnAccounts>().Object);
            _openingBal = _acct.GetBalance();
        }
        [Fact]
        public void OverdraftDoesNotDecreaseBal()
        {
            
            try
            {
                _acct.Withdraw(_openingBal + 1);
            }
            catch (InsufficientFundsException) {
                //oof
            }
            
            Assert.Equal(_openingBal, _acct.GetBalance());
     
        }
        [Fact]
        public void OverdraftThrowsAnException() {
            Assert.Throws<InsufficientFundsException>(() => _acct.Withdraw(_openingBal + 1));
        }
    }
}
