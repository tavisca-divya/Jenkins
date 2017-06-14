using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSender
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53093/");
            bool conti = true;
            while (conti)
            {
                Publisher notification = new Publisher();
                notification.Notification = Console.ReadLine();
                client.PostAsJsonAsync("api/notification/post", notification);
                Console.WriteLine("Do you wish to continue? (Y/N)");
                var result = Console.ReadLine();
                if (result.ToUpper() == "N")
                    conti = false;

            }
            
        }
    }
}
