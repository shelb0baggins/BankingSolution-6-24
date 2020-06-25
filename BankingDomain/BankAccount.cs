using System;
using System.Threading;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _currentBal = 5000;
        private ICalculateBonuses _bonusCalculator;
        private INarcOnAccounts _feds;

        public BankAccount(ICalculateBonuses bonusCalculator, INarcOnAccounts feds)
        {
            _bonusCalculator = bonusCalculator;
            _feds = feds;
        }

        public decimal GetBalance()
        {
            return _currentBal;
        }

        public void Deposit(decimal amountToDeposit)
        {
            //the amt to deposit
            //current bal
            decimal amountOfBonus = _bonusCalculator.GetDepositBonusFor(amountToDeposit, _currentBal);
            _currentBal += amountToDeposit + amountOfBonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= _currentBal)
            {
                _feds.NotifyOfWithdrawal(this, amountToWithdraw);
                _currentBal -= amountToWithdraw;
            }
            else {
                throw new InsufficientFundsException();
            }
            
        }
    }
}