using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public static class EnumConverter
    {
        public static string ToEnumString<T>(this T @enum)
        {
           return Enum.GetName(@enum.GetType(), @enum);
        }
    }
}
