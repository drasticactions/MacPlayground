using System;
namespace MacPlayground
{
	public class MainViewController : UISplitViewController
	{
		private SidebarViewController sidebar;
		private MacSidebarMenuOptions options;

		public MainViewController(MacSidebarMenuOptions options)
        {
			this.options = options;
			this.PrimaryBackgroundStyle = UISplitViewControllerBackgroundStyle.Sidebar;
			this.sidebar = new SidebarViewController(this.options);
            var vc = new UIViewController();
            vc.View!.AddSubview(new UILabel(vc.View.Frame)
            {
                BackgroundColor = UIColor.SystemBackground,
                TextAlignment = UITextAlignment.Center,
                Text = "Hello, Catalyst!",
                AutoresizingMask = UIViewAutoresizing.All,
            });
            this.ViewControllers = new[] { this.sidebar, vc }; 
        }
	}
}

