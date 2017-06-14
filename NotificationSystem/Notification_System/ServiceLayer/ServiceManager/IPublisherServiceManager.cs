using MongoDB.Bson;
using ServiceLayer.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceManager
{
    public interface IPublisherServiceManager
    {
        Publisher Save_Notification(string id, Publisher notification);
    }
}
