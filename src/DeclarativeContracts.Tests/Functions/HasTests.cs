using System.Collections.Generic;
using System.Linq;
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
        public void AtLeastOneValue_ListWithNoValue_ReturnFalse()
        {
            List<string> listWithNoValues = new List<string>();
            Assert.False(Has.AtLeastOneValue(listWithNoValues));
        }

        [Test]
        public void AtLeastOneValue_Null_ReturnFalse()
        {
            List<string> nullList = null;
            Assert.False(Has.AtLeastOneValue(nullList));
        }

        [Test]
        public void AtLeastOneValue_ListWithFewValues_ReturnTrue()
        {
            List<string> listWithFewValues = new List<string>()
            {
                "a", "b", "c", "d"
            };
            Assert.True(Has.AtLeastOneValue(listWithFewValues));
        }
    }
}