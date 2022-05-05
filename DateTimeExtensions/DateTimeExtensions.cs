namespace DateTimeExtensions;

using System;

public static class DateTimeExtensions
{
    private const string isoFormat = "yyyy-MM-ddTHH:mm:ss.ffffff";

    public static string ToIsoString(this DateTime dateTime)
        => dateTime.Kind == DateTimeKind.Utc // Only add the 'Z' if the DateTime is UTC
            ? dateTime.ToString(isoFormat + "Z")
            : dateTime.ToString(isoFormat);

    public static DateTime Floor(this DateTime dateTime, TimeSpan significance)
        => new(dateTime.Ticks.Floor(significance.Ticks), dateTime.Kind);

    public static DateTime Ceiling(this DateTime dateTime, TimeSpan significance)
        => new(dateTime.Ticks.Ceiling(significance.Ticks), dateTime.Kind);

    public static DateTimeOffset Floor(this DateTimeOffset dateTime, TimeSpan significance)
        => new(dateTime.Ticks.Floor(significance.Ticks), dateTime.Offset);

    public static DateTimeOffset Ceiling(this DateTimeOffset dateTime, TimeSpan significance)
        => new(dateTime.Ticks.Ceiling(significance.Ticks), dateTime.Offset);

    public static DateTime AsUtc(this DateTime value)
        => DateTime.SpecifyKind(value, DateTimeKind.Utc);

    public static DateTime? AsUtc(this DateTime? value)
        => value.HasValue ? value.Value.AsUtc() : null;

    public static DateTime ToFirstDayOfMonth(this DateTime dateTime)
        => new(dateTime.Year, dateTime.Month, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, dateTime.Kind);

    public static DateTime ToLastDayOfMonth(this DateTime dateTime)
        => dateTime
            .ToFirstDayOfMonth()
            .AddMonths(1)
            .AddDays(-1);

    public static DateTime ToNthWeekdayOfMonth(this DateTime dateTime, DayOfWeek dayOfWeek, int occurrence)
    {
        var firstDay = dateTime.ToFirstDayOfMonth();

        var offset = dayOfWeek - firstDay.DayOfWeek;
        if (offset < 0)
        {
            offset += 7;
        }

        return firstDay.AddDays(offset + ((occurrence - 1) * 7));
    }

    public static DateTime ToLastWeekdayOfMonth(this DateTime dateTime, DayOfWeek dayOfWeek)
    {
        var firstDay = dateTime.ToFirstDayOfMonth().AddMonths(1);

        var offset = dayOfWeek - firstDay.DayOfWeek;
        if (offset > 0)
        {
            offset -= 7;
        }

        return firstDay.AddDays(offset);
    }
}
