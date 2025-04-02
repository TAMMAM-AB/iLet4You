using System.Text.Json;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iLet4You
{
    public class Server
    {
        public WebSocket ws;
        public bool IsLoggedIn = false;
        public bool receivedResponse = false;

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
                        receivedResponse = true;

                        string role = data["role"]?.ToString();
                        string username = data["username"]?.ToString();

                        Global.User = new User(username, role);

                        MessageBox.Show($"Login Successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "login_failed":
                        receivedResponse = true;
                        MessageBox.Show("Login Failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case "landlords_data":
                        // HandleLandlordsData(data);
                        break;

                    case "tenants_data":
                        // HandleTenantsData(data);
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

        public async Task AwaitResponse()
        {
            // wait for server response with a timeout
            int timeoutMs = 5000; // 5 seconds max
            int intervalMs = 100;
            int waited = 0;

            while (!Global.Server.receivedResponse && waited < timeoutMs)
            {
                await Task.Delay(intervalMs);
                waited += intervalMs;
            }

            if (!Global.Server.receivedResponse)
            {
                MessageBox.Show("Failed to connect to the server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

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
                receivedResponse = false; // reset here
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // admin
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
                receivedResponse = false;
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
    }
}