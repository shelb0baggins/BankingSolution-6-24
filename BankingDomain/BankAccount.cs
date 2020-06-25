using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _currentBal = 5000;
        private ICalculateBonuses _bonusCalculator;

        public BankAccount(ICalculateBonuses bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
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
                _currentBal -= amountToWithdraw;
            }
            else {
                throw new InsufficientFundsException();
            }
            
        }
    }
}