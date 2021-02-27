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
    public static partial class Require
    {
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

            InternalForAll(elementsSequence, predicate);
        }

        /// <summary>
        /// Methods that checks whether all members of input sequence satisfy the predicate
        /// </summary>
        /// <param name="elementsSequence">Input sequence of elements</param>
        /// <param name="predicate">Predicate that tests every element of sequence</param>
        /// <param name="contractViolationMessage">Custom text that will be throw as an exception text</param>
        /// <typeparam name="TElement">Element type</typeparam>
        /// <exception cref="ContractViolationException"></exception>
        /// <throws>Throws ContractViolationException if element does not satisfy predicate</throws>
        public static void ForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate, string contractViolationMessage)
        {
            ArgumentChecker.CheckArgumentsNull(predicate);

            InternalForAll(elementsSequence, predicate, contractViolationMessage);
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
            ArgumentChecker.CheckArgumentsNull(predicate);

            if (elementsSequence.Any(element => !predicate(element)))
            {
                throw new ContractViolationException();
            }
        }

        /// <summary>
        /// Methods that checks whether predicate is true for all member of input sequence
        /// </summary>
        /// <param name="elementsSequence">Input sequence of elements</param>
        /// <param name="predicate">Predicate that tests every element of sequence</param>
        /// <param name="contractViolationMessage">Custom text that will be throw as an exception text</param>
        /// <typeparam name="TElement">Element type</typeparam>
        /// <exception cref="ContractViolationException"></exception>
        /// <throws>Throws ContractViolationException if element does not satisfy predicate</throws>
        public static void TrueForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate, string contractViolationMessage)
        {
            ArgumentChecker.CheckArgumentsNull(predicate);

            if (elementsSequence.Any(element => !predicate(element)))
            {
                throw new ContractViolationException(contractViolationMessage);
            }
        }

        private static void InternalForAll<TElement>(IEnumerable<TElement> elementsSequence, Predicate<TElement> predicate, string contractViolationMessage = null)
        {
            try
            {
                foreach (var element in elementsSequence)
                {
                    if(!predicate(element))
                    {
                        throw new ContractViolationException(contractViolationMessage ?? $"Contact was violated.Predicate for element {element} return false.");
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ContractViolationException(contractViolationMessage ?? "Contact was violated because an unhandled exception occured.", ex);
            }
        }

        public static void InternalTrueForAll<TElement>(IEnumerable<TElement> elementsSequence,
            Predicate<TElement> predicate, string contractViolationMessage)
        {
            if (elementsSequence.Any(element => !predicate(element)))
            {
                throw new ContractViolationException(contractViolationMessage ?? "default message");
            }
        }
    }
}