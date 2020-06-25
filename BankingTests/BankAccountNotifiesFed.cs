using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountNotifiesFed
    {
        [Fact]
        public void NotifiedOnWithdrawal() {
            var mockFed = new Mock<INarcOnAccounts>();
            var acct = new BankAccount(new Mock<ICalculateBonuses>().Object, mockFed.Object);

            acct.Withdraw(108);

            //fed is then notified
            mockFed.Verify(m => m.NotifyOfWithdrawal(acct, 108));
        }
    }
}
