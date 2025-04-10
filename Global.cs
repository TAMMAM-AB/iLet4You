using iLet4You;

public static class Global
{
    public static Server Server = new Server(Settings.ip, Settings.port);
    public static User? User { get; set; }  // nullable because user starts as null
    public static Users? Users { get; set; } // only admins can get users
    public static Landlords? Landlords { get; set; }
    public static Tenants? Tenants { get; set; }
    public static Properties? Properties { get; set; }
    public static Maintenances? Maintenances { get; set; }
    public static QuickLinks? QuickLinks { get; set; }
    public static Rents? Rents { get; set; }
}