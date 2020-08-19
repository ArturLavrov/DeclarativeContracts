using System;
using NUnit.Framework;
using Is = DeclarativeContracts.Functions.Is;

namespace DeclarativeContracts.Tests.Functions
{
    [TestFixture]
    public partial class IsTests
    {
        [Test]
        public void Null_NullValue_ReturnsTrue()
        {
            object nullObject = null;
            Assert.True(Is.Null(nullObject));
        }
        
        [Test]
        public void Null_NotNullValue_ReturnsFalse()
        {
            object nullObject = "a";
            Assert.False(Is.Null(nullObject));
        }

        [Test]
        public void NotNull_NotNullValue_ReturnsTrue()
        {
            object notNullObject = "a";
            Assert.True(Is.NotNull(notNullObject));
        }

        [Test]
        public void NotNull_NullValue_ReturnFalse()
        {
            object nullValie = null;
            Assert.False(Is.NotNull(nullValie));
        }
        
        [Test]
        public void Default_ZeroValue_ReturnsTrue()
        {
            int intValue = 0;
            Assert.True(Is.Default(intValue));
        }

        [Test]
        public void Default_IntValueGreaterThatZero_ReturnsFalse()
        {
            int intValue = 10;
            Assert.False(Is.Default(intValue));
        }
        
        [Test]
        public void NotDefault_ZeroValue_ReturnsTrue()
        {
            int intValue = 0;
            Assert.False(Is.NotDefault(intValue));
        }

        [Test]
        public void NotDefault_IntValueLessThatZero_ReturnsFalse()
        {
            int intValue = -1;
            Assert.False(Is.Default(intValue));
        }

        [Test]
        public void NotNullOrEmptyString_NotEmptyString_ReturnsTrue()
        {
            string notEmptyString = "not empty";
            Assert.True(Is.NotNullOrEmptyString(notEmptyString));
        }

        [Test]
        public void NotNullOrEmptyString_EmptyString_ReturnsFalse()
        {
            string notEmptyString = String.Empty;
            Assert.False(Is.NotNullOrEmptyString(notEmptyString));
        }

        [Test]
        public void True_True_ReturnsTrue()
        {
            Assert.True(Is.True(true));
        }
        
        [Test]
        public void True_False_ReturnsFalse()
        {
            Assert.True(Is.False(false));
        }
    }
}
