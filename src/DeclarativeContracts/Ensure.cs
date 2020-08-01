using System;
using DeclarativeContracts.Exceptions;

namespace DeclarativeContracts
{
    /// <summary>
    /// Class that represent methods for performing preconditions
    /// </summary>
    public class Ensure
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberSelector">func that select specified member to check</param>
        /// <param name="predicate"Predicate that checks selected member></param>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static void That<TElement, TException>(Func<TElement> memberSelector, Predicate<TElement> predicate)
        {
            var member = memberSelector.Invoke();
            if (!predicate(member))
            {
                throw new ContractViolationException("Contact postcondition was violated. Expected that predicate returns true.");
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TElement"></typeparam>
        public static void That<TElement>(TElement element, Predicate<TElement> predicate)
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