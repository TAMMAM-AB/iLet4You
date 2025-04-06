using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iLet4You
{
    public partial class QuickLinksManager : Form
    {
        public static QuickLinksManager? Instance { get; private set; }
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

        public QuickLinksManager()
        {
            InitializeComponent();

            RefreshData();
        }

        private async void RefreshData()
        {
            result = new TaskCompletionSource<bool>();
            Global.Server.RequestData();
            bool success = await AwaitResponse(); // wait for response
            dgvQuickLinks.DataSource = null;

            dgvQuickLinks.DataSource = Global.QuickLinks?.GetAll();
        }

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

        // buttons
        private void btnQuickLinkRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtbxName.Text) || String.IsNullOrWhiteSpace(txtbxURL.Text)) {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CreateQuickLink(txtbxName.Text.Trim(), txtbxURL.Text.Trim());
            await Task.Delay(500);
            RefreshData();
            txtbxName.Text = "";
            txtbxURL.Text = "";
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtbxName.Text) || String.IsNullOrWhiteSpace(txtbxURL.Text)) {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id;
            try
            {
                id = Convert.ToInt32(dgvQuickLinks.SelectedRows[0].Cells["quickLinkIdDataGridViewTextBoxColumn"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a quick link to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to update selected quick link? (ID: '{id}')",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdateQuickLink(id, txtbxName.Text.Trim(), txtbxURL.Text.Trim());
                await Task.Delay(500);
                RefreshData();
                txtbxName.Text = "";
                txtbxURL.Text = "";
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dgvQuickLinks.SelectedRows[0].Cells["quickLinkIdDataGridViewTextBoxColumn"].Value.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Please select a quick link to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete selected quick link? (ID: '{id}')",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteQuickLink(id);
                await Task.Delay(500);
                RefreshData();
                txtbxName.Text = "";
                txtbxURL.Text = "";
            }
        }
    }
}
