using System;

namespace DeclarativeContracts
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

        public static bool GreaterThanZero(int elementToCheck)
        {
            return elementToCheck > 0;
        }

        public static bool True(bool element)
        {
            return element == true;
        }

        public static bool False(bool element)
        {
            return element == false;
        }
    }
}