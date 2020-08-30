using System;

namespace DeclarativeContracts.Functions
{
    /// <summary>
    /// Class that represent a set of function to check whether passed argument satisfy condition or not
    /// </summary>
    public static partial class Is
    {
        /// <summary>
        /// Check whether element is null
        /// </summary>
        /// <typeparam name="TElement">Element that needs to be cheked. Element should be a refernce type</typeparam>
        public static bool Null<TElement>(TElement obj) where TElement : class
        {
            return obj == null;
        }
        
        /// <summary>
        /// Check whether element is not null
        /// </summary>
        /// <typeparam name="TElement">Element that needs to be cheked. Element should be a refernce type</typeparam>
        public static bool NotNull<TElement>(TElement obj) where TElement : class
        {
            return obj != null;
        }
        
        // <summary>
        /// Check whether element is equals to default type. For instance Int32.MinValue or Guid.Empty etc
        /// </summary>
        /// <typeparam name="TElement">Element that needs to be cheked. Element should be a value type</typeparam> 
        public static bool Default<TElement>(TElement obj) where TElement : struct
        {
            return obj.Equals(default(TElement));
        }
        
        // <summary>
        /// Check whether element is not equals to default type. For instance Int32.MinValue or Guid.Empty etc
        /// </summary>
        /// <typeparam name="TElement">Element that needs to be cheked. Element should be a value type</typeparam> 
        public static bool NotDefault<TElement>(TElement obj) where TElement : struct
        {
            return !obj.Equals(default(TElement));
        }

        /// <summary>
        /// Check whether string is not null or empty
        /// </summary>
        /// <param name="stringToCheck">String to check</param>
        /// <returns></returns>
        public static bool NotNullOrEmptyString(string stringToCheck)
        {
            return !String.IsNullOrEmpty(stringToCheck);
        }        

        /// <summary>
        /// Check whether element is true
        /// </summary>
        /// <param name="stringToCheck">Boolen to check</param>
        /// <returns></returns>
        public static bool True(bool element)
        {
            return element;
        }

        /// <summary>
        /// Check whether element is false
        /// </summary>
        /// <param name="stringToCheck">Boolen to check</param>
        /// <returns></returns>
        public static bool False(bool element)
        {
            return !element;
        }        
    }
}
