using System;

namespace DeclarativeContracts.Exceptions
{
    public class ContractViolationException : Exception
    {
        public ContractViolationException()
        {
        }

        public ContractViolationException(string message) : base(message)
        {
        }

        public ContractViolationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}