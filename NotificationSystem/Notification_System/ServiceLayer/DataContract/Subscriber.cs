using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataContract
{
    [DataContract]
    public class Subscriber
    {
        [DataMember]
        public ObjectId _id;
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public int UnreadCount = 0;
    }
}
