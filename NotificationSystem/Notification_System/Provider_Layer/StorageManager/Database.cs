using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using Provider_Layer.StorageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Provider_Layer.StorageManager
{
    public class Database : IPublisher, ISubscriber
    {
        IMongoCollection<Subscriber> subData;
        IMongoCollection<Model.Publisher> pubData;
        public Database()
        {
            subData = new MongoClient().GetDatabase("SubData").GetCollection<Subscriber>("SubscriberCollection");
            pubData = new MongoClient().GetDatabase("PubData").GetCollection<Model.Publisher>("PublisherCollection");

        }

        public Publisher Save_Notification(string id, Model.Publisher notification)
        {
            notification.TimeStamp = DateTime.Now;
            pubData.InsertOne(notification);
            UpdateNotificationCount();
            return notification;
        }

        public bool UpdateNotificationCount()
        {
            var builder = Builders<Subscriber>.Update.Inc("UnreadCount", 1);
            var update = new UpdateOptions { IsUpsert = true };
            var isUpdated = subData.UpdateMany<Subscriber>(x => x._id != null, builder, update);
            if (isUpdated.ModifiedCount > 0)
                return true;
            return false;
        }

        public Subscriber create_Subscriber(string name, string password, Subscriber subscriber)
        {
            subData.InsertOne(subscriber);
            return subscriber;
        }

        public bool validate_user(string name, string password)
        {

            var result = subData.Find(x => x.UserName == name && x.password == password).Count();
            if (result != 0)
                return true;
            else
                return false;
        }

        public List<Publisher> GetNotifications()
        {
            var result = pubData.Find(x => x._id != null).ToList();
            result.Reverse();
            return result;
        }

        public int GetNotificationCount(string UserName)
        {
            var sub = subData.Find(x => x.UserName == UserName).Single();
            int count = sub.UnreadCount;
            return count;
        }

        public bool ResetUnreadCount(string UserName)
        {
            var filter = Builders<Subscriber>.Filter.Where(x => x.UserName == UserName);
            var update = Builders<Subscriber>.Update.Set("UnreadCount", 0);
            subData.UpdateOne(filter, update);
            return true;
        }
    }
}
