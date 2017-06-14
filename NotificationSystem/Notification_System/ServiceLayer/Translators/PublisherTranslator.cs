using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Translators
{
    public static class PublisherTranslator
    {
        public static ServiceLayer.DataContract.Publisher ModelToDataContract(this Publisher publisher)
        {
            return new DataContract.Publisher
            {
                Notification = publisher.Notification,
                TimeStamp = DateTime.Now
            };
        }

        public static Publisher DataContractToModel(this ServiceLayer.DataContract.Publisher publisher)
        {
            return new Publisher
            {
                Notification = publisher.Notification,
                TimeStamp = DateTime.Now
            };
        }
    }
}
