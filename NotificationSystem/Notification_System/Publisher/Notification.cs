using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    public class Notification
    {
        public string NotificationId { get; set; }
        public string message { get; set; }
    }
}
