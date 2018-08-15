using System;

namespace KDRSManager.Models
{
    public class Server
    {
        public Server(string srv, int user, string pw)
        {
            UserID = user;
            Adress = srv;
            Password = pw;
        }

        public int UserID { get; set; }
        public String Adress { get; set; }
        public String Password { get; set; }
    }
}