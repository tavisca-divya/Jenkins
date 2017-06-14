using BusinessLayer.BusinessLogic;
using Model;
using MongoDB.Bson;
using Provider_Layer.StorageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessImplementation
{
    public class SubscriberManager : ISubscriberManager
    {
        ISubscriber _manager;
        public SubscriberManager(ISubscriber manager)
        {
            _manager = manager;
        }
        public Subscriber create_Subscriber(string name, string password, Subscriber subscriber)
        {
            var result = _manager.create_Subscriber(name, password, subscriber);
            return subscriber;
        }

        public int GetNotificationCount(string UserName)
        {
            return _manager.GetNotificationCount(UserName);
        }

        public List<Publisher> GetNotifications()
        {
            List<Publisher> result = _manager.GetNotifications();
            return result;
        }

        public bool ResetUnreadCount(string UserName)
        {
            return _manager.ResetUnreadCount(UserName);
        }

        public bool validate_user(string name, string password)
        {
            return _manager.validate_user(name, password);
        }
    }
}
