using System;
using DeclarativeContracts.Exceptions;
using DeclarativeContracts.Postcondition;
using DeclarativeContracts.Tests.Precondition;
using NUnit.Framework;

namespace DeclarativeContracts.Tests.Postcondition
{
    [TestFixture]
    public class EnsureTests
    {
         [Test]
        public void Ensure_ValidArgumentsAndContractNotViolated_ContractViolationExceptionDoesNotThrows()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };

            Assert.DoesNotThrow
            (
                () => Ensure.That(
                        customer, 
                        customer => customer.Name, 
                        (name) => name != null
                    )
            );
        }

        [Test]
        public void Ensure_ValidArgumentsAndContractViolated_ContractViolationExceptionThrows()
        {
            var customer = new Customer()
            {
                Name = null,
                LastName = "Osbourne"
            };

            Assert.Throws
            (
                typeof(ContractViolationException),
                () => Ensure.That(
                    customer, 
                    customer => customer.Name, 
                    (name) => name != null
                )
            );
        }
       
        [Test]
        public void Ensure_ValidArguemntsStringIsNotNull_ContractViolationExceptionDoesNotThrows()
        {
            Assert.DoesNotThrow(() => Ensure.That<String>("string", (item) => item.Length == 6));
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
                () => Ensure.That(customer.Name, n => n.Length > 5, new ArgumentException()));
        }

        [Test]
        public void That_EntityIsNotNullPredicateIsNull_ThrowsArgumentException()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };

            Assert.Throws(typeof(ArgumentException), () => Ensure.That(customer, (c) => c.Name,  null));
        }
        
        [Test]
        public void That_PredicateIsNull_ThrowsArgumentException()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };

            Assert.Throws(typeof(ArgumentException), () => Ensure.That(customer, null));
        }

        [Test]
        public void That_PredicateRetursFalse_ThrowsContractViolationException()
        {
            var customer = new Customer()
            {
                Name = "Ozzy",
                LastName = "Osbourne"
            };

            Assert.Throws(typeof(ContractViolationException), () => Ensure.That(customer.Name, (name) => name.Length > 10));
        }
    }
}