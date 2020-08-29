﻿using System;
using NUnit.Framework;
using System.Collections.Generic;
using DeclarativeContracts.Precondition;
using DeclarativeContracts.Exceptions;

namespace DeclarativeContracts.Tests.Precondition
{
    [TestFixture]
    public class RequireTest
    {
        [Test]
        public void That_ValidArguemntsAndContractNotViolated_ContractViolationExceptionDoesNotThrows()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };

            Assert.DoesNotThrow
                (
                    () => Require.That(
                            customer, 
                            с => с.Name, 
                            (name) => name != null
                        )
                );
        }

        [Test]
        public void That_ValidArguemntsAndContractViolated_ContractViolationExceptionThrows()
        {
            var customer = new Customer()
            {
                Name = null,
                LastName = "Osbourne"
            };

            Assert.Throws(
                    typeof(ContractViolationException),
                    () => Require.That(
                        customer, 
                        с => с.Name, 
                        (name) => name != null
                    )
                );
        }

        [Test]
        public void That_CustomerNameSelectorIsNullPredicateNotNull_ArgumentExceptionThrows()
        {
            var customer = new Customer()
            {
                Name = null,
                LastName = "Osbourne"
            };

            Assert.Throws(
                typeof(ContractViolationException), 
                    () =>  Require.That(
                    customer, 
                    с => с.Name, 
                    (name) => name.StartsWith("O")
                )
            );
        }

        [Test]
        public void That_CustomerNameSelectorIsNotNullPredicateIsNull_ArgumentExceptionThrows()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };

            Assert.Throws(
                typeof(ArgumentException), 
                () =>  Require.That(
                customer, 
                с => с.Name, 
                null)
            );
        }

        [Test]
        public void That_ElementIsNotNullPredicateNull_ContractViolationException()
        {
            Assert.Throws(typeof(ArgumentException), () => Require.That("string", null));
        }

        [Test]
        public void That_ValidArguemntsStringIsNotNull_ContractViolationExceptionDoesNotThrows()
        {
            Assert.DoesNotThrow(() => Require.That<String>("string", (item) => item.Length == 6));
        }
        
        [Test]
        public void That_ValidArgumentsPredicateThowAnException_ThrowsContractViolationException()
        {
            Assert.Throws(
                typeof(ContractViolationException),
                () => Require.That<String>(
                    "element",
                    (item) => {
                        throw new Exception("Predicate Exception");
                    }
                )
            );
        }

        [Test]
        public void ForAll_ListWithAllElementGreaterThanZero_ContractViolationExceptionDoesNotThrows()
        {
            List<int> elementsCollection = new List<int>
            {
                1,3,4
            };

            Assert.DoesNotThrow(() => Require.ForAll(elementsCollection, (element) => element > 0));
        }

        [Test]
        public void ForAll_ListWith3ElementsOneIsLessThanZero_ThrowsContractViolationException()
        {
            List<int> elementsCollection = new List<int>
            {
                -1,3,4
            };

            Assert.Throws(
                typeof(ContractViolationException),
                () => Require.ForAll(
                    elementsCollection,
                    ((element) => element > 0)
                )
            );
        }

        [Test]
        public void That_ContractViolatedPassCustomException_CustomExceptionWasThrows()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };
            
            Assert.Throws(
                typeof(ArgumentException), 
                () => Require.That(customer.Name, n => n.Length > 5, new ArgumentException()));
        }
    }

    internal class Customer
    {
        public string Name {get;set;}
        public string LastName {get;set;}

        public DateTime DateOfBirth {get;set;}

        public List<String> FavoritePhrases {get;set;}
    }
}