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
        public AcctType AcctType = AcctType.Standard;
        public decimal GetBalance()
        {
            return _currentBal;
        }

        public void Deposit(decimal amountToDeposit)
        {
            if (AcctType == AcctType.Gold) {
                amountToDeposit *= 1.10M;
            }
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