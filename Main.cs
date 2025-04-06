namespace iLet4You
{
    public partial class Main : Form
    {
        public Panel QuickLinkPanel => panel1;
        public TabPage DashboardTab => tabPage5;

        public Main()
        {
            string username = Global.User?.Username;
            string role = Global.User?.Role;

            InitializeComponent();

            this.Text = $"iLet4You | {username} | {role}";

            // show and enable admin controls button is user is admin
            btnAdmin.Enabled = (role == "admin");
            btnAdmin.Visible = (role == "admin");
            Global.Server.RequestData();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

            AdminPanel a = new AdminPanel();
            a.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private Label CreateLabel(string text)
        {
            return new Label
            {
                AutoSize = true,
                Text = text,
                Font = new Font("Segoe UI", 16f, FontStyle.Regular),
                Margin = new Padding(10),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private Control CreateSpacer()
        {
            return new Label
            {
                Text = "",
                Height = 15
            };
        }

        private void DisplayLandlordResultsWithRelations(List<Landlord> landlords)
        {
            tabPage2.Controls.Clear();
            tabPage1.Controls.Clear();
            tabPage3.Controls.Clear();

            foreach (var landlord in landlords)
            {
                tabPage2.Controls.Add(CreateLabel(
                    $"#{landlord.LandlordId} - {landlord.FirstName} {landlord.LastName}, {landlord.Address}"
                ));

                var landlordNotesBox = new RichTextBox
                {
                    Text = landlord.Notes ?? "No notes available",
                    Font = new Font("Segoe UI", 12f),
                    Width = tabPage2.Width - 40,
                    Height = 100,
                    ReadOnly = true,
                    Margin = new Padding(10),
                };
                landlordNotesBox.Top = 30;
                tabPage2.Controls.Add(landlordNotesBox);

                var properties = Global.Properties?.GetAll()
                    .Where(p => p.LandlordId == landlord.LandlordId)
                    .ToList() ?? new List<Property>();

                foreach (var property in properties)
                {
                    tabPage1.Controls.Add(CreateLabel(
                        $"#{property.PropertyId} - {property.HouseNo} {property.AddressLine1}, {property.City}, {property.PostCode}, Rent: £{property.RentAmount:F2}"
                    ));

                    var propertyNotesBox = new RichTextBox
                    {
                        Text = property.Notes ?? "No notes available",
                        Font = new Font("Segoe UI", 12f),
                        Width = tabPage1.Width - 40,
                        Height = 100,
                        ReadOnly = true,
                        Margin = new Padding(10),
                    };
                    propertyNotesBox.Top = 30;
                    tabPage1.Controls.Add(propertyNotesBox);

                    if (property.TenantId.HasValue == true)
                    {
                        var tenant = Global.Tenants?.GetAll()
                            .FirstOrDefault(t => t.TenantId == property.TenantId.Value);

                        if (tenant != null)
                        {
                            tabPage3.Controls.Add(CreateLabel(
                                $"#{tenant?.TenantId} - {tenant?.FirstName} {tenant?.LastName}, Phone: {tenant?.PhoneNumber}, Email: {tenant?.Email}"
                            ));

                            var tenantNotesBox = new RichTextBox
                            {
                                Text = tenant?.Notes ?? "No notes available",
                                Font = new Font("Segoe UI", 12f),
                                Width = tabPage3.Width - 40,
                                Height = 100,
                                ReadOnly = true,
                                Margin = new Padding(10),
                            };
                            tenantNotesBox.Top = 30;
                            tabPage3.Controls.Add(tenantNotesBox);
                        }
                    }

                    tabPage3.Controls.Add(CreateSpacer());
                    tabPage1.Controls.Add(CreateSpacer());
                }

                tabPage2.Controls.Add(CreateSpacer());
            }
        }

        private void DisplayTenantResultsWithRelations(List<Tenant> tenants)
        {
            tabPage3.Controls.Clear();
            tabPage1.Controls.Clear();
            tabPage2.Controls.Clear();

            foreach (var tenant in tenants)
            {
                tabPage3.Controls.Add(CreateLabel(
                    $"#{tenant.TenantId} - {tenant.FirstName} {tenant.LastName}, Phone: {tenant.PhoneNumber}, Email: {tenant.Email}"
                ));

                var tenantNotesBox = new RichTextBox
                {
                    Text = tenant.Notes ?? "No notes available",
                    Font = new Font("Segoe UI", 12f),
                    Width = tabPage3.Width - 40,
                    Height = 100,
                    ReadOnly = true,
                    Margin = new Padding(10),
                };
                tenantNotesBox.Top = 30;
                tabPage3.Controls.Add(tenantNotesBox);

                var property = Global.Properties?.GetAll()
                    .FirstOrDefault(p => p.TenantId == tenant.TenantId);

                if (property != null)
                {
                    tabPage1.Controls.Add(CreateLabel(
                        $"#{property?.PropertyId} - {property?.HouseNo} {property?.AddressLine1}, {property?.City}, {property?.PostCode}, Rent: £{property?.RentAmount:F2}"
                    ));

                    var propertyNotesBox = new RichTextBox
                    {
                        Text = property?.Notes ?? "No notes available",
                        Font = new Font("Segoe UI", 12f),
                        Width = tabPage1.Width - 40,
                        Height = 100,
                        ReadOnly = true,
                        Margin = new Padding(10),
                    };
                    propertyNotesBox.Top = 30;
                    tabPage1.Controls.Add(propertyNotesBox);

                    var landlord = Global.Landlords?.GetAll()
                        .FirstOrDefault(l => l.LandlordId == property?.LandlordId);

                    if (landlord != null)
                    {
                        tabPage2.Controls.Add(CreateLabel(
                            $"#{landlord?.LandlordId} - {landlord?.FirstName} {landlord?.LastName}, {landlord?.Address}"
                        ));

                        var landlordNotesBox = new RichTextBox
                        {
                            Text = landlord?.Notes ?? "No notes available",
                            Font = new Font("Segoe UI", 12f),
                            Width = tabPage2.Width - 40,
                            Height = 100,
                            ReadOnly = true,
                            Margin = new Padding(10),
                        };
                        landlordNotesBox.Top = 30;
                        tabPage2.Controls.Add(landlordNotesBox);
                    }

                    tabPage2.Controls.Add(CreateSpacer());
                    tabPage1.Controls.Add(CreateSpacer());
                }

                tabPage3.Controls.Add(CreateSpacer());
            }
        }

        private void DisplayPropertyResultsWithRelations(List<Property> properties)
        {
            tabPage1.Controls.Clear();
            tabPage2.Controls.Clear();
            tabPage3.Controls.Clear();

            foreach (var property in properties)
            {
                tabPage1.Controls.Add(CreateLabel(
                    $"#{property.PropertyId} - {property.HouseNo} {property.AddressLine1}, {property.City}, {property.PostCode}, Rent: £{property.RentAmount:F2}"
                ));

                var propertyNotesBox = new RichTextBox
                {
                    Text = property.Notes ?? "No notes available",
                    Font = new Font("Segoe UI", 12f),
                    Width = tabPage1.Width - 40,
                    Height = 100,
                    ReadOnly = true,
                    Margin = new Padding(10),
                };
                propertyNotesBox.Top = 30;
                tabPage1.Controls.Add(propertyNotesBox);

                var landlord = Global.Landlords?.GetAll()
                    .FirstOrDefault(l => l.LandlordId == property.LandlordId);

                if (landlord != null)
                {
                    tabPage2.Controls.Add(CreateLabel(
                        $"#{landlord?.LandlordId} - {landlord?.FirstName} {landlord?.LastName}, {landlord?.Address}"
                    ));

                    var landlordNotesBox = new RichTextBox
                    {
                        Text = landlord?.Notes ?? "No notes available",
                        Font = new Font("Segoe UI", 12f),
                        Width = tabPage2.Width - 40,
                        Height = 100,
                        ReadOnly = true,
                        Margin = new Padding(10),
                    };
                    landlordNotesBox.Top = 30;
                    tabPage2.Controls.Add(landlordNotesBox);
                }

                if (property.TenantId.HasValue == true)
                {
                    var tenant = Global.Tenants?.GetAll()
                        .FirstOrDefault(t => t.TenantId == property.TenantId.Value);

                    if (tenant != null)
                    {
                        tabPage3.Controls.Add(CreateLabel(
                            $"#{tenant?.TenantId} - {tenant?.FirstName} {tenant?.LastName}, Phone: {tenant?.PhoneNumber}, Email: {tenant?.Email}"
                        ));

                        var tenantNotesBox = new RichTextBox
                        {
                            Text = tenant?.Notes ?? "No notes available",
                            Font = new Font("Segoe UI", 12f),
                            Width = tabPage3.Width - 40,
                            Height = 100,
                            ReadOnly = true,
                            Margin = new Padding(10),
                        };
                        tenantNotesBox.Top = 30;
                        tabPage3.Controls.Add(tenantNotesBox);
                    }
                }

                tabPage2.Controls.Add(CreateSpacer());
                tabPage3.Controls.Add(CreateSpacer());
                tabPage1.Controls.Add(CreateSpacer());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = textBox1.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
                return;

            if (radioBtnLandlord.Checked && Global.Landlords != null)
            {
                var results = Global.Landlords.GetAll()
                    .Where(l => l.FirstName.ToLower().Contains(query)
                             || l.LastName.ToLower().Contains(query)
                             || l.Address.ToLower().Contains(query))
                    .ToList();

                DisplayLandlordResultsWithRelations(results);
            }
            else if (radioBtnTenant.Checked && Global.Tenants != null)
            {
                var results = Global.Tenants.GetAll()
                    .Where(t => t.FirstName.ToLower().Contains(query)
                             || t.LastName.ToLower().Contains(query)
                             || (t.Email?.ToLower().Contains(query) ?? false)
                             || (t.PhoneNumber?.ToLower().Contains(query) ?? false))
                    .ToList();

                DisplayTenantResultsWithRelations(results);
            }
            else if (radioBtnProperty.Checked && Global.Properties != null)
            {
                var results = Global.Properties.GetAll()
                    .Where(p =>
                        (p.HouseNo?.ToLower().Contains(query) ?? false)
                        || p.AddressLine1.ToLower().Contains(query)
                        || p.City.ToLower().Contains(query)
                        || p.PostCode.ToLower().Contains(query))
                    .ToList();

                DisplayPropertyResultsWithRelations(results);
            }
        }
    }
}
