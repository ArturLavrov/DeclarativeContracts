using NUnit.Framework;
using Is = DeclarativeContracts.Functions.Is;

namespace DeclarativeContracts.Tests.Functions
{
    public partial class IsTests
    {
        [Test]
        public void IsPositive_NotNegativeInteger_ReturnsTrue()
        {
            int notNegativeInteger = 123;
            Assert.True(Is.Positive(notNegativeInteger));
        }

        [Test]
        public void IsPositive_NegativeInteger_ReturnFalse()
        {
            int negativeInteger = -1;
            Assert.False(Is.Positive(negativeInteger));
        }
        
        [Test]
        public void IsPositive_IntegerZero_ReturnFalse()
        {
            int zero = 0;
            Assert.False(Is.Positive(zero));
        }
        

        [Test]
        public void IsPositive_NotNegativeShort_ReturnsTrue()
        {
            short notNegativeInteger = 100;
            Assert.True(Is.Positive(notNegativeInteger));
        }

        [Test]
        public void IsPositive_NegativeShort_ReturnFalse()
        {
            short negativeInteger = -1;
            Assert.False(Is.Positive(negativeInteger));
        }

        [Test]
        public void IsPositive_ShortZero_ReturnFalse()
        {
            short zero = 0;
            Assert.False(Is.Positive(zero));
        }


        [Test]
        public void IsNegative_NegativeInteger_ReturnsTrue()
        {
            int notNegativeInteger = -1123;
            Assert.True(Is.Negative(notNegativeInteger));
        }

        [Test]
        public void IsNegative_NonNegativeInteger_ReturnsFalse()
        {
            int negativeInteger = 1;
            Assert.False(Is.Negative(negativeInteger));
        }

        [Test]
        public void IsOdd_OddNunber_ReturnTrue()
        {
            int oddNumber = 11;
            Assert.True(Is.Odd(oddNumber));
        }

        [Test]
        public void IsEven_EvenNumebr_ReturnTrue()
        {
            int evenNumber = 10;
            Assert.That(Is.Even(evenNumber));
        }

        [Test]
        public void IsEven_Zero_ReturnTrue()
        {
            int zero = 0;
            Assert.True(Is.Even(zero));
        }

        [Test]
        [TestCase(2)]
        [TestCase(32)]
        [TestCase(1024)]
        [TestCase(16384)]
        public void IsPowerOfTwo_PowerOfTwoShortNumber_ReturnTrue(short testNumber)
        {
            Assert.True(Is.PowerOfTwo(testNumber));
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(2354)]
        [TestCase(11534)]
        public void IsPowerOfTwo_NotPowerOfTwoShortNumber_ReturnTrue(short testNumber)
        {
            Assert.False(Is.PowerOfTwo(testNumber));
        }

        [Test]
        [TestCase(2)]
        [TestCase(32)]
        [TestCase(1024)]
        [TestCase(16384)]
        public void IsPowerOfTwo_PowerOfTwoIntNumber_ReturnTrue(int testNumber)
        {
            Assert.True(Is.PowerOfTwo(testNumber));
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(2354)]
        [TestCase(11534)]
        public void IsPowerOfTwo_NotPowerOfTwoIntNumber_ReturnTrue(int testNumber)
        {
            Assert.False(Is.PowerOfTwo(testNumber));
        }

        [Test]
        [TestCase(2)]
        [TestCase(32)]
        [TestCase(1024)]
        [TestCase(16384)]
        public void IsPowerOfTwo_PowerOfTwoLongNumber_ReturnTrue(long testNumber)
        {
            Assert.True(Is.PowerOfTwo(testNumber));
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(2354)]
        [TestCase(11534)]
        public void IsPowerOfTwo_NotPowerOfTwoLongNumber_ReturnTrue(long testNumber)
        {
            Assert.False(Is.PowerOfTwo(testNumber));
        }
    }
}
