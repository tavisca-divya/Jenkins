using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Subscriber
    {
        public ObjectId _id;
        public string UserName { get; set; }
        public string password { get; set; }
        public int UnreadCount = 0;
    }
}
