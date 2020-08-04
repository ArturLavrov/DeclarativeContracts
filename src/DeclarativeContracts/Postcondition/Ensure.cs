using System;
using DeclarativeContracts.Exceptions;

namespace DeclarativeContracts.Postcondition
{
    /// <summary>
    /// Class that represent methods for performing postcondition checking
    /// </summary>
    public class Ensure
    {
        /// <summary>
        /// Verified that selected member satisfied specified predicate
        /// </summary>
        /// <param name="memberSelector">Func that select specified member to check</param>
        /// <param name="predicate">Predicate that checks selected member</param>
        /// <typeparam name="TElement">Element type to check</typeparam>
        /// <typeparam name="TException">Exception type to throw</typeparam>
        /// <returns></returns>
        public static void That<TElement>(Func<TElement> memberSelector, Predicate<TElement> predicate)
        {
            var member = memberSelector.Invoke();
            if (!predicate(member))
            {
                throw new ContractViolationException("Contact postcondition was violated. Expected that predicate returns true.");
            }
        }
        
        /// <summary>
        /// Verify that verify element satisfied specified predicate
        /// </summary>
        /// <param name="element">Element that needs to be checked</param>
        /// <param name="predicate">Predicate that checks selected member</param>
        /// <typeparam name="TElement">Element type to check</typeparam>
        public static void That<TElement>(TElement element, Predicate<TElement> predicate)
        {
            if (!predicate(element))
            {
                throw new ContractViolationException("Contact postcondition was violated. Expected that predicate returns true.");
            }
        }

        /// <summary>
        ///Verify that element satisfied specified predicate, and throw passed exception.
        /// </summary>
        /// <param name="element">Element that needs to be checked</param>
        /// <param name="predicate">Predicate that checks selected member</param>
        /// <param name="exceptionToThrow">Exception to throw if contract violated</param>
        /// <typeparam name="TElement">Element type to check</typeparam>
        /// <typeparam name="TException">Exception type to throw</typeparam>
        /// <returns></returns>
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