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
            bool predicateResult;
            
            try
            {
                var member = entityMemberSelector.Invoke(entity);
                predicateResult =  predicate.Invoke(member);
            }
            catch(Exception ex)
            {
                throw new ContractViolationException(
                    "Exception occured during predicate execution.See inner exception for details", 
                    ex);
            }

            if(!predicateResult)
            {
                throw new ContractViolationException("Contact precondition was violated. Expected that predicate returns true.");
            }
        }

        public static void That<TElement>(TElement element, Predicate<TElement> predicate)
        {
           bool predicateResult;
           
           try{
               predicateResult =  predicate.Invoke(element);
           }
           catch(Exception ex)
           {
               throw new ContractViolationException(
                   "Exception occured during predicate execution.See inner exception for details", 
                   ex);
           }

           if(!predicateResult)
           {
               throw new ContractViolationException("Contact precondition was violated. Expected that predicate returns true.");
           }
        }

        public static void That<TElement, TException>(TElement element, Predicate<TElement> predicate,
            TException exceptionToThrow) where TException : Exception, new()
        {
            bool predicateResult;
           
            try
            {
                predicateResult =  predicate.Invoke(element);
            }
            catch(Exception ex)
            {
                throw new ContractViolationException(
                    "Exception occured during predicate execution.See inner exception for details", ex);
            }

            if(!predicateResult)
            {
                throw exceptionToThrow;
            }
        }
        
        public static void ForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate)
        {
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