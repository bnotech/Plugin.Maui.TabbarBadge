namespace Plugin.Maui.TabbarBadge;

public static class ShellExtension
{
    public static void AssignBadge(this Shell shell, Tab tab)
    {
        BadgeCounterService.BadgeTabIndex = shell.Items.First().Items.IndexOf(tab);
    }
}