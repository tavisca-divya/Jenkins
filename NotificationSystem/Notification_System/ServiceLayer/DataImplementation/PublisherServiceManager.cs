using ServiceLayer.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.DataContract;
using System.Runtime.Serialization;
using BusinessLayer.BusinessLogic;
using ServiceLayer.Translators;
using BusinessLayer.BusinessImplementation;
using MongoDB.Bson;

namespace ServiceLayer.DataImplementation
{
    public class PublisherServiceManager : IPublisherServiceManager
    {
        IPublisherManager _manager;
        public PublisherServiceManager(IPublisherManager manager)
        {
            _manager = manager;
        }
        public Publisher Save_Notification(string id, Publisher notification)
        {
            var result = _manager.Save_Notification(id, notification.DataContractToModel());
            return notification;
        }
    }
}
