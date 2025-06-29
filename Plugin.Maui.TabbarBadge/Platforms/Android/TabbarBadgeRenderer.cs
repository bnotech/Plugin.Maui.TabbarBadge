using Google.Android.Material.Badge;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;

namespace Plugin.Maui.TabbarBadge
{
    public partial class TabbarBadgeRenderer
    {
        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new BadgeShellBottomNavViewAppearanceTracker(this, shellItem);
        }
    }

    class BadgeShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
    {
        private BadgeDrawable? _badgeDrawable;
        
        public BadgeShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
        {
        }
        
        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            base.SetAppearance(bottomView, appearance);

            if (_badgeDrawable is null)
            {
                var cartTabbarItemIndex = BadgeCounterService.BadgeTabIndex;

                _badgeDrawable = bottomView.GetOrCreateBadge(cartTabbarItemIndex);
                UpdateBadge(0);
                BadgeCounterService.CountChanged += OnCountChanged;
            }
        }
        
        private void OnCountChanged(object? sender, int newCount)
        {
            UpdateBadge(newCount);
        }
        
        private void UpdateBadge(int count)
        {
            if(_badgeDrawable is not null)
            {
                if (count <= 0)
                {
                    _badgeDrawable.SetVisible(false);
                }
                else
                {
                    _badgeDrawable.Number = count;
                    _badgeDrawable.BackgroundColor = Colors.Red.ToPlatform();
                    _badgeDrawable.BadgeTextColor = Colors.White.ToPlatform();
                    _badgeDrawable.SetVisible(true);
                }
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            BadgeCounterService.CountChanged -= OnCountChanged;
        }
    }
}

