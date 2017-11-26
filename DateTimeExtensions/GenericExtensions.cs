namespace DateTimeExtensions
{
    using System;

    public static class GenericExtensions
    {
        public static T Max<T>(this T first, T other) where T : IComparable<T>
        {
            return first.CompareTo(other) >= 0 ? first : other;
        }

        public static T Min<T>(this T first, T other) where T : IComparable<T>
        {
            return first.CompareTo(other) < 0 ? first : other;
        }
    }
}
