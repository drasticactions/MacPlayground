namespace MacPlayground
{
    public class MacSidebarMenuOptions
    {
        public MacSidebarMenuOptions(string header, IEnumerable<NavigationSidebarItem> items, bool showSettings = false, string settingsTitle = "Settings", bool showSearchBar = false, string searchBarHeader = "Search", UINavigationItemLargeTitleDisplayMode largeTitle = UINavigationItemLargeTitleDisplayMode.Always)
        {
            this.LargeTitleDisplayMode = largeTitle;
            this.Header = header;
            this.DefaultSidebarItems = items.ToList().AsReadOnly();
            this.ShowSearchBar = showSearchBar;
            this.SearchBarHeader = searchBarHeader;
            this.SettingsTitle = settingsTitle;
            this.ShowSettingsItem = showSettings;
        }

        public IReadOnlyList<NavigationSidebarItem> DefaultSidebarItems { get; }

        public string Header { get; }

        public bool ShowSettingsItem { get; }

        public string SettingsTitle { get; }

        public bool ShowSearchBar { get; }

        public string SearchBarHeader { get; }

        public UINavigationItemLargeTitleDisplayMode LargeTitleDisplayMode { get; }
    }

    public class NavigationSidebarItem : Foundation.NSObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrasticMenuItem"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="action">Action.</param>
        /// <param name="page">Page.</param>
        /// <param name="id">Id. Auto Generated.</param>
        /// <param name="subtitle">Subtitle.</param>
        /// <param name="imageStream">Icon.</param>
        /// <param name="type">Type of Sidebar Item.</param>
        public NavigationSidebarItem(
            string title,
            Guid? id = null,
            string subtitle = "",
            Stream? imageStream = null,
            SidebarItemType type = SidebarItemType.Row)
        {
            this.Id = id ?? Guid.NewGuid();
            this.Type = type;
            this.Title = title;
            this.Subtitle = subtitle;
            if (imageStream is not null)
            {
                var imageData = Foundation.NSData.FromStream(imageStream);
                if (imageData is not null)
                {
                    this.Image = UIKit.UIImage.LoadFromData(imageData);
                }

                imageStream.Seek(0, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Gets the Id of the menu item.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the type of sidebar item.
        /// </summary>
        public SidebarItemType Type { get; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        public UIKit.UIImage? Image { get; private set; }

        /// <summary>
        /// Gets the text for the menu item.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the subtitle text for the menu item.
        /// Optional.
        /// </summary>
        public string? Subtitle { get; }
    }

    /// <summary>
    /// Sidebar Item Type.
    /// </summary>
    public enum SidebarItemType
    {
        /// <summary>
        /// Header.
        /// </summary>
        Header,

        /// <summary>
        /// Expandable Row.
        /// </summary>
        ExpandableRow,

        /// <summary>
        /// Row.
        /// </summary>
        Row,

        /// <summary>
        /// Footer.
        /// </summary>
        Footer,
    }

    public class SidebarMenuItemSelectedEventArgs : EventArgs
    {
        private readonly NavigationSidebarItem item;

        public SidebarMenuItemSelectedEventArgs(NavigationSidebarItem item)
        {
            this.item = item;
        }

        public NavigationSidebarItem Item => this.item;
    }
}

