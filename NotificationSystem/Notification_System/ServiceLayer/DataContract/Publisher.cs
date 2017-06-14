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
    public class Publisher
    {

        [DataMember]
        public string NotificationId { get; set; }
        [DataMember]
        public string Notification { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }

    }
}
