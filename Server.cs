using System.Text.Json;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;

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

                        MessageBox.Show($"Login Successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "login_failed":
                        iLet4You.Login.ResultReceived(false);
                        MessageBox.Show("Login Failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case "landlords_data":
                        AdminPanel.ResultReceived(true);
                        HandleLandlordsData(data);
                        break;

                    case "tenants_data":
                        AdminPanel.ResultReceived(true);
                        HandleTenantsData(data);
                        break;

                    case "properties_data":
                        AdminPanel.ResultReceived(true);
                        HandlePropertiesData(data);
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
                        AdminPanel.ResultReceived(true);
                        HandleUsersData(data);
                        break;

                    case "delete_account_success":
                        AdminPanel.ResultReceived(true);
                        break;

                    case "create_account_success":
                        AdminPanel.ResultReceived(true);
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

        // login
        public void Login(string username, string password)
        {
            var loginData = new
            {
                action = "login",
                username = username,
                password = password
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
                    string PhoneNumber = landlord["Address"]?.ToString() ?? "Unknown";
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
                    int tenantID = tenant["TenantID"] != null && tenant["TenantID"].Type != JTokenType.Null
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

                    tenantList.Add(new Tenant(tenantID, FirstName, LastName, HouseNo, AddressLine1, City, PostCode, PhoneNumber, Email, Notes));
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
            var request = new
            {
                action = "create_account",
                username = username,
                password = password,
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
    }
}