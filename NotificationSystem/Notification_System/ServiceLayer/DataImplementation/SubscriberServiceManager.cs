using BusinessLayer.BusinessLogic;
using ServiceLayer.DataContract;
using ServiceLayer.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Translators;
using MongoDB.Bson;

namespace ServiceLayer.DataImplementation
{
    public class SubscriberServiceManager : ISubscriberServiceManager
    {
        ISubscriberManager _manager;
        public SubscriberServiceManager(ISubscriberManager manager)
        {
            _manager = manager;
        }
        public Subscriber create_Subscriber(string name, string password, Subscriber subscriber)
        {
            var value = subscriber.DataContractToModel();
            var result = _manager.create_Subscriber(name, password, value);
            return subscriber;
        }

        public int GetNotificationCount(string UserName)
        {
            return _manager.GetNotificationCount(UserName);
        }

        public List<Publisher> GetNotifications()
        {
            var listOfPublishers = new List<DataContract.Publisher>();
            var result = _manager.GetNotifications();
            foreach (var publishers in result)
            {
                listOfPublishers.Add(publishers.ModelToDataContract());
            }
            return listOfPublishers;
        }

        public bool ResetUnreadCount(string UserName)
        {
            return _manager.ResetUnreadCount(UserName);
        }

        public bool validate_user(string name, string password)
        {
            var result = _manager.validate_user(name, password);
            return result;
        }
    }
}
