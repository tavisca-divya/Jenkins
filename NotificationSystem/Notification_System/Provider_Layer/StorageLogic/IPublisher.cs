using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Provider_Layer.StorageLogic
{
    public interface IPublisher
    {
        Publisher Save_Notification(string id, Model.Publisher notification);
    }
}
