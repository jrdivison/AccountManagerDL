using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class SystemExtension
    {
        public static bool IsNulOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string Format(this string value, string format)
        {
            return format.IsNulOrEmpty()
                ? string.Format(value)
                : string.Format(format, value);
        }
    }
}
