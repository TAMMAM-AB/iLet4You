using iLet4You;

public static class Global
{
    public static Server Server = new Server(Settings.ip, Settings.port);
    public static User? User { get; set; }  // nullable because user starts as null
    public static Users? Users { get; set; } // admins only can get users


}