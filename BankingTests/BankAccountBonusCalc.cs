using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountBonusCalc
    {
        [Fact]
        public void BonusCalcIsUsedProperly() {
            var fakeBonusCalculator = new Mock<ICalculateBonuses>();
            fakeBonusCalculator.Setup(m => m.GetDepositBonusFor(100, 5000)).Returns(42);
            var acct = new BankAccount(fakeBonusCalculator.Object, new Mock<INarcOnAccounts>().Object);
            acct.Deposit(100);
            Assert.Equal(5142, acct.GetBalance());
        }

    }
    public class StubbedBonusCalc : ICalculateBonuses
    {

        public decimal GetDepositBonusFor(decimal amountToDeposit, decimal currentBal)
        {
            //this should return random #  if the right amt and bal are passed
            if (amountToDeposit == 100 && currentBal == 5000)
            {
                return 42;
            }
            else {
                return -1;
            }
        }
    }
}
