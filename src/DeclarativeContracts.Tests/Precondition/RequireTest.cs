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
        public void ForAll_ListWith3ElementsOneIsLessThanZero_ThrowsContractViolationExceptionWithCustomErrorMessage()
        {
            List<int> elementsCollection = new List<int>
            {
                -1,3,4
            };

            string contractViolationMessage = "contract was violated, custom message";
            
            Assert.Throws(
                typeof(ContractViolationException),
                () => Require.ForAll(
                    elementsCollection,
                    ((element) => element > 0),
                    contractViolationMessage
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
        
        [Test]
        public void That_TrueForAllElements_ReturnTrue()
        {
           var collection = new List<string>(){ "Hello", "World"};
            Assert.DoesNotThrow(() => Require.TrueForAll(collection, (item) => item.Length > 2));
        }

        [Test]
        public void That_FalseForOneElementFromCollection_ContractViolationExceptionWasThrown()
        {
            var collection = new List<string>(){ "o", "World"};
            Assert.Throws(typeof(ContractViolationException), () => Require.TrueForAll(collection, (item) => item.Length > 2));
        }
        
        [Test]
        public void That_FalseForOneElementFromCollection_ContractViolationExceptionWasThrownWithCustomErrorMessage()
        {
            var collection = new List<string>(){ "o", "World"};

            string contractViolationMessage = "contract was violated, custom message";
            
            Assert.Throws(
                typeof(ContractViolationException), 
                () => Require.TrueForAll(collection, (item) => item.Length > 2),
                contractViolationMessage
            );
        }

        [Test]
        public void That_PredicateForApplyIsNull_ArgumentExceptionWasThrown()
        {
            var collection = new List<string>(){ "o", "World"};
            Assert.Throws(typeof(ArgumentException), () => Require.TrueForAll(collection, null));
        }
        
        [Test]
        public void That_FuncThatReturnsTrue_ContractViolationExceptionDoesNotThrows()
        {
            Func<bool> functor = () => true;

            Assert.DoesNotThrow(() => Require.That(functor));
        }

        [Test]
        public void That_FuncThatReturnsFalse_ContractViolationExceptionWasThrown()
        {
            Func<bool> functor = () => false;

            Assert.Throws(typeof(ContractViolationException), () => Require.That(functor));
        }
        
        [Test]
        public void That_FuncThatReturnsFalse_ContractViolationExceptionWasThrownWithCustomUserDefinedMessage()
        {
            Func<bool> functor = () => false;

            string contractViolationCustomMessage = "functor return false";

            Assert.Throws(typeof(ContractViolationException), () => Require.That(functor, contractViolationCustomMessage), contractViolationCustomMessage);
        }

        [Test]
        public void That_FuncIsNull_ArgumentExceptionWasThrown()
        {
            Func<bool> functor = null;

            Assert.Throws(typeof(ArgumentException), () => Require.That(functor));
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