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
            var acct = new GoldAccount();
            var openingBal = acct.GetBalance();

            acct.Deposit(100M);

            var expectedBal = 110M + openingBal;

            Assert.Equal(expectedBal, acct.GetBalance());
        }
    }
}
