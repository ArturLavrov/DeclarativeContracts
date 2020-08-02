using System;

namespace DeclarativeContracts.Functions
{
    public static class Is
    {
        public static bool Null<TElement>(TElement obj) where TElement : class
        {
            return obj == null;
        }
        
        public static bool NotNull<TElement>(TElement obj) where TElement : class
        {
            return obj != null;
        }
        
        public static bool Empty<TElement>(TElement obj) where TElement : struct
        {
            return obj.Equals(default(TElement));
        }
        
        public static bool NotEmpty<TElement>(TElement obj) where TElement : struct
        {
            return !obj.Equals(default(TElement));
        }

        public static bool NotNullOrEmptyString(string stringToCheck)
        {
            return !String.IsNullOrEmpty(stringToCheck);
        }

        public static bool IsPositive(int elementToCheck)
        {
            return elementToCheck > 0;
        }

        public static bool IsNegative(int elementToCheck)
        {
            return elementToCheck < 0;
        }

        public static bool True(bool element)
        {
            return element;
        }

        public static bool False(bool element)
        {
            return !element;
        }

        public static bool IsOdd(int numberToCheck)
        {
            throw new NotImplementedException("");
        }
        
        public static bool IsEven(int numberToCheck)
        {
            throw new NotImplementedException("");
        }
        
    }
}