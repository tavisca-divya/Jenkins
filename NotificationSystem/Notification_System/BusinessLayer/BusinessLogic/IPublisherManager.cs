using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessLogic
{
    public interface IPublisherManager
    {
        Publisher Save_Notification(string id, Publisher notification);

    }
}
