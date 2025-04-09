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
            RefreshData();

            this.Text = $"iLet4You | {username} | {role}";

            cmbobxMaintenanceStatus.SelectedIndex = 0;
            dateMaintenanceCompleted.Enabled = false; // disable until checked

            // show and enable admin controls button is user is admin
            btnAdmin.Enabled = (role == "admin");
            btnAdmin.Visible = (role == "admin");
            Global.Server.RequestData();
        }

        public static Main? Instance { get; private set; }
        // server response
        private static TaskCompletionSource<bool> result = new();
        public static void ResultReceived(bool success)
        {
            if (!result.Task.IsCompleted)
            {
                result.SetResult(success);
            }
        }

        private async Task<bool> AwaitResponse()
        {
            Cursor = Cursors.WaitCursor; // loading cursor

            Task delayTask = Task.Delay(5000); // timeout after 5 seconds
            Task completedTask = await Task.WhenAny(result.Task, delayTask);

            Cursor = Cursors.Default;

            return completedTask == result.Task && result.Task.Result;
        }

        private async void RefreshData()
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestData();
            bool success = await AwaitResponse(); // wait for response

            dgvMaintenances.DataSource = null;
            dgvLandlordProperties.DataSource = null;
            dgvTenantProperties.DataSource = null;
            dgvRents.DataSource = null;

            if (_selectedProperty != null) dgvMaintenances.DataSource = Global.Properties?.FindMaintenancesFromId(_selectedProperty.Value.PropertyId);
            if (_selectedLandlord != null) dgvLandlordProperties.DataSource = Global.Landlords?.FindPropertiesFromId(_selectedLandlord.Value.LandlordId);
            if (_selectedTenant != null) dgvTenantProperties.DataSource = Global.Tenants?.FindPropertiesFromId(_selectedTenant.Value.TenantId);
            if (_selectedTenant != null) dgvRents.DataSource = Global.Tenants?.FindRentsFromId(_selectedTenant.Value.TenantId);
        }

        // landlords
        private async void CreateLandlord(string fName, string lName, string address, string phone, string email, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "FirstName", $"{fName}" },
                { "LastName", $"{lName}" },
                { "Address", $"{address}" },
                { "PhoneNumber", $"{phone}" },
                { "Email", $"{email}" },
                { "Notes", $"{notes}" }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestCreateRecord(Settings.landlordsTable, data);
            bool success = await AwaitResponse();
        }

        private async void UpdateLandlord(int id, string fName, string lName, string address, string phone, string email, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "FirstName", $"{fName}" },
                { "LastName", $"{lName}" },
                { "Address", $"{address}" },
                { "PhoneNumber", $"{phone}" },
                { "Email", $"{email}" },
                { "Notes", $"{notes}" }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUpdateRecord(Settings.landlordsTable, id, data);
            bool success = await AwaitResponse();
        }

        private async void DeleteLandlord(int id)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestDeleteRecord(Settings.landlordsTable, id);
            bool success = await AwaitResponse();
        }

        // tenants
        private async void CreateTenant(string fName, string lName, string phone, string email, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "FirstName", $"{fName}" },
                { "LastName", $"{lName}" },
                { "PhoneNumber", $"{phone}" },
                { "Email", $"{email}" },
                { "Notes", $"{notes}" }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestCreateRecord(Settings.tenantsTable, data);
            bool success = await AwaitResponse();
        }

        private async void UpdateTenant(int id, string fName, string lName, string phone, string email, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "FirstName", $"{fName}" },
                { "LastName", $"{lName}" },
                { "PhoneNumber", $"{phone}" },
                { "Email", $"{email}" },
                { "Notes", $"{notes}" }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUpdateRecord(Settings.tenantsTable, id, data);
            bool success = await AwaitResponse();
        }

        private async void DeleteTenant(int id)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestDeleteRecord(Settings.tenantsTable, id);
            bool success = await AwaitResponse();
        }

        // properties
        private async void CreateProperty(int landLordId, int tenantId, string houseNo, string address1, string city, string postcode, double rentAmount, DateTime? gasCertExpiry, DateTime? epcExpiry, DateTime? eicrExpiry, string epcRating, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "LandlordID", $"{landLordId}" },
                { "TenantID", $"{tenantId}" },
                { "HouseNo", $"{houseNo}" },
                { "AddressLine1", $"{address1}" },
                { "City", $"{city}" },
                { "PostCode", $"{postcode}" },
                { "RentAmount", $"{rentAmount}" },
                { "GasCertExpiry", gasCertExpiry?.ToString("yyyy-MM-dd") }, // nullable
                { "EPCExpiry", epcExpiry?.ToString("yyyy-MM-dd") },
                { "EICRExpiry", eicrExpiry?.ToString("yyyy-MM-dd") },
                { "EPCRating", $"{epcRating}" },
                { "Notes", $"{notes}" }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestCreateRecord(Settings.propertiesTable, data);
            bool success = await AwaitResponse();
        }

        private async void UpdateProperty(int id, int landLordId, int tenantId, string houseNo, string address1, string city, string postcode, double rentAmount, DateTime? gasCertExpiry, DateTime? epcExpiry, DateTime? eicrExpiry, string epcRating, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "LandlordID", $"{landLordId}" },
                { "TenantID", $"{tenantId}" },
                { "HouseNo", $"{houseNo}" },
                { "AddressLine1", $"{address1}" },
                { "City", $"{city}" },
                { "PostCode", $"{postcode}" },
                { "RentAmount", $"{rentAmount}" },
                { "GasCertExpiry", gasCertExpiry?.ToString("yyyy-MM-dd") },
                { "EPCExpiry", epcExpiry?.ToString("yyyy-MM-dd") },
                { "EICRExpiry", eicrExpiry?.ToString("yyyy-MM-dd") },
                { "EPCRating", $"{epcRating}" },
                { "Notes", $"{notes}" }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUpdateRecord(Settings.propertiesTable, id, data);
            bool success = await AwaitResponse();
        }

        private async void DeleteProperty(int id)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestDeleteRecord(Settings.propertiesTable, id);
            bool success = await AwaitResponse();
        }

        // maintenances
        private async void CreateMaintenance(int propertyId, string description, string status, DateTime dateReported, DateTime? dateCompleted)
        {
            var data = new Dictionary<string, object>
            {
                { "PropertyID", $"{propertyId}" },
                { "Description", $"{description}" },
                { "Status", $"{status}" },
                { "DateReported", $"{dateReported:yyyy-MM-dd}" },
                { "DateCompleted", dateCompleted?.ToString("yyyy-MM-dd") }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestCreateRecord(Settings.maintenancesTable, data);
            bool success = await AwaitResponse();
        }

        private async void UpdateMaintenance(int id, int propertyId, string description, string status, DateTime dateReported, DateTime? dateCompleted)
        {
            var data = new Dictionary<string, object>
            {
                { "PropertyID", $"{propertyId}" },
                { "Description", $"{description}" },
                { "Status", $"{status}" },
                { "DateReported", $"{dateReported:yyyy-MM-dd}" },
                { "DateCompleted", dateCompleted?.ToString("yyyy-MM-dd") }
            };
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUpdateRecord(Settings.maintenancesTable, id, data);
            bool success = await AwaitResponse();
        }

        private async void DeleteMaintenance(int id)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestDeleteRecord(Settings.maintenancesTable, id);
            bool success = await AwaitResponse();
        }

        // rents
        private async void CreateRent(int tenantId, int propertyId, DateTime dueDate, DateTime? dateReceived, double rentAmount, double rentAmountPaid, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "TenantID", tenantId },
                { "PropertyID", propertyId },
                { "DueDate", dueDate.ToString("yyyy-MM-dd") },
                { "DateReceived", dateReceived?.ToString("yyyy-MM-dd") },
                { "RentAmount", rentAmount },
                { "RentAmountPaid", rentAmountPaid },
                { "Notes", notes }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestCreateRecord(Settings.rentsTable, data);
            bool success = await AwaitResponse();
        }

        private async void UpdateRent(int id, int tenantId, int propertyId, DateTime dueDate, DateTime? dateReceived, double rentAmount, double rentAmountPaid, string notes)
        {
            var data = new Dictionary<string, object>
            {
                { "TenantID", tenantId },
                { "PropertyID", propertyId },
                { "DueDate", dueDate.ToString("yyyy-MM-dd") },
                { "DateReceived", dateReceived?.ToString("yyyy-MM-dd") },
                { "RentAmount", rentAmount },
                { "RentAmountPaid", rentAmountPaid },
                { "Notes", notes }
            };

            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUpdateRecord(Settings.rentsTable, id, data);
            bool success = await AwaitResponse();
        }

        private async void DeleteRent(int id)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestDeleteRecord(Settings.rentsTable, id);
            bool success = await AwaitResponse();
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

        // maintenance

        private bool CheckMaintenanceFields()
        {
            if (_selectedProperty == null)
            {
                MessageBox.Show("Please select a property first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(rchtxtbxMaintenance.Text.Trim()))
            {
                MessageBox.Show("Description is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cmbobxMaintenanceStatus.Text.Trim()))
            {
                MessageBox.Show("Status is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(dateMaintenanceReported.Text.Trim())) // idk if this is even possible but just in case
            {
                MessageBox.Show("Date reported is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private async void btnMaintenanceCreate_Click(object sender, EventArgs e)
        {
            if (!CheckMaintenanceFields()) return;

            string description = rchtxtbxMaintenance.Text.Trim();
            string status = cmbobxMaintenanceStatus.Text.Trim();
            DateTime dateReported = dateMaintenanceReported.Value;
            DateTime dateCompleted = dateMaintenanceCompleted.Value;

            CreateMaintenance(_selectedProperty.Value.PropertyId, description, status, dateReported, chkbxMaintenanceCompleted.Checked ? dateCompleted : null);
            await Task.Delay(500);
            RefreshData();

            rchtxtbxMaintenance.Text = "";
            cmbobxMaintenanceStatus.Text = "";
            dateMaintenanceReported.Value = DateTime.Now;
            dateMaintenanceCompleted.Value = DateTime.Now;
        }

        private async void btnMaintenanceUpdate_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dgvMaintenances.SelectedRows[0].Cells["maintenanceIdDataGridViewTextBoxColumn"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a maintenance to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckMaintenanceFields()) return;

            string description = rchtxtbxMaintenance.Text.Trim();
            string status = cmbobxMaintenanceStatus.Text.Trim();
            DateTime dateReported = dateMaintenanceReported.Value;
            DateTime dateCompleted = dateMaintenanceCompleted.Value;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update selected maintenance? (Maintenance ID: '{id}')",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdateMaintenance(id, _selectedProperty.Value.PropertyId, description, status, dateReported, chkbxMaintenanceCompleted.Checked ? dateCompleted : null);
                await Task.Delay(500);
                RefreshData();

                rchtxtbxMaintenance.Text = "";
                cmbobxMaintenanceStatus.Text = "";
                dateMaintenanceReported.Value = DateTime.Now;
                dateMaintenanceCompleted.Value = DateTime.Now;
            }
        }

        private async void btnMaintenanceDelete_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dgvMaintenances.SelectedRows[0].Cells["maintenanceIdDataGridViewTextBoxColumn"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a maintenance to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete selected maintenance? (Maintenance ID: '{id}')",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteMaintenance(id);
                await Task.Delay(500);
                RefreshData();
            }
        }

        private async void btnMaintenanceRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void chkbxMaintenanceCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxMaintenanceCompleted.Checked)
            {
                dateMaintenanceCompleted.Enabled = true;
                cmbobxMaintenanceStatus.SelectedItem = "Completed"; // set to completed
                cmbobxMaintenanceStatus.Enabled = false; // disable status selection
            }
            else
            {
                dateMaintenanceCompleted.Enabled = false;
                cmbobxMaintenanceStatus.Enabled = true;
            }
        }
    }
}
