using System;
using System.Linq;

namespace DeclarativeContracts.Utilities
{
    internal static class ArgumentChecker
    {
        public static void CheckArgumentsNull(params object[] valuesToCheck)
        {
            if (valuesToCheck.Any(value => value == null))
            {
                throw new ArgumentException("entityMemberSelector could not be null.Please check the following doc how to properly use lib");
            }
        }
    }
}