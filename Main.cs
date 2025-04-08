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

        // populate search results panel
        private void PopulateSearchResultsPanel(Panel targetPanel, List<object> searchResults, string resultType)
        {
            targetPanel.Controls.Clear();
            targetPanel.AutoScroll = true;

            int yOffset = 10;

            foreach (var result in searchResults)
            {
                Control resultControl = null;

                if (resultType == "Landlord" && result is Landlord landlord)
                {
                    resultControl = new Label
                    {
                        Text = $"{landlord.FirstName} {landlord.LastName} - {landlord.Address}",
                        AutoSize = true,
                        Location = new Point(10, yOffset)
                    };
                    resultControl.Click += (sender, e) => OnSearchResultClicked(landlord);
                }
                else if (resultType == "Tenant" && result is Tenant tenant)
                {
                    resultControl = new Label
                    {
                        Text = $"{tenant.FirstName} {tenant.LastName} - {tenant.Email}",
                        AutoSize = true,
                        Location = new Point(10, yOffset)
                    };
                    resultControl.Click += (sender, e) => OnSearchResultClicked(tenant);
                }
                else if (resultType == "Property" && result is Property property)
                {
                    resultControl = new Label
                    {
                        Text = $"{property.AddressLine1}, {property.City} - Rent: {property.RentAmount}",
                        AutoSize = true,
                        Location = new Point(10, yOffset)
                    };
                    resultControl.Click += (sender, e) => OnSearchResultClicked(property);
                }

                if (resultControl != null)
                {
                    targetPanel.Controls.Add(resultControl);
                    yOffset += resultControl.Height + 5;
                }
            }
        }

        private void OnSearchResultClicked(object selectedItem)
        {
            txtbxSearch.Text = "";

            lblPropertyTenant.Text = "";
            lblPropertyLandord.Text = "";

            txtbxLandlordFName.Text = "";
            txtbxLandlordLName.Text = "";
            txtbxLandlordAddress.Text = "";
            txtbxLandlordPhone.Text = "";
            txtbxLandlordEmail.Text = "";
            richtxtbxLandlord.Text = "";

            txtbxTenantFName.Text = "";
            txtbxTenantLName.Text = "";
            txtbxTenantPhone.Text = "";
            txtbxTenantEmail.Text = "";
            richtxtbxTenant.Text = "";

            txtbxHNo.Text = "";
            txtbxAddress.Text = "";
            txtbxCity.Text = "";
            txtbxPostcode.Text = "";

            numRent.Value = 0;

            dateGas.Value = DateTime.Now;
            dateEPC.Value = DateTime.Now;
            dateEICR.Value = DateTime.Now;

            cmbobxEPC.SelectedItem = null;

            richtxtbxProperty.Text = "";

            if (selectedItem is Landlord landlord)
            {
                panelSearchResults.Visible = false;
                ShowLandlordDetails(landlord);
            }
            else if (selectedItem is Tenant tenant)
            {
                panelSearchResults.Visible = false;
                ShowTenantDetails(tenant);
            }
            else if (selectedItem is Property property)
            {
                panelSearchResults.Visible = false;
                ShowPropertyDetails(property);
            }
        }

        private void ShowLandlordDetails(Landlord landlord)
        {
            txtbxLandlordFName.Text = landlord.FirstName;
            txtbxLandlordLName.Text = landlord.LastName;
            txtbxLandlordAddress.Text = landlord.Address;
            txtbxLandlordPhone.Text = landlord.PhoneNumber;
            txtbxLandlordEmail.Text = landlord.Email;
            richtxtbxLandlord.Text = landlord.Notes;
        }

        private void ShowTenantDetails(Tenant tenant)
        {
            txtbxTenantFName.Text = tenant.FirstName;
            txtbxTenantLName.Text = tenant.LastName;
            txtbxTenantPhone.Text = tenant.PhoneNumber;
            txtbxTenantEmail.Text = tenant.Email;
            richtxtbxTenant.Text = tenant.Notes;
        }

        private void ShowPropertyDetails(Property property)
        {
            txtbxHNo.Text = property.HouseNo;
            txtbxAddress.Text = property.AddressLine1;
            txtbxCity.Text = property.City;
            txtbxPostcode.Text = property.PostCode;

            numRent.Value = (decimal)property.RentAmount;

            dateGas.Value = property.GasCertExpiry;
            dateEPC.Value = property.EPCExpiry;
            dateEICR.Value = property.EICRExpiry;

            cmbobxEPC.SelectedItem = property.EPCRating;

            richtxtbxProperty.Text = property.Notes;

            if (property.TenantId.HasValue)
            {
                ShowTenantDetails(Global.Tenants.FindById(property.TenantId.Value));
                lblPropertyTenant.Text = $"{Global.Tenants.FindById(property.TenantId.Value).FirstName} {Global.Tenants.FindById(property.TenantId.Value).LastName}";
            }

            ShowLandlordDetails(Global.Landlords.FindById(property.LandlordId));
            lblPropertyLandord.Text = $"{Global.Landlords.FindById(property.LandlordId).FirstName} {Global.Landlords.FindById(property.LandlordId).LastName}";

            dgvMaintenances.DataSource = Global.Properties.FindMaintenancesFromId(property.PropertyId);
        }

        private void txtbxSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtbxSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                panelSearchResults.Controls.Clear();
                panelSearchResults.Visible = false;
                return;
            }

            panelSearchResults.Visible = true;

            if (radioBtnLandlord.Checked && Global.Landlords != null)
            {
                var results = Global.Landlords.GetAll()
                    .Where(l => l.FirstName.ToLower().Contains(query)
                             || l.LastName.ToLower().Contains(query)
                             || l.Address.ToLower().Contains(query))
                    .ToList();

                PopulateSearchResultsPanel(panelSearchResults, results.Cast<object>().ToList(), "Landlord");
            }
            else if (radioBtnTenant.Checked && Global.Tenants != null)
            {
                var results = Global.Tenants.GetAll()
                    .Where(t => t.FirstName.ToLower().Contains(query)
                             || t.LastName.ToLower().Contains(query)
                             || (t.Email?.ToLower().Contains(query) ?? false)
                             || (t.PhoneNumber?.ToLower().Contains(query) ?? false))
                    .ToList();

                PopulateSearchResultsPanel(panelSearchResults, results.Cast<object>().ToList(), "Tenant");
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

                PopulateSearchResultsPanel(panelSearchResults, results.Cast<object>().ToList(), "Property");
            }
        }

        private void btnQuickLinks_Click(object sender, EventArgs e)
        {
            QuickLinksManager q = new QuickLinksManager();
            q.ShowDialog();
        }
    }
}
