using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountDeposits
    {
        [Fact]
        public void DeposityingMoneyIncreasesBalances() {
            var acct = new BankAccount(new DummyBonusCalc(), new Mock<INarcOnAccounts>().Object);
            var openingBal = acct.GetBalance();
            var amountToDeposit = 1M;

            acct.Deposit(amountToDeposit);

            var expectedBal = openingBal + amountToDeposit;
            Assert.Equal(expectedBal, acct.GetBalance());


        }
    }
}
