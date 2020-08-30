using System.Collections.Generic;
using NUnit.Framework;
using Has = DeclarativeContracts.Functions.Has;

namespace DeclarativeContracts.Tests.Functions
{
    [TestFixture]
    public class HasTests
    {
        [Test]
        public void AtLeastOneValue_ListWithOneValue_ReturnsTrue()
        {
            List<string> listWithOneValue = new List<string>(){"a"};
            Assert.True(Has.AtLeastOneValue(listWithOneValue));
        }

        [Test]
        public void AtLeastOneValue_ListWithNoValue_ReturnsFalse()
        {
            List<string> listWithNoValues = new List<string>();
            Assert.False(Has.AtLeastOneValue(listWithNoValues));
        }

        [Test]
        public void AtLeastOneValue_Null_ReturnsFalse()
        {
            List<string> nullList = null;
            Assert.False(Has.AtLeastOneValue(nullList));
        }

        [Test]
        public void AtLeastOneValue_ListWithFewValues_ReturnsTrue()
        {
            List<string> listWithFewValues = new List<string>()
            {
                "a", "b", "c", "d"
            };
            Assert.True(Has.AtLeastOneValue(listWithFewValues));
        }

        [Test]
        public void OnlyOneValue_ListWithOneValue_ReturnsTrue()
        {
            List<string> listWithOneValue = new List<string>()
            {
                "a"
            };
            
            Assert.True(Has.OnlyOneValue(listWithOneValue));
        }

        [Test]
        public void OnlyOneValue_ListWithFewValues_ReturnsTrue()
        {
            List<string> listWithFewValues = new List<string>()
            {
                "a", "b", "c", "d"
            };
            Assert.False(Has.OnlyOneValue(listWithFewValues));
        }

        [Test]
        public void OnlyOneValue_Null_ReturnsFalse()
        {
            List<string> nullList = null;
            Assert.False(Has.OnlyOneValue(nullList));
        }

        [Test]
        public void OnlyOneValue_EmptySequence_ReturnFalse()
        {
            List<string> emptyList = new List<string>();
            Assert.False(Has.OnlyOneValue(emptyList));
        }
    }
}