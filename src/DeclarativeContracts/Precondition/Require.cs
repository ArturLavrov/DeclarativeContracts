using System;
using System.Collections.Generic;
using System.Linq;
using DeclarativeContracts.Exceptions;

namespace DeclarativeContracts.Precondition
{
    public static class Require
    {
        public static void That<TEntity, TMember>(TEntity entity, Func<TEntity, TMember> entityMemberSelector, Predicate<TMember> predicate)
        {
            if (entity == null || entityMemberSelector == null || predicate == null)
            {
                throw new ArgumentException("entityMemberSelector could not be null.Please check the following doc how to properly use lib");
            }
            
            var member = entityMemberSelector(entity);
            InternalThat(member, predicate);
        }

        public static void That<TElement>(TElement element, Predicate<TElement> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentException("Predicate could not be null.Please check the following doc how to properly use lib");
            }

            InternalThat(element, predicate);
        }

        public static void That<TElement, TException>(TElement element, Predicate<TElement> predicate,
            TException exceptionToThrow) where TException : Exception, new()
        {
            if (predicate == null)
            {
                throw new ArgumentException("Predicate could not be null.Please check the following doc how to properly use lib");
            }
            
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
        
        public static void ForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentException("predicate could not be null.Please check the following doc how to properly use lib");
            }

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

        public static void TrueForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate)
        {
            if (elementsSequence.Any(element => !predicate(element)))
            {
                throw new ContractViolationException();
            }
        }
    }
}