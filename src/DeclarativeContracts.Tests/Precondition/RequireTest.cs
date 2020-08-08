using System;
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
                            customer => customer.Name, 
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
                        customer => customer.Name, 
                        (name) => name != null
                    )
                );
        }
        
        [Test]
        public void That_EntityToChekcIsNull_ContractViolationExceptionIsThrows()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };

            customer = null;

            Assert.Throws(
                    typeof(ArgumentException),
                    () => Require.That(
                        customer, 
                        customer => customer.Name, 
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
                    customer => customer.Name, 
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
                customer => customer.Name, 
                null)
            );
        }
    }

    internal class Customer
    {
        public string Name {get;set;}
        public string LastName {get;set;}

        public DateTime DateOfBirth {get;set;}

        public List<String> FavoritePharses {get;set;}
    }
}