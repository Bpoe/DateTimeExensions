namespace DateTimeExtensions
{
    using System;

    public static class DateTimeExtensions
    {
        public static DateTime Floor(this DateTime dateTime, TimeSpan significance)
        {
            return new DateTime(dateTime.Ticks.Floor(significance.Ticks), dateTime.Kind);
        }

        public static DateTime Ceiling(this DateTime dateTime, TimeSpan significance)
        {
            return new DateTime(dateTime.Ticks.Ceiling(significance.Ticks), dateTime.Kind);
        }
    }
}
