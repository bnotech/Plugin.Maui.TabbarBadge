# Plugin.Maui.TabbarBadge

A library to add Tabbar Badge to Shell Tabbar Items for Android and iOS using .NET MAUI.

## Setup

Add the `Plugin.Maui.TabbarBadge` Nuget Package to your project.

Initialize the Library in your `MauiProgram.cs`:

```
builder
    .UseMauiApp<App>()
    .UseTabbarBadge() // <- Add This Line
    .ConfigureFonts(fonts =>
    {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    })
```

Next you need to assign the Badge to one of your Tabs, the Tab should be setup in your `AppShell.xaml` like this:

```
<Tab Title="Cart"
     Icon="tab_cart.png"
     x:Name="CartTab">
    <ShellContent ContentTemplate="{DataTemplate cart:CartPage}" />
</Tab>
```

In the `AppShell.xaml.cs` Constructor assign the Tab:

```
public AppShell()
{
    InitializeComponent();
    
    this.AssignBadge(CartTab); // <- Add this line
}
```

From now on if you want to change the badge number you can call:

```
BadgeCounterService.SetCount(1);
```

## Credits

This library is based on the work done by [@Abhayprince](https://github.com/Abhayprince).

Check out his original [Repoistory](https://github.com/Abhayprince/TabbarBadgeShellMAUI) and the associated Youtube Video for more information about the process.

## License

As the original sample this Library is using the MIT License.