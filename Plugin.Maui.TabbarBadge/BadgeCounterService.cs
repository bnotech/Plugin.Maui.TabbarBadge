namespace Plugin.Maui.TabbarBadge;

public static class BadgeCounterService
{
    private static int _count;

    public static int BadgeTabIndex { get; set; }
    
    public static int Count
    {
        get => _count;
        private set
        {
            _count = value;
            CountChanged?.Invoke(null, _count);
        }
    }

    public static void SetCount(int count) => Count = count;

    public static event EventHandler<int> CountChanged;
}

