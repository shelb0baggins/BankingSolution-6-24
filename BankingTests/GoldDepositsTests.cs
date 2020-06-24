using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldDepositsTests
    {

        [Fact]
        public void GoldAccountsGetABonus() {
            var goldAcct = new BankAccount();
            var openingBal = goldAcct.GetBalance();

            var amountToDeposit = 100M;
            goldAcct.AcctType = AcctType.Gold;

            goldAcct.Deposit(amountToDeposit);

            var expectedBal = (amountToDeposit * 1.10M) + openingBal;

            Assert.Equal(expectedBal, goldAcct.GetBalance());
        }
    }
}
