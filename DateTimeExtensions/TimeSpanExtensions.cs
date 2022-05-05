namespace DateTimeExtensions;

using System;

public static class TimeSpanExtensions
{
    public static TimeSpan Floor(this TimeSpan timeSpan, TimeSpan significance)
        => new(timeSpan.Ticks.Floor(significance.Ticks));

    public static TimeSpan Ceiling(this TimeSpan timeSpan, TimeSpan significance)
        => new(timeSpan.Ticks.Ceiling(significance.Ticks));
}
