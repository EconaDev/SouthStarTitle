using System;

namespace SouthStarTitleCommon
{
    public class Util
    {
        // Methods
        private Util()
        {
        }

        public static bool IsDateTime(object o)
        {
            return (o is DateTime);
        }

        public static bool IsNumeric(object o)
        {
            return ((((((o is short) || (o is int)) || ((o is long) || (o is decimal))) || (((o is double) || (o is byte)) || ((o is sbyte) || (o is float)))) || ((o is ushort) || (o is uint))) || (o is ulong));
        }
    }
}
