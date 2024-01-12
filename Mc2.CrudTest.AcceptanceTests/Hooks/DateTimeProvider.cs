namespace Mc2.CrudTest.AcceptanceTests.Hooks;

public static class DateTimeProvider
{
    private static readonly AsyncLocal<DateTime> _now;

    static DateTimeProvider()
    {
        _now = new AsyncLocal<DateTime> { Value = DateTime.Now };
    }

    public static DateTime Now
    {
        get => _now.Value == DateTime.MinValue ? DateTime.Now : _now.Value;
        set => _now.Value = value;
    }
}