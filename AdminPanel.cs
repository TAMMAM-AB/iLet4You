using System.Net;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iLet4You
{
    public partial class AdminPanel : Form
    {
        public static AdminPanel? Instance { get; private set; }
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

        public AdminPanel()
        {
            InitializeComponent();

            cmbobxUserRoles.SelectedIndex = 0;

            RefreshUsers();
            Thread.Sleep(50);
            RefreshData();
        }

        // users
        private async void RefreshUsers()
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUsers();
            bool success = await AwaitResponse(); // wait for response

            dgvUsers.DataSource = null;
            dgvUsers.DataSource = Global.Users?.GetAll();
        }

        private async void DeleteUser(string username)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestDeleteUser(username);
            bool success = await AwaitResponse();
        }

        private async void CreateUser(string username, string password, string role)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestCreateUser(username, password, role);
            bool success = await AwaitResponse();
        }

        private async void UpdatePassword(string username, string password)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUpdatePassword(username, password);
            bool success = await AwaitResponse();
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
        private async void CreateProperty(int landLordId, int tenantId,string houseNo, string address1, string city, string postcode, double rentAmount,DateTime? gasCertExpiry, DateTime? epcExpiry, DateTime? eicrExpiry, string epcRating, string notes)
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

        // quick links
        private async void CreateQuickLink(string name, string url)
        {
            var data = new Dictionary<string, object>
            {
                { "Name", $"{name}" },
                { "URL", $"{url}" }
            };
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestCreateRecord(Settings.quickLinksTable, data);
            bool success = await AwaitResponse();
        }

        private async void UpdateQuickLink(int id, string name, string url)
        {
            var data = new Dictionary<string, object>
            {
                { "Name", $"{name}" },
                { "URL", $"{url}" }
            };
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestUpdateRecord(Settings.quickLinksTable, id, data);
            bool success = await AwaitResponse();
        }

        private async void DeleteQuickLink(int id)
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestDeleteRecord(Settings.quickLinksTable, id);
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

        // fetch
        private async void RefreshData()
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestData();
            bool success = await AwaitResponse(); // wait for response

            dgvLandlords.DataSource = null;
            dgvTenants.DataSource = null;
            dgvProperties.DataSource = null;
            dgvMaintenances.DataSource = null;
            dgvQuickLinks.DataSource = null;
            dgvRents.DataSource = null;

            dgvLandlords.DataSource = Global.Landlords?.GetAll();
            dgvTenants.DataSource = Global.Tenants?.GetAll();
            dgvProperties.DataSource = Global.Properties?.GetAll();
            dgvMaintenances.DataSource = Global.Maintenances?.GetAll();
            dgvQuickLinks.DataSource = Global.QuickLinks?.GetAll();
            dgvRents.DataSource = Global.Rents?.GetAll();
        }

        private void btnUserRefresh_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void btnLandlordRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnTenantRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnPropertyRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnQuickLinkRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnMaintenanceRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnRentRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        // users

        private async void btnUserCreate_Click(object sender, EventArgs e)
        {
            string username = txtbxUsername.Text.Trim();
            string password = txtbxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CreateUser(username, password, cmbobxUserRoles.Text);
            await Task.Delay(500);
            RefreshUsers();
            txtbxUsername.Text = "";
            txtbxPassword.Text = "";
        }

        private async void btnUserUpdatePass_Click(object sender, EventArgs e)
        {
            string password = txtbxPassword.Text.Trim();
            string username = dgvUsers.SelectedRows[0].Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString().Trim();

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update password for the account '{username}' to '{password}'?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdatePassword(username, txtbxPassword.Text);
                await Task.Delay(500);
                RefreshUsers();
                txtbxPassword.Text = "";
            }
        }

        private async void btnUserDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string username = dgvUsers.SelectedRows[0].Cells["usernameDataGridViewTextBoxColumn"].Value?.ToString().Trim();
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the account '{username}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteUser(username);
                    await Task.Delay(500);
                    RefreshUsers();
                }
            }
        }

        // landlords
        private bool CheckLandlordFields()
        {
            if (string.IsNullOrEmpty(txtbxllFName.Text.Trim()))
            {
                MessageBox.Show("First Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtbxllLName.Text.Trim()))
            {
                MessageBox.Show("Last Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtbxllAddress.Text.Trim()))
            {
                MessageBox.Show("Address is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private async void btnllCreate_Click(object sender, EventArgs e)
        {
            if (!CheckLandlordFields()) return;

            string fName = txtbxllFName.Text.Trim();
            string lName = txtbxllLName.Text.Trim();
            string address = txtbxllAddress.Text.Trim();
            string phone = txtbxllPhone.Text.Trim();
            string email = txtbxllEmail.Text.Trim();
            string notes = rchtxtbxllNotes.Text.Trim();


            CreateLandlord(fName, lName, address, phone, email, notes);
            await Task.Delay(500);
            RefreshData();

            txtbxllFName.Text = "";
            txtbxllLName.Text = "";
            txtbxllAddress.Text = "";
            txtbxllPhone.Text = "";
            txtbxllEmail.Text = "";
            rchtxtbxllNotes.Text = "";
        }

        private async void btnllUpdate_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dgvLandlords.SelectedRows[0].Cells["landlordIdDataGridViewTextBoxColumn"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a landlord to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckLandlordFields()) return;

            string fName = txtbxllFName.Text.Trim();
            string lName = txtbxllLName.Text.Trim();
            string address = txtbxllAddress.Text.Trim();
            string phone = txtbxllPhone.Text.Trim();
            string email = txtbxllEmail.Text.Trim();
            string notes = rchtxtbxllNotes.Text.Trim();


            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update details for selected landlord? (Landlord ID: '{id}')",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdateLandlord(id, fName, lName, address, phone, email, notes);
                await Task.Delay(500);
                RefreshData();

                txtbxllFName.Text = "";
                txtbxllLName.Text = "";
                txtbxllAddress.Text = "";
                txtbxllPhone.Text = "";
                txtbxllEmail.Text = "";
                rchtxtbxllNotes.Text = "";
            }
        }

        private async void btnllDelete_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dgvLandlords.SelectedRows[0].Cells["landlordIdDataGridViewTextBoxColumn"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a landlord to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete selected landlord? (Landlord ID: '{id}')",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteLandlord(id);
                await Task.Delay(500);
                RefreshData();
            }
        }

        // tenants

        private bool CheckTenantFields()
        {
            if (string.IsNullOrEmpty(txtbxtFName.Text.Trim()))
            {
                MessageBox.Show("First Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtbxtLName.Text.Trim()))
            {
                MessageBox.Show("Last Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private async void btnTenantCreate_Click(object sender, EventArgs e)
        {
            if (!CheckTenantFields()) return;

            string fName = txtbxtFName.Text.Trim();
            string lName = txtbxtLName.Text.Trim();
            string phone = txtbxtPhone.Text.Trim();
            string email = txtbxtEmail.Text.Trim();
            string notes = rchtxtbxtNotes.Text.Trim();

            CreateTenant(fName, lName, phone, email, notes);
            await Task.Delay(500);
            RefreshData();

            txtbxtFName.Text = "";
            txtbxtLName.Text = "";
            txtbxtPhone.Text = "";
            txtbxtEmail.Text = "";
            rchtxtbxtNotes.Text = "";
        }

        private async void btnTenantUpdate_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dgvTenants.SelectedRows[0].Cells["TenantId"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a tenant to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckTenantFields()) return;

            string fName = txtbxtFName.Text.Trim();
            string lName = txtbxtLName.Text.Trim();
            string phone = txtbxtPhone.Text.Trim();
            string email = txtbxtEmail.Text.Trim();
            string notes = rchtxtbxtNotes.Text.Trim();

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update selected tenant? (Tenant ID: '{id}')",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdateTenant(id, fName, lName, phone, email, notes);
                await Task.Delay(500);
                RefreshData();

                txtbxtFName.Text = "";
                txtbxtLName.Text = "";
                txtbxtPhone.Text = "";
                txtbxtEmail.Text = "";
                rchtxtbxtNotes.Text = "";
            }
        }

        private async void btnTenantDelete_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dgvTenants.SelectedRows[0].Cells["TenantId"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a tenant to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete selected tenant? (Tenant ID: '{id}')",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteTenant(id);
                await Task.Delay(500);
                RefreshData();
            }
        }

        // properties


    }
}
