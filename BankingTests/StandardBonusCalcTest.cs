using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalcTest 
    {
        [Theory]
        [InlineData(100,9999, 0)]
        [InlineData(100, 10000, 10)]
        public void CanCalculateBonusesBeforeCutoff(decimal deposit, decimal balance, decimal expectedBal) {
            ICalculateBonuses bonusCalculator = new StandardBonusCalculator();
            var bonus = bonusCalculator.GetDepositBonusFor(deposit, balance);

            Assert.Equal(expectedBal, bonus);
        }
        [Theory]
        [InlineData(100, 9999, 0)]
        [InlineData(100, 10000, 5)]
        public void CanCalculateBonusesAfterCutoff(decimal deposit, decimal balance, decimal expectedBal)
        {
            ICalculateBonuses bonusCalculator = new TestStandingBonusCalc(true);
            var bonus = bonusCalculator.GetDepositBonusFor(deposit, balance);

            Assert.Equal(expectedBal, bonus);
        }
    }
    public class TestStandingBonusCalc : StandardBonusCalculator
    {
        private bool isBeforeCutOff;
        public TestStandingBonusCalc(bool isBeforeCutOff)
        {
            this.isBeforeCutOff = isBeforeCutOff;
        }
        protected virtual bool BeforeCutOff() { 
            return isBeforeCutOff;
        }
    }
}
