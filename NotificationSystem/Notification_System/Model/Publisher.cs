using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Publisher
    {
        public string Notification { get; set; }
        public DateTime TimeStamp { get; set; }
        public ObjectId _id { get; set; }
    }
}
