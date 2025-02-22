﻿using Microsoft.AspNetCore.Components;

namespace Kanba.Layout;

public partial class MainLayout : LayoutComponentBase
{
    private bool drawerOpen = true;
    private bool isDarkMode = true;

    private void DrawerToggle()
    {
        drawerOpen = !drawerOpen;
    }
}
