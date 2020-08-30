using System.Collections.Generic;
using System.Linq;

namespace DeclarativeContracts.Functions
{
    /// <summary>
    /// Class that contains methods for checkinng with collection
    /// </summary>
    public static class Has
    {
        /// <summary>
        /// Method that checks whether enumeration of items contains at least one value
        /// </summary>
        /// <param name="enumeration">Enumeration that needs to be checked</param>
        /// <typeparam name="TValue">Type of enumeration</typeparam>
        /// <returns>True if enumeration contains more that one value. False if enumeration is empty or null</returns>
        public static bool AtLeastOneValue<TValue>(IEnumerable<TValue> enumeration)
        {
            return enumeration != null && enumeration.Any();
        }

        /// <summary>
        /// Method that verify that enumeration contains only one value.
        /// </summary>
        /// <param name="enumeration"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>True if enumeration contains more that one value. False if enumeration is null or contains more that one value</returns>
        public static bool OnlyOneValue<TValue>(IEnumerable<TValue> enumeration)
        {
            if (enumeration == null)
            {
                return false;
            }

            using (var enumerator = enumeration.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                {
                    return false;
                }

                return !enumerator.MoveNext();
            }
        }
    }
}