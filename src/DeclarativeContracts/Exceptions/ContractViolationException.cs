using System;

namespace DeclarativeContracts.Exceptions
{
    /// <summary>
    /// Excepiton that occurs when contract was violated.
    /// </summary>
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