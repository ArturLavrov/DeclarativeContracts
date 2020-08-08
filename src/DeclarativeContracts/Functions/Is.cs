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
        
        public static bool Default<TElement>(TElement obj) where TElement : struct
        {
            return obj.Equals(default(TElement));
        }
        
        public static bool NotDefault<TElement>(TElement obj) where TElement : struct
        {
            return !obj.Equals(default(TElement));
        }

        public static bool NotNullOrEmptyString(string stringToCheck)
        {
            return !String.IsNullOrEmpty(stringToCheck);
        }

        public static bool Positive(int elementToCheck)
        {
            return elementToCheck > 0;
        }

        public static bool Negative(int elementToCheck)
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

        public static bool Odd(int numberToCheck)
        {
            return (numberToCheck % 2 != 0);
        }
        
        public static bool Even(int numberToCheck)
        {
            return (numberToCheck % 2 == 0);
        } 
    }
}