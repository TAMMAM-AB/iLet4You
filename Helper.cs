using System.Diagnostics;

public static class QuickLinkRenderer
{
    public static void PopulateQuickLinks(Panel targetPanel, List<QuickLink> quickLinks)
    {
        targetPanel.Controls.Clear();
        targetPanel.AutoScroll = true;

        int yOffset = 10;

        foreach (QuickLink link in quickLinks)
        {
            LinkLabel linkLabel = new LinkLabel
            {
                Text = link.Name,
                Tag = link.URL,
                AutoSize = true,
                Location = new Point(10, yOffset)
            };

            linkLabel.LinkClicked += (sender, e) =>
            {
                if (sender is LinkLabel clickedLink && clickedLink.Tag is string url)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not open link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            targetPanel.Controls.Add(linkLabel);
            yOffset += linkLabel.Height + 5;
        }
    }
}

public static class UIUpdater
{
    public static void UpdateHomeTabStats(TabPage parentControl)
    {
        // Find the labels by name
        var labelLandlords = parentControl.Controls.Find("labelTotalLandlords", true).FirstOrDefault() as Label;
        var labelTenants = parentControl.Controls.Find("labelTotalTenants", true).FirstOrDefault() as Label;
        var labelProperties = parentControl.Controls.Find("labelTotalProperties", true).FirstOrDefault() as Label;

        int totalLandlords = Global.Landlords?.GetAll().Count ?? 0;
        int totalTenants = Global.Tenants?.GetAll().Count ?? 0;
        int totalProperties = Global.Properties?.GetAll().Count ?? 0;

        if (labelLandlords != null)
            labelLandlords.Text = $"Total Landlords: {totalLandlords}";

        if (labelTenants != null)
            labelTenants.Text = $"Total Tenants: {totalTenants}";

        if (labelProperties != null)
            labelProperties.Text = $"Total Properties: {totalProperties}";
    }
}
