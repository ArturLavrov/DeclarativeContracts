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
        public void IsPositive_NotNegativeLong_ReturnsTrue()
        {
            long notNegativeLong = 100;
            Assert.True(Is.Positive(notNegativeLong));
        }

        [Test]
        public void IsPositive_NegativeLong_ReturnFalse()
        {
            long negativeLong = -1;
            Assert.False(Is.Positive(negativeLong));
        }

        [Test]
        public void IsPositive_LongZero_ReturnFalse()
        {
            long zero = 0;
            Assert.False(Is.Positive(zero));
        }


        [Test]
        public void IsPositive_NotNegativeFloat_ReturnsTrue()
        {
            float notNegativeFloat = 100.99999f;
            Assert.True(Is.Positive(notNegativeFloat));
        }

        [Test]
        public void IsPositive_NegativeFloat_ReturnFalse()
        {
            float negativeFloat = -1.1111f;
            Assert.False(Is.Positive(negativeFloat));
        }

        [Test]
        public void IsPositive_FloatZero_ReturnFalse()
        {
            float zero = 0.0f;
            Assert.False(Is.Positive(zero));
        }

        [Test]
        public void IsPositive_NotNegativeDouble_ReturnsTrue()
        {
            double notNegativeFloat = 12.3;
            Assert.True(Is.Positive(notNegativeFloat));
        }

        [Test]
        public void IsPositive_NegativeDouble_ReturnFalse()
        {
            double negativeFloat = -12.3;
            Assert.False(Is.Positive(negativeFloat));
        }

        [Test]
        public void IsPositive_DoubleZero_ReturnFalse()
        {
            double zero = 0;
            Assert.False(Is.Positive(zero));
        }


        [Test]
        public void IsPositive_NotNegativeDecimal_ReturnsTrue()
        {
            decimal notNegativeFloat = 12.3m;
            Assert.True(Is.Positive(notNegativeFloat));
        }

        [Test]
        public void IsPositive_NegativeDecimal_ReturnFalse()
        {
            decimal negativeFloat = -12.3m;
            Assert.False(Is.Positive(negativeFloat));
        }

        [Test]
        public void IsPositive_DecimalZero_ReturnFalse()
        {
            decimal zero = 0m;
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
        public void IsNegative_IntegerZero_ReturnsFalse()
        {
            int zero = 0;
            Assert.False(Is.Negative(zero));
        }


        [Test]
        public void IsNegative_NegativeShort_ReturnsTrue()
        {
            short notNegativeInteger = -1123;
            Assert.True(Is.Negative(notNegativeInteger));
        }

        [Test]
        public void IsNegative_NonNegativeShort_ReturnsFalse()
        {
            short negativeInteger = 1;
            Assert.False(Is.Negative(negativeInteger));
        }

        [Test]
        public void IsNegative_ShortZero_ReturnsFalse()
        {
            short zero = 0;
            Assert.False(Is.Negative(zero));
        }

        [Test]
        public void IsNegative_NegativeLong_ReturnsTrue()
        {
            long negativeInteger = -11221123;
            Assert.True(Is.Negative(negativeInteger));
        }

        [Test]
        public void IsNegative_NonNegativeLong_ReturnsFalse()
        {
            long nonNegativeInteger = 1;
            Assert.False(Is.Negative(nonNegativeInteger));
        }

        [Test]
        public void IsNegative_LongZero_ReturnsFalse()
        {
            long zero = 0;
            Assert.False(Is.Negative(zero));
        }


        [Test]
        public void IsNegative_NegativeFloat_ReturnsTrue()
        {
            float negativeInteger = -1.1221123f;
            Assert.True(Is.Negative(negativeInteger));
        }

        [Test]
        public void IsNegative_NonNegativeFloat_ReturnsFalse()
        {
            float negativeInteger = 1f;
            Assert.False(Is.Negative(negativeInteger));
        }

        [Test]
        public void IsNegative_FloatZero_ReturnsFalse()
        {
            float zero = 0.0000f;
            Assert.False(Is.Negative(zero));
        }

        [Test]
        public void IsNegative_NegativeDouble_ReturnsTrue()
        {
            double negativeDouble = -1.122;
            Assert.True(Is.Negative(negativeDouble));
        }

        [Test]
        public void IsNegative_NonNegativeDouble_ReturnsFalse()
        {
            double nonNegativeDouble = 1.222;
            Assert.False(Is.Negative(nonNegativeDouble));
        }

        [Test]
        public void IsNegative_DoubleZero_ReturnsFalse()
        {
            double zero = 0;
            Assert.False(Is.Negative(zero));
        }

        [Test]
        public void IsNegative_NegativeDecimal_ReturnsTrue()
        {
            decimal negativeDecimal = -1.122m;
            Assert.True(Is.Negative(negativeDecimal));
        }


        [Test]
        public void IsZero_ShortZero_ReturnTrue()
        {
            short zero = 0;
            Assert.True(Is.Zero(zero));
        }

        
        [Test]
        public void IsZero_ShortNotZero_ReturnFalse()
        {
            short zero = 8;
            Assert.False(Is.Zero(zero));
        }


        [Test]
        public void IsZero_IntZero_ReturnTrue()
        {
            int zero = 0;
            Assert.True(Is.Zero(zero));
        }

        
        [Test]
        public void IsZero_IntNotZero_ReturnFalse()
        {
            int zero = 8;
            Assert.False(Is.Zero(zero));
        }


        [Test]
        public void IsZero_LongZero_ReturnTrue()
        {
            long zero = 0;
            Assert.True(Is.Zero(zero));
        }

        
        [Test]
        public void IsZero_LongNotZero_ReturnFalse()
        {
            long zero = 8;
            Assert.False(Is.Zero(zero));
        }


        [Test]
        public void IsZero_FloatZero_ReturnTrue()
        {
            float zero = 0.0f;
            Assert.True(Is.Zero(zero));
        }

        
        [Test]
        public void IsZero_FloatNotZero_ReturnFalse()
        {
            float zero = 8.00000f;
            Assert.False(Is.Zero(zero));
        }


        [Test]
        public void IsZero_DecimalZero_ReturnTrue()
        {
            decimal zero = 0.0M;
            Assert.True(Is.Zero(zero));
        }

        
        [Test]
        public void IsZero_DecimalNotZero_ReturnFalse()
        {
            decimal zero = 8.00000M;
            Assert.False(Is.Zero(zero));
        }
        
        [Test]
        public void IsNegative_NonNegativeDecimal_ReturnsFalse()
        {
            decimal negativeDecimal = 1.122m;
            Assert.False(Is.Negative(negativeDecimal));
        }

        [Test]
        public void IsNegative_DecimalZero_ReturnsFalse()
        {
            decimal negativeDecimal = 0;
            Assert.False(Is.Negative(negativeDecimal));
        }

        [Test]
        public void IsNotZero_ShortZero_ReturnFale()
        {
            short zero = 0;
            Assert.False(Is.NotZero(zero));
        }

        
        [Test]
        public void IsNotZero_ShortNotZero_ReturnTrue()
        {
            short notZero = 8;
            Assert.True(Is.NotZero(notZero));
        }

        [Test]
        public void IsNotZero_IntZero_ReturnFale()
        {
            int zero = 0;
            Assert.False(Is.NotZero(zero));
        }

        
        [Test]
        public void IsNotZero_IntNotZero_ReturnTrue()
        {
            int notZero = 8;
            Assert.True(Is.NotZero(notZero));
        }

        [Test]
        public void IsNotZero_LongZero_ReturnFale()
        {
            long zero = 0;
            Assert.False(Is.NotZero(zero));
        }

        
        [Test]
        public void IsNotZero_LongNotZero_ReturnTrue()
        {
            long notZero = 873249872345;
            Assert.True(Is.NotZero(notZero));
        }

        [Test]
        public void IsNotZero_FloatZero_ReturnFale()
        {
            float zero = 0.0f;
            Assert.False(Is.NotZero(zero));
        }

        
        [Test]
        public void IsNotZero_FloatNotZero_ReturnTrue()
        {
            float notZero = 8.000f;
            Assert.True(Is.NotZero(notZero));
        }

        [Test]
        public void IsNotZero_DoubleZero_ReturnFale()
        {
            double zero = 0.0;
            Assert.False(Is.NotZero(zero));
        }

        
        [Test]
        public void IsNotZero_DoubleNotZero_ReturnTrue()
        {
            double notZero = 8.000;
            Assert.True(Is.NotZero(notZero));
        }

        [Test]
        public void IsNotZero_DecimalZero_ReturnFale()
        {
            double zero = 0.0d;
            Assert.False(Is.NotZero(zero));
        }

        
        [Test]
        public void IsNotZero_DecimalNotZero_ReturnTrue()
        {
            double notZero = 8.000d;
            Assert.True(Is.NotZero(notZero));
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
