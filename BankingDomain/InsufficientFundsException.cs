﻿using System;
using System.Runtime.Serialization;

namespace BankingDomain
{
    [Serializable]
    public class InsufficientFundsException : ArgumentOutOfRangeException
    {
        
    }
}