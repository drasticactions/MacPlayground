namespace MacPlayground;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

    private MacSidebarMenuOptions options;
    private List<NavigationSidebarItem> items;

    public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
        this.items = new List<NavigationSidebarItem>();
        this.options = new MacSidebarMenuOptions("Mac Playground", this.items);

        // create a new window instance based on the screen size
        Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// create a UIViewController with a single UILabel
		var vc = new MainViewController(this.options);
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}
}
