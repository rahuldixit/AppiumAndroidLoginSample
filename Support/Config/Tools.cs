using System;

namespace GE2AutomatedTesting.Support
{
    public static class Tools
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
