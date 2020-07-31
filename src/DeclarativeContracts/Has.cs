using System.Collections.Generic;
using System.Linq;

namespace DeclarativeContracts
{
    public static class Has
    {
        public static bool AtLeastOneValue<TValue>(IEnumerable<TValue> enumeration)
        {
            return enumeration.Any();
        }

        public static bool OnlyOneValue<TValue>(IEnumerable<TValue> enumeration)
        {
            return !(enumeration.LongCount() > 1);
        }
    }
}