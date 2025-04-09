namespace iLet4You
{
    public partial class Main : Form
    {
        public Panel QuickLinkPanel => panel1;
        public TabPage DashboardTab => tabPageHome;

        private Property? _selectedProperty;
        private Landlord? _selectedLandlord;
        private Tenant? _selectedTenant;

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
            panelSearchResults.Visible = false;

            lblPropertyTenant.Text = "";
            lblPropertyLandord.Text = "";
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

            dgvMaintenances.DataSource = null;
            dgvLandlordProperties.DataSource = null;
            dgvTenantProperties.DataSource = null;
            dgvRents.DataSource = null;

            _selectedProperty = null;
            _selectedLandlord = null;
            _selectedTenant = null;

            tabPageProperty.Text = "Property";
            tabPageLandlord.Text = "Landlord";
            tabPageTenant.Text = "Tenant";

            if (radioBtnProperty.Checked) tabControl.SelectedTab = tabPageProperty;
            if (radioBtnLandlord.Checked) tabControl.SelectedTab = tabPageLandlord;
            if (radioBtnTenant.Checked) tabControl.SelectedTab = tabPageTenant;

            if (selectedItem is Landlord landlord)
            {
                _selectedLandlord = landlord;
                ShowLandlordDetails(landlord);
            }
            else if (selectedItem is Tenant tenant)
            {
                _selectedTenant = tenant;
                ShowTenantDetails(tenant);
            }
            else if (selectedItem is Property property)
            {
                _selectedProperty = property;
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

            LandlordTabTitle();

            dgvLandlordProperties.DataSource = Global.Landlords.FindPropertiesFromId(landlord.LandlordId);
        }

        private void ShowTenantDetails(Tenant tenant)
        {
            txtbxTenantFName.Text = tenant.FirstName;
            txtbxTenantLName.Text = tenant.LastName;
            txtbxTenantPhone.Text = tenant.PhoneNumber;
            txtbxTenantEmail.Text = tenant.Email;
            richtxtbxTenant.Text = tenant.Notes;

            TenantTabTitle();

            dgvTenantProperties.DataSource = Global.Tenants.FindPropertiesFromId(tenant.TenantId);
            dgvRents.DataSource = Global.Tenants.FindRentsFromId(tenant.TenantId);
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
                _selectedTenant = Global.Tenants.FindById(property.TenantId.Value);
                ShowTenantDetails(Global.Tenants.FindById(property.TenantId.Value));
                lblPropertyTenant.Text = $"{Global.Tenants.FindById(property.TenantId.Value).FirstName} {Global.Tenants.FindById(property.TenantId.Value).LastName}";
            }

            _selectedLandlord = Global.Landlords.FindById(property.LandlordId);
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
        private void txtbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) txtbxSearch.Text = "";
        }

        private void btnQuickLinks_Click(object sender, EventArgs e)
        {
            QuickLinksManager q = new QuickLinksManager();
            q.ShowDialog();
        }

        // make it obvious to user when there are unsaved changes
        // property tab

        private void PropertyTabTitle()
        {
            if (_selectedProperty != null)
            {
                if (txtbxHNo.Text.Trim() != _selectedProperty.Value.HouseNo.Trim()
                    || txtbxAddress.Text.Trim() != _selectedProperty.Value.AddressLine1.Trim()
                    || txtbxCity.Text.Trim() != _selectedProperty.Value.City.Trim()
                    || txtbxPostcode.Text.Trim() != _selectedProperty.Value.PostCode.Trim()
                    || Math.Round(numRent.Value, 2) != (decimal)_selectedProperty.Value.RentAmount // treat as decimal without converting by using (decimal)
                    || dateGas.Value != _selectedProperty.Value.GasCertExpiry
                    || dateEPC.Value != _selectedProperty.Value.EPCExpiry
                    || dateEICR.Value != _selectedProperty.Value.EICRExpiry
                    || cmbobxEPC.SelectedItem?.ToString() != _selectedProperty.Value.EPCRating.Trim()
                    || richtxtbxProperty.Text.Trim() != _selectedProperty.Value.Notes.Trim()
                    )
                {
                    if (tabPageProperty.Text != "Property *") tabPageProperty.Text = "Property *";
                }
                else
                {
                    if (tabPageProperty.Text != "Property") tabPageProperty.Text = "Property";
                }
            }
        }

        private void txtbxHNo_TextChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void txtbxAddress_TextChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void txtbxCity_TextChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void txtbxPostcode_TextChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void numRent_ValueChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void dateGas_ValueChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void dateEPC_ValueChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void dateEICR_ValueChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void cmbobxEPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        private void richtxtbxProperty_TextChanged(object sender, EventArgs e)
        {
            PropertyTabTitle();
        }

        // landlord tab

        private void LandlordTabTitle()
        {
            if (_selectedLandlord != null)
            {
                if (txtbxLandlordFName.Text.Trim() != _selectedLandlord.Value.FirstName.Trim()
                    || txtbxLandlordLName.Text.Trim() != _selectedLandlord.Value.LastName.Trim()
                    || txtbxLandlordAddress.Text.Trim() != _selectedLandlord.Value.Address.Trim()
                    || txtbxLandlordPhone.Text.Trim() != _selectedLandlord.Value.PhoneNumber.Trim()
                    || txtbxLandlordEmail.Text.Trim() != _selectedLandlord.Value.Email.Trim()
                    || richtxtbxLandlord.Text.Trim() != _selectedLandlord.Value.Notes.Trim()
                    )
                {
                    if (tabPageLandlord.Text != "Landlord *") tabPageLandlord.Text = "Landlord *";
                }
                else
                {
                    if (tabPageLandlord.Text != "Landlord") tabPageLandlord.Text = "Landlord";
                }
            }
        }

        private void txtbxLandlordFName_TextChanged(object sender, EventArgs e)
        {
            LandlordTabTitle();
        }

        private void txtbxLandlordLName_TextChanged(object sender, EventArgs e)
        {
            LandlordTabTitle();
        }

        private void txtbxLandlordAddress_TextChanged(object sender, EventArgs e)
        {
            LandlordTabTitle();
        }

        private void txtbxLandlordPhone_TextChanged(object sender, EventArgs e)
        {
            LandlordTabTitle();
        }

        private void txtbxLandlordEmail_TextChanged(object sender, EventArgs e)
        {
            LandlordTabTitle();
        }

        private void richtxtbxLandlord_TextChanged(object sender, EventArgs e)
        {
            LandlordTabTitle();
        }

        // tenant tab
        private void TenantTabTitle()
        {
            if (_selectedTenant != null)
            {
                if (txtbxTenantFName.Text.Trim() != _selectedTenant.Value.FirstName.Trim()
                    || txtbxTenantLName.Text.Trim() != _selectedTenant.Value.LastName.Trim()
                    || txtbxTenantPhone.Text.Trim() != _selectedTenant.Value.PhoneNumber.Trim()
                    || txtbxTenantEmail.Text.Trim() != _selectedTenant.Value.Email.Trim()
                    || richtxtbxTenant.Text.Trim() != _selectedTenant.Value.Notes.Trim()
                    )
                {
                    if (tabPageTenant.Text != "Tenant *") tabPageTenant.Text = "Tenant *";
                }
                else
                {
                    if (tabPageTenant.Text != "Tenant") tabPageTenant.Text = "Tenant";
                }
            }
        }

        private void txtbxTenantFName_TextChanged(object sender, EventArgs e)
        {
            TenantTabTitle();
        }

        private void txtbxTenantLName_TextChanged(object sender, EventArgs e)
        {
            TenantTabTitle();
        }

        private void txtbxTenantPhone_TextChanged(object sender, EventArgs e)
        {
            TenantTabTitle();
        }

        private void txtbxTenantEmail_TextChanged(object sender, EventArgs e)
        {
            TenantTabTitle();
        }

        private void richtxtbxTenant_TextChanged(object sender, EventArgs e)
        {
            TenantTabTitle();
        }

        private void radioBtnProperty_CheckedChanged(object sender, EventArgs e)
        {
            txtbxSearch_TextChanged(sender, e);
        }

        private void radioBtnLandlord_CheckedChanged(object sender, EventArgs e)
        {
            txtbxSearch_TextChanged(sender, e);
        }

        private void radioBtnTenant_CheckedChanged(object sender, EventArgs e)
        {
            txtbxSearch_TextChanged(sender, e);
        }
    }
}
