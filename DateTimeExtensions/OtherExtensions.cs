namespace DateTimeExtensions;

public static class OtherExtensions
{
    public static long Floor(this long number, long significance)
        => significance * (number / significance);

    public static long Ceiling(this long number, long significance)
    {
        var intervals = number / significance;

        if (number % significance != 0)
        {
            intervals++;
        }

        return intervals * significance;
    }
}
