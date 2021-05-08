using System;
namespace RomanToNumericMicroservice.Helper
{
    public static class Extensions
    {
        public static RomanEnumerate ToRomanEnum(this string s)
        {
            return (RomanEnumerate)Enum.Parse(typeof(RomanEnumerate), s, true);
        }
    }
}