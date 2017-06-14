using BusinessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Runtime.Serialization;
using Provider_Layer.StorageLogic;
using Provider_Layer.StorageManager;
using MongoDB.Bson;

namespace BusinessLayer.BusinessImplementation
{
    public class PublisherManager : IPublisherManager
    {
        IPublisher _publisher;

        public PublisherManager(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public Publisher Save_Notification(string id, Publisher notification)
        {
            _publisher.Save_Notification(id, notification);
            return notification;
        }
    }
}
