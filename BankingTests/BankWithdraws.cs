using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankWithdraws
    {
        [Theory]
        [InlineData(100)]
        public void WithdrawMoneyDecreaseBalance(decimal amountToWithdraw) {
            var acct = new BankAccount();
            var openingBal = acct.GetBalance();

            acct.Withdraw(amountToWithdraw);

            var expectedBal = openingBal - amountToWithdraw;
            Assert.Equal(expectedBal, acct.GetBalance());
        }

    }
}
