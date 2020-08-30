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
        /// 
        /// </summary>
        /// <param name="enumeration">Enumeration that needs to be checked</param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static bool AtLeastOneValue<TValue>(IEnumerable<TValue> enumeration)
        {
            return enumeration != null && enumeration.Any();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumeration"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
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