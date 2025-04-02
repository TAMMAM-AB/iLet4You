using System.Text.Json;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iLet4You
{
    public class Server
    {
        // server related
        public WebSocket ws;

        // login related
        public bool IsLoggedIn = false;
        public bool receivedResponce = false;

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
                        receivedResponce = true;

                        string role = data["role"]?.ToString();
                        string username = data["username"]?.ToString();

                        Global.User = new User(username, role);

                        MessageBox.Show($"Login Successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "login_failed":
                        receivedResponce = true;
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
                receivedResponce = false; // reset here instead of in UI
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
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleUsersData(JToken data)
        {
            List<User> userList = data.ToObject<List<User>>();
            Global.Users = new Users(userList); // store in global users collection
            MessageBox.Show($"Users received: {userList.Count}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}