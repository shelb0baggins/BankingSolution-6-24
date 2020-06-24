using System;

namespace BankingDomain
{
    public enum AcctType
    {
        Standard, Gold
    }
    public class BankAccount
    {
        
        private decimal _currentBal = 5000;
        
        public decimal GetBalance()
        {
            return _currentBal;
        }

        public virtual void Deposit(decimal amountToDeposit)
        {
            _currentBal += amountToDeposit;
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