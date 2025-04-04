using System.Text.Json;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace iLet4You
{
    public class Server
    {
        public WebSocket ws;
        public bool IsLoggedIn = false;

        public Server(string ip, string port)
        {
            ws = new WebSocket($"ws://{ip}:{port}");

            // setting event handlers
            ws.OnOpen += Ws_OnOpen;
            ws.OnMessage += Ws_OnMessage;
            ws.OnError += Ws_OnError;
            ws.OnClose += Ws_OnClose;

            // open the WebSocket connection
            ws.Connect();
        }

        // when connection is opened
        private void Ws_OnOpen(object sender, EventArgs e)
        {

        }

        // server resonses / updates (runs every time a server sends message)
        private async void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                // parse JSON message
                JObject json = JObject.Parse(e.Data);

                // extract type and data
                string type = json["type"]?.ToString();
                JToken data = json["data"];

                switch (type)
                {
                    case "login_success":
                        IsLoggedIn = true;
                        iLet4You.Login.ResultReceived(true);

                        string role = data["role"]?.ToString();
                        string username = data["username"]?.ToString();
                        Global.User = new User(username, role);

                        // MessageBox.Show($"Login Successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "login_failed":
                        iLet4You.Login.ResultReceived(false);
                        MessageBox.Show("Login Failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case "landlords_data":
                        HandleLandlordsData(data);
                        AdminPanel.ResultReceived(true);
                        break;

                    case "tenants_data":
                        HandleTenantsData(data);
                        AdminPanel.ResultReceived(true);
                        break;

                    case "properties_data":
                        HandlePropertiesData(data);
                        AdminPanel.ResultReceived(true);
                        break;

                    case "maintenances_data":
                        HandleMaintenancesData(data);
                        AdminPanel.ResultReceived(true);
                        break;

                    case "quicklinks_data":
                        HandleQuickLinksData(data);
                        AdminPanel.ResultReceived(true);
                        break;

                    case "rents_data":
                        HandleRentsData(data);
                        AdminPanel.ResultReceived(true);
                        break;

                    case "record_created":
                        MessageBox.Show("Record created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "record_updated":
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "record_deleted":
                        MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "users_data":
                        HandleUsersData(data);
                        AdminPanel.ResultReceived(true);
                        break;

                    case "delete_account_success":
                        AdminPanel.ResultReceived(true);
                        break;

                    case "create_account_success":
                        AdminPanel.ResultReceived(true);
                        break;

                    case "update_password_success":
                        AdminPanel.ResultReceived(true);
                        break;

                    case "create_success":
                        // HANDLE CREATE RECORD SUCCESS? (a MessageBox.Show is enough?)
                        break;

                    case "update_success":
                        // HANDLE UPDATE RECORD SUCCESS? (a MessageBox.Show is enough?)
                        break;
                    
                    case "delete_success":
                        // HANDLE DELETE RECORD SUCCESS? (a MessageBox.Show is enough?)
                        break;

                    case "error":
                        string errorMessage = data["message"]?.ToString();
                        MessageBox.Show($"Error: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        // Console.WriteLine($"Unknown message type: {type}");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"Error processing WebSocket message: {ex.Message}");
            }
        }

        // errors
        private void Ws_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {

        }

        // when connection is closed
        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            // open login page again (and close everything else)? idk
        }

        // hashing

        public string GenerateHash(string input)
        {
            if (input == null || input.Length == 0)
                return "";

            MD5 md5 = MD5.Create(); // create md5 instance
            byte[] cool = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input)); // get the bytes and make hash of it

            StringBuilder sb = new StringBuilder(); // making a string from it
            foreach (byte b in cool)
            {
                sb.Append(b.ToString("x2"));
            }

            string hashedpassword = sb.ToString();
            return hashedpassword;
        }

        // login
        public void Login(string username, string password)
        {
            string hashedPassword = GenerateHash(password); // hash the password
            var loginData = new
            {
                action = "login",
                username = username,
                password = hashedPassword
            };

            string jsonMessage = JsonSerializer.Serialize(loginData);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // data
        public void RequestData()
        {
            var request = new
            {
                action = "fetch_data"
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // request server to create a record in db
        public void RequestCreateRecord(string table, Dictionary<string, object> values)
        {
            var request = new
            {
                action = "create",
                table = table,
                values = values
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // request server to update a record
        public void RequestUpdateRecord(string table, int id, Dictionary<string, object> values)
        {
            var request = new
            {
                action = "update",
                table = table,
                id = id,
                values = values
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // request server to delete a record
        public void RequestDeleteRecord(string table, int id)
        {
            var request = new
            {
                action = "delete",
                table = table,
                id = id
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // handle data from server
        private void HandleLandlordsData(JToken data)
        {
            try
            {
                if (data == null || !data.HasValues)
                {
                    MessageBox.Show("Received empty or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Landlord> landlordList = new();

                foreach (var landlord in data)
                {
                    int LandlordID = landlord["LandlordID"] != null && landlord["LandlordID"].Type != JTokenType.Null
                        ? landlord["LandlordID"].Value<int>() : -1; // -1 if somehow no Landlord ID

                    string FirstName = landlord["FirstName"]?.ToString() ?? "Unknown";
                    string LastName = landlord["LastName"]?.ToString() ?? "Unknown";
                    string Address = landlord["Address"]?.ToString() ?? "Unknown";
                    string PhoneNumber = landlord["PhoneNumber"]?.ToString() ?? "Unknown";
                    string Email = landlord["Email"]?.ToString() ?? "Unknown";
                    string Notes = landlord["Notes"]?.ToString() ?? "Unknown";

                    landlordList.Add(new Landlord(LandlordID, FirstName, LastName, Address, PhoneNumber, Email, Notes));
                }

                Global.Landlords = new Landlords(landlordList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing landlord data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleTenantsData(JToken data)
        {
            try
            {
                if (data == null || !data.HasValues)
                {
                    MessageBox.Show("Received empty or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Tenant> tenantList = new();

                foreach (var tenant in data)
                {
                    int TenantID = tenant["TenantID"] != null && tenant["TenantID"].Type != JTokenType.Null
                        ? tenant["TenantID"].Value<int>() : -1;

                    string FirstName = tenant["FirstName"]?.ToString() ?? "Unknown";
                    string LastName = tenant["LastName"]?.ToString() ?? "Unknown";
                    string HouseNo = tenant["HouseNo"]?.ToString() ?? "Unknown";
                    string AddressLine1 = tenant["AddressLine1"]?.ToString() ?? "Unknown";
                    string City = tenant["City"]?.ToString() ?? "Unknown";
                    string PostCode = tenant["PostCode"]?.ToString() ?? "Unknown";
                    string PhoneNumber = tenant["PhoneNumber"]?.ToString() ?? "Unknown";
                    string Email = tenant["Email"]?.ToString() ?? "Unknown";
                    string Notes = tenant["Notes"]?.ToString() ?? "Unknown";

                    tenantList.Add(new Tenant(TenantID, FirstName, LastName, HouseNo, AddressLine1, City, PostCode, PhoneNumber, Email, Notes));
                }

                Global.Tenants = new Tenants(tenantList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing tenant data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandlePropertiesData(JToken data)
        {
            try
            {
                if (data == null || !data.HasValues)
                {
                    MessageBox.Show("Received empty or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Property> propertyList = new();

                foreach (var property in data)
                {
                    int PropertyID = property["PropertyID"] != null && property["PropertyID"].Type != JTokenType.Null
                        ? property["PropertyID"].Value<int>() : -1;

                    int LandlordID = property["LandlordID"] != null && property["LandlordID"].Type != JTokenType.Null
                        ? property["LandlordID"].Value<int>() : -1;
                    int TenantID = property["TenantID"] != null && property["TenantID"].Type != JTokenType.Null
                        ? property["TenantID"].Value<int>() : -1;

                    string AddressLine1 = property["AddressLine1"]?.ToString() ?? "Unknown";
                    string City = property["City"]?.ToString() ?? "Unknown";
                    string PostCode = property["PostCode"]?.ToString() ?? "Unknown";

                    double RentAmount = property["RentAmount"] != null &&
                        double.TryParse(property["RentAmount"].ToString(), out double rent) ? rent : 0.0;
                    DateTime? GasCertExpiry = property["GasCertExpiry"] != null &&
                        DateTime.TryParse(property["GasCertExpiry"].ToString(), out DateTime gasExpiry) ? gasExpiry : null;
                    DateTime? EPCExpiry = property["EPCExpiry"] != null &&
                        DateTime.TryParse(property["EPCExpiry"].ToString(), out DateTime epcExpiry) ? epcExpiry : null;
                    DateTime? EICRExpiry = property["EICRExpiry"] != null &&
                        DateTime.TryParse(property["EICRExpiry"].ToString(), out DateTime eicrExpiry) ? eicrExpiry : null;
                    string EPCRating = property["EPCRating"]?.ToString() ?? "Unknown";
                    string Notes = property["Notes"]?.ToString() ?? "Unknown";

                    propertyList.Add(new Property(PropertyID, LandlordID, TenantID, AddressLine1, City, PostCode, RentAmount, GasCertExpiry, EPCExpiry, EICRExpiry, EPCRating, Notes));
                }

                Global.Properties = new Properties(propertyList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing property data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleMaintenancesData(JToken data)
        {
            try
            {
                if (data == null || !data.HasValues)
                {
                    MessageBox.Show("Received empty or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Maintenance> maintenanceList = new();

                foreach (var maintenance in data)
                {
                    int MaintenanceID = maintenance["MaintenanceID"] != null && maintenance["MaintenanceID"].Type != JTokenType.Null
                        ? maintenance["MaintenanceID"].Value<int>() : -1;

                    int PropertyID = maintenance["PropertyID"] != null && maintenance["PropertyID"].Type != JTokenType.Null
                        ? maintenance["PropertyID"].Value<int>() : -1;

                    string Description = maintenance["Description"]?.ToString() ?? "Unknown";
                    string Status = maintenance["Status"]?.ToString() ?? "Unknown";

                    DateTime DateReported = maintenance["DateReported"] != null &&
                        DateTime.TryParse(maintenance["DateReported"].ToString(), out DateTime dateReported) ? dateReported : default;
                    DateTime? DateCompleted = maintenance["DateCompleted"] != null &&
                        DateTime.TryParse(maintenance["DateCompleted"].ToString(), out DateTime dateCompleted) ? dateCompleted : null;

                    maintenanceList.Add(new Maintenance(MaintenanceID, PropertyID, Description, Status, DateReported, DateCompleted));
                }

                Global.Maintenances = new Maintenances(maintenanceList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing maintenance data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleQuickLinksData(JToken data)
        {
            try
            {
                if (data == null || !data.HasValues)
                {
                    MessageBox.Show("Received empty or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<QuickLink> quickLinkList = new();

                foreach (var quickLink in data)
                {
                    int QuickLinkID = quickLink["QuickLinkID"] != null && quickLink["QuickLinkID"].Type != JTokenType.Null
                        ? quickLink["QuickLinkID"].Value<int>() : -1;

                    string Name = quickLink["Name"]?.ToString() ?? "Unknown";
                    string URL = quickLink["URL"]?.ToString() ?? "Unknown";

                    quickLinkList.Add(new QuickLink(QuickLinkID, Name, URL));
                }

                Global.QuickLinks = new QuickLinks(quickLinkList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing quick link data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleRentsData(JToken data)
        {
            try
            {
                if (data == null || !data.HasValues)
                {
                    MessageBox.Show("Received empty or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Rent> rentList = new();

                foreach (var rent in data)
                {
                    int RentID = rent["RentID"] != null && rent["RentID"].Type != JTokenType.Null
                        ? rent["RentID"].Value<int>() : -1;

                    int? TenantID = rent["TenantID"]?.Value<int?>();
                    int? PropertyID = rent["PropertyID"]?.Value<int?>();

                    DateTime DueDate = rent["DueDate"] != null &&
                        DateTime.TryParse(rent["DueDate"].ToString(), out DateTime dueDate) ? dueDate : default;
                    DateTime? DateReceived = DateTime.TryParse(
                        rent["DateReceived"]?.ToString(), out DateTime dateReceived) ? dateReceived : null;

                    int RentAmount = rent["RentAmount"] != null && rent["RentAmount"].Type != JTokenType.Null
                        ? rent["RentAmount"].Value<int>() : 0;
                    int RentAmountPaid = rent["RentAmountPaid"] != null && rent["RentAmountPaid"].Type != JTokenType.Null
                        ? rent["RentAmountPaid"].Value<int>() : 0;

                    string Notes = rent["Notes"]?.ToString();

                    rentList.Add(new Rent(RentID, PropertyID, TenantID, DueDate, DateReceived, RentAmount, RentAmountPaid, Notes));
                }

                Global.Rents = new Rents(rentList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing rent data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // for admins
        public void RequestUsers()
        {
            var request = new
            {
                action = "get_users"
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleUsersData(JToken data)
        {
            try
            {
                if (data == null || !data.HasValues)
                {
                    MessageBox.Show("Received empty or invalid user data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<User> userList = new();

                foreach (var user in data)
                {
                    string username = user["Username"]?.ToString() ?? "Unknown";
                    string role = user["Role"]?.ToString() ?? "Unknown";

                    userList.Add(new User(username, role));
                }

                Global.Users = new Users(userList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RequestDeleteUser(string username)
        {
            var request = new
            {
                action = "delete_account",
                username = username
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RequestCreateUser(string username, string password, string role)
        {
            string hashedPassword = GenerateHash(password);
            var request = new
            {
                action = "create_account",
                username = username,
                password = hashedPassword,
                role = role
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RequestUpdatePassword(string username, string password)
        {
            string hashedPassword = GenerateHash(password);
            var request = new
            {
                action = "update_password",
                username = username,
                password = hashedPassword,
            };

            string jsonMessage = JsonSerializer.Serialize(request);

            try
            {
                ws.Send(jsonMessage);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}