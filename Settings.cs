using System.Text.Json;

public static class Settings
{
    // server
    public static string ip = "127.0.0.1";
    public static string port = "8080";

    public static string landlordsTable = "Landlords";
    public static string maintenancesTable = "Maintenances";
    public static string propertiesTable = "Properties";
    public static string quickLinksTable = "QuickLinks";
    public static string rentsTable = "Rents";
    public static string tenantsTable = "Tenants";


    private class ConfigData
    {
        public string? ip { get; set; }
        public string? port { get; set; }
    }

    public static void Load(string filePath = "config.json")
    {
        if (!File.Exists(filePath))
        {
            var defaultConfig = new ConfigData { ip = ip, port = port };
            File.WriteAllText(filePath, JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true }));
            return;
        }

        try
        {
            string json = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<ConfigData>(json);

            if (!string.IsNullOrEmpty(config?.ip)) ip = config.ip;
            if (!string.IsNullOrEmpty(config?.port)) port = config.port;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load config: {ex.Message}");
        }
    }
}