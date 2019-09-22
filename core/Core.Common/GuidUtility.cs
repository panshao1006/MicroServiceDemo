using System;

namespace Core.Common
{
    public class GuidUtility
    {
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
