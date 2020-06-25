using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class NewAccountTests
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance() {
            //brand new account
            var acct = new BankAccount(new DummyBonusCalc(), new Mock<INarcOnAccounts>().Object);
            //when balance is retrieved
            decimal balance = acct.GetBalance();
            //it has a balance of 5k
            Assert.Equal(5000M, balance);
        }
    }
}
