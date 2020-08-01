using System;
using System.Collections.Generic;
using System.Linq;
using DeclarativeContracts.Exceptions;

namespace DeclarativeContracts
{
    public static class Require
    {
        public static void That<TElement, TException>(Func<TElement> memberSelector, Predicate<TElement> predicate)
        {
            var member = memberSelector.Invoke();
            if (!predicate(member))
            {
                throw new ContractViolationException("Contact precondition was violated. Expected that predicate returns true.");
            }
        }

        public static void That<TElement>(TElement element, Predicate<TElement> predicate, string exceptionText = "")
        {
            if (!predicate(element))
            {
                throw new ContractViolationException("Contact precondition was violated. Expected that predicate returns true.");
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
        
        public static void That(Func<bool> func)
        {
            try
            { 
                func.Invoke();
            }
            catch (Exception exception)
            {
                throw new ContractViolationException(
                    "Contract was violated. Functor throw an exception instead returning true.",
                    innerException: exception);
            }

        }
        
        public static void ForAll<TElement>(IEnumerable<TElement> elementsSequence, Action<TElement> actionToCall)
        {
            foreach (var element in elementsSequence)
            {
                actionToCall(element);
            }
        }

        public static void TrueForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate)
        {
            if (elementsSequence.Any(element => !predicate(element)))
            {
                throw new ContractViolationException();
            }
        }
    }
}