using System;
using System.Collections.Generic;
using System.Linq;
using DeclarativeContracts.Exceptions;
using DeclarativeContracts.Utilities;

namespace DeclarativeContracts.Precondition
{
    /// <summary>
    /// Class that represent general precondition for method arguments
    /// </summary>
    public static class Require
    {
        /// <summary>
        /// Method that verify that entity member satisfy passed predicate
        /// </summary>
        /// <param name="entity">Entity that contains verifiable member</param>
        /// <param name="entityMemberSelector">Func that returns entity member that needs to be checked</param>
        /// <param name="predicate">Predicate that check is entity member satisfy a condition</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <typeparam name="TMember">Entity member type</typeparam>
        /// <throws>Throws ContractViolationException if element does not satisfy predicate</throws>
        /// <throws>Throws ArgumentException if element does not satisfy predicate</throws>
        public static void That<TEntity, TMember>(TEntity entity, Func<TEntity, TMember> entityMemberSelector, Predicate<TMember> predicate)
        {
            ArgumentChecker.CheckArgumentsNull(entity, entityMemberSelector, predicate);
            
            var member = entityMemberSelector(entity);
            InternalThat(member, predicate);
        }

        /// <summary>
        /// Method that verify that entity member satisfy passed predicate
        /// </summary>
        /// <param name="element">Element that needs to be checked</param>
        /// <param name="predicate">Predicated that checks member</param>
        /// <typeparam name="TElement">Element type</typeparam>
        /// <throws>Throws ContractViolationException if element does not satisfy predicate</throws>
        /// <throws>Throws ArgumentException if element does not satisfy predicate</throws>
        public static void That<TElement>(TElement element, Predicate<TElement> predicate)
        {
            ArgumentChecker.CheckArgumentsNull(element, predicate);

            InternalThat(element, predicate);
        }

        /// <summary>
        /// Method that verify that entity member satisfy passed predicate
        /// </summary>
        /// <param name="element">Element that needs to be checked</param>
        /// <param name="predicate">Predicated that checks member</param>
        /// <param name="exceptionToThrow">Custom exception to throw instead of contract violation exception</param>
        /// <typeparam name="TElement">Element type</typeparam>
        /// <typeparam name="TException">Exception type</typeparam>
        public static void That<TElement, TException>(TElement element, Predicate<TElement> predicate,
            TException exceptionToThrow) where TException : Exception, new()
        {
            ArgumentChecker.CheckArgumentsNull(element, predicate);
            
            InternalThat(element, predicate, exceptionToThrow);
        }
        
        
        private static void InternalThat<TMember>(TMember member, Predicate<TMember> predicate, Exception exceptionToThrow = null)
        {
            bool predicateResult;
            
            try
            {
                predicateResult =  predicate.Invoke(member);
            }
            catch(Exception ex)
            {
                throw exceptionToThrow ?? 
                      new ContractViolationException(
                          "Exception occured during predicate execution.See inner exception for details", ex);
            }

            if(!predicateResult)
            {
                throw exceptionToThrow ?? 
                      new ContractViolationException(
                          "Contact precondition was violated. Expected that predicate returns true.");
            }
        }
        
        /// <summary>
        /// Methods that checks whether all members of input sequence satisfy the predicate
        /// </summary>
        /// <param name="elementsSequence">Input sequence of elements</param>
        /// <param name="predicate">Predicate that tests every element of sequence</param>
        /// <typeparam name="TElement">Element type</typeparam>
        /// <exception cref="ContractViolationException"></exception>
        /// <throws>Throws ContractViolationException if element does not satisfy predicate</throws>
        public static void ForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate)
        {
            ArgumentChecker.CheckArgumentsNull(predicate);

            try
            {
                foreach (var element in elementsSequence)
                {
                    if(!predicate(element))
                    {
                        throw new ContractViolationException($"Contact was violated.Predicate for element {element} return false.");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ContractViolationException("Contact was violated because an unhandled exception occured.", ex);
            }
        }

        /// <summary>
        /// Methods that checks whether predicate is true for all member of input sequence
        /// </summary>
        /// <param name="elementsSequence">Input sequence of elements</param>
        /// <param name="predicate">Predicate that tests every element of sequence</param>
        /// <typeparam name="TElement">Element type</typeparam>
        /// <exception cref="ContractViolationException"></exception>
        /// <throws>Throws ContractViolationException if element does not satisfy predicate</throws>
        public static void TrueForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate)
        {
            if (elementsSequence.Any(element => !predicate(element)))
            {
                throw new ContractViolationException();
            }
        }
    }
}