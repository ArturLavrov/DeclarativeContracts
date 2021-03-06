using System;
using DeclarativeContracts.Exceptions;
using DeclarativeContracts.Utilities;

namespace DeclarativeContracts.Postcondition
{
    /// <summary>
    /// Class that represent methods for performing postcondition checking
    /// </summary>
    public class Ensure
    {
        /// <summary>
        ///  Method that verify element satisfied specified predicate
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="memberSelector"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TMember"></typeparam>
        /// <returns></returns>
        public static void That<TEntity, TMember>(TEntity entity, Func<TEntity, TMember> memberSelector, Predicate<TMember> predicate)
        {
            ArgumentChecker.CheckArgumentsNull(memberSelector, predicate);

            var member = memberSelector.Invoke(entity);
            if (!predicate(member))
            {
                throw new ContractViolationException("Contact postcondition was violated. Expected that predicate returns true.");
            }
        }

        /// <summary>
        ///  Method that verify element satisfied specified predicate
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="memberSelector"></param>
        /// <param name="predicate"></param>
        /// <param name="contractViolationMsg">Custom text that will be throw as an exception text</param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TMember"></typeparam>
        /// <returns></returns>
        public static void That<TEntity, TMember>(TEntity entity, Func<TEntity, TMember> memberSelector, Predicate<TMember> predicate, string contractViolationMsg)
        {
            ArgumentChecker.CheckArgumentsNull(memberSelector, predicate);

            var member = memberSelector.Invoke(entity);
            if (!predicate(member))
            {
                throw new ContractViolationException(contractViolationMsg);
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
            ArgumentChecker.CheckArgumentsNull(predicate, predicate);

            if (!predicate(element))
            {
                throw new ContractViolationException("Contact postcondition was violated. Expected that predicate returns true.");
            }
        }

        /// <summary>
        /// Verify that verify element satisfied specified predicate
        /// </summary>
        /// <param name="element">Element that needs to be checked</param>
        /// <param name="predicate">Predicate that checks selected member</param>
        /// <param name="contractViolationMessage">Custom text that will be throw as an exception text</param>
        /// <typeparam name="TElement">Element type to check</typeparam>
        public static void That<TElement>(TElement element, Predicate<TElement> predicate, string contractViolationMessage)
        {
            ArgumentChecker.CheckArgumentsNull(predicate, predicate);

            if (!predicate(element))
            {
                throw new ContractViolationException(contractViolationMessage);
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
            ArgumentChecker.CheckArgumentsNull(predicate, exceptionToThrow);
            
            if (!predicate(element))
            {
                throw exceptionToThrow;
            }
        }
    }
}