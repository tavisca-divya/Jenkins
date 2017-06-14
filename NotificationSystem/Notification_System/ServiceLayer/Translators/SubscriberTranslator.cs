using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Translators
{
    public static class SubscriberTranslator
    {
        public static ServiceLayer.DataContract.Subscriber ModelToDataContract(this Subscriber subscriber)
        {
            return new ServiceLayer.DataContract.Subscriber
            {

                UserName = subscriber.UserName,
                password = subscriber.password,
                UnreadCount = subscriber.UnreadCount
            };
        }
        public static Subscriber DataContractToModel(this ServiceLayer.DataContract.Subscriber subscriber)
        {
            return new Subscriber
            {

                UserName = subscriber.UserName,
                password = subscriber.password,
                UnreadCount = subscriber.UnreadCount
            };
        }
    }
}
