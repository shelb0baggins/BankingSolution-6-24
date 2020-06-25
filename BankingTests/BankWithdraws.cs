using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankWithdraws
    {
        private BankAccount _acct;
        private decimal _openingBal;

        public BankWithdraws()
        {
            _acct = new BankAccount(new DummyBonusCalc(), new Mock<INarcOnAccounts>().Object);
            _openingBal = _acct.GetBalance();
        }

        [Theory]
        [InlineData(100)]
        public void WithdrawMoneyDecreaseBalance(decimal amountToWithdraw) {
            _acct.Withdraw(amountToWithdraw);

            var expectedBal = _openingBal - amountToWithdraw;
            Assert.Equal(expectedBal, _acct.GetBalance());
        }

        [Fact]
        public void YouCanTakeItAll()
        {
            _acct.Withdraw(_openingBal);
            Assert.Equal(0, _acct.GetBalance());
        }
    }
}
