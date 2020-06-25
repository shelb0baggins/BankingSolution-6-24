using System;

namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateBonuses
    {
        decimal ICalculateBonuses.GetDepositBonusFor(decimal amountToDeposit, decimal currentBal)
        {
            if (currentBal >= 10000)
            {
                if (BeforeCutoff())
                {
                    return amountToDeposit * .1M;
                }
                else
                {
                    return amountToDeposit * .05M;
                }
            }
            else {
                return 0;
            }
        }

        protected virtual bool BeforeCutoff()
        {
            return DateTime.Now.Hour < 17;
        }
    }
}