using System;
using DeclarativeContracts.Exceptions;

namespace DeclarativeContracts
{
    public class Ensure
    {
        public static void That<TElement, TException>(Func<TElement> memberSelector, Predicate<TElement> predicate)
        {
            var member = memberSelector.Invoke();
            if (!predicate(member))
            {
                throw new ContractViolationException("Contact postcondition was violated. Expected that predicate returns true.");
            }
        }

        public static void That<TElement>(TElement element, Predicate<TElement> predicate, string exceptionText = "")
        {
            if (!predicate(element))
            {
                throw new ContractViolationException("Contact postcondition was violated. Expected that predicate returns true.");
            }
        }

        public static void That<TElement, TException>(TElement element, Predicate<TElement> predicate,
            TException exceptionToThrow) where TException : Exception, new()
        {
            if (!predicate(element))
            {
                throw exceptionToThrow;
            }
        }
    }
}