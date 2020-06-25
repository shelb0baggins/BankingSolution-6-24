using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingTests
{
    public class DummyBonusCalc : ICalculateBonuses
    {
        public decimal GetDepositBonusFor(decimal amountToDeposit, decimal currentBal)
        {
            return 0;
        }
    }
}
