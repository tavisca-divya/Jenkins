using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using BusinessLayer.BusinessLogic;
using Provider_Layer.StorageManager;
using System.Runtime.Serialization;
using ServiceLayer.DataImplementation;
using BusinessLayer.BusinessImplementation;
using Provider_Layer.StorageLogic;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Notification_System.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void check_if_data_is_sent_to_database()
        {
            Database Db = new Database();
            var target = Db.Save_Notification(It.IsAny<string>() ,new Publisher {Notification="hello"});
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void Test_If_Saving_Notification_In_BusinessLayer()
        {
            Publisher tester = new Publisher {Notification = "Hi" };
            Mock<IPublisher> db = new Mock<IPublisher>();
            db.Setup(x => x.Save_Notification("3", new Publisher() { Notification = "Hi" })).Returns(tester);
            PublisherManager businessManager = new PublisherManager(db.Object);
            var target = businessManager.Save_Notification("3", new Publisher() { Notification = "Hi" });
            Assert.IsNotNull(target);
            Assert.AreEqual(tester.Notification, target.Notification);
            Assert.AreEqual(tester._id, target._id);
            Assert.IsInstanceOfType(new Publisher(), target.GetType());       
        }
        [TestMethod]
        public void Fail_Test_If_Saving_Notification_In_BusinessLayer()
        {
            Publisher tester = new Publisher { Notification = "Hello" };
            Mock<IPublisher> db = new Mock<IPublisher>();
            db.Setup(x => x.Save_Notification("3", new Publisher() { Notification = "Hello" })).Returns(tester);
            PublisherManager businessManager = new PublisherManager(db.Object);
            var target = businessManager.Save_Notification("2", new Publisher() { Notification = "Hi" });
            Assert.AreNotEqual(tester.Notification, target.Notification);           
        }

        [TestMethod]
        public void Test_If_Saving_Notification_In_ServiceLayer()
        {
            Publisher tester = new Publisher { Notification = "Hello" };
            Mock<IPublisherManager> businessManager = new Mock<IPublisherManager>();
            businessManager.Setup(x => x.Save_Notification(It.IsAny<string>(), new Publisher { Notification = "Hello" }));
            PublisherServiceManager serviceManager = new PublisherServiceManager(businessManager.Object);
            var target = serviceManager.Save_Notification(It.IsAny<string>(), new ServiceLayer.DataContract.Publisher { Notification = "Hello" });
            Assert.IsNotNull(target);
            Assert.AreEqual(tester.Notification, target.Notification);
        }
        [TestMethod]
        public void Fail_Test_If_Saving_Notification_In_ServiceLayer()
        {
            Publisher tester = new Publisher { Notification = "Hello" };
            Mock<IPublisherManager> businessManager = new Mock<IPublisherManager>();
            businessManager.Setup(x => x.Save_Notification(It.IsAny<string>(), new Publisher { Notification = "Hello" }));
            PublisherServiceManager serviceManager = new PublisherServiceManager(businessManager.Object);
            var target = serviceManager.Save_Notification(It.IsAny<string>(), new ServiceLayer.DataContract.Publisher { Notification = "hello" });
            Assert.IsNotNull(target);
            Assert.AreNotEqual(tester.Notification, target.Notification);
        }

        [TestMethod]
        public void Test_Subscriber_Validation()
        { 
            Database Db = new Database();
            var target = Db.validate_user("Divya", "divya");
            Assert.AreEqual(true, target);
        }

        [TestMethod]
        public void Fail_Test_Subscriber_Validation()
        {

            Database Db = new Database();
            var target = Db.validate_user("abc", "pswrd");
            Assert.AreEqual(false, target);
        }
        [TestMethod]
        public void Test_If_Validating_user_In_BusinessLayer()
        {
            
            Mock<ISubscriber> db = new Mock<ISubscriber>();
            db.Setup(x => x.validate_user("Divya","divya")).Returns(true);
            SubscriberManager businessManager = new SubscriberManager(db.Object);
            var target = businessManager.validate_user("Divya", "divya");
            Assert.AreEqual(true, target);
        }
        
        [TestMethod]
        public void Fail_Test_If_Validating_user_In_BusinessLayer()
        {

            Mock<ISubscriber> db = new Mock<ISubscriber>();
            db.Setup(x => x.validate_user("Divya", "divya"));
            SubscriberManager businessManager = new SubscriberManager(db.Object);
            var target = businessManager.validate_user("divya", "sbrvw");
            Assert.AreEqual(false, target);
        }
        [TestMethod]
        public void Test_If_Validating_user_In_ServiceLayer()
        {

            Mock<ISubscriberManager> businessManager = new Mock<ISubscriberManager>();
            businessManager.Setup(x => x.validate_user("Divya", "divya")).Returns(true);
            SubscriberServiceManager serviceManager = new SubscriberServiceManager(businessManager.Object);
            var target = serviceManager.validate_user("Divya", "divya");
            Assert.AreEqual(true, target);
        }

        [TestMethod]
        public void Fail_Test_If_Validating_user_In_ServiceLayer()
        {

            Mock<ISubscriberManager> businessManager = new Mock<ISubscriberManager>();
            businessManager.Setup(x => x.validate_user("Divya", "divya"));
            SubscriberServiceManager serviceManager = new SubscriberServiceManager(businessManager.Object);
            var target = serviceManager.validate_user("Keep", "calm");
            Assert.AreEqual(false, target);
        }

        [TestMethod]

        public void Test_if_Subscriber_is_created()
        {
            Database Db = new Database();
            var target = Db.create_Subscriber(It.IsAny<string>(), It.IsAny<string>(), new Subscriber());
            Assert.IsNotNull(target);
        }

        [TestMethod]

        public void Test_businesslayer_CreateSubscriber()
        {
            Mock<ISubscriber> db = new Mock<ISubscriber>();
            db.Setup(x => x.create_Subscriber(It.IsAny<string>(), It.IsAny<string>(), new Subscriber { UserName = "hello" }));
            SubscriberManager businessManager = new SubscriberManager(db.Object);
            var target = businessManager.create_Subscriber(It.IsAny<string>(), It.IsAny<string>(), new Subscriber { UserName = "hello" });
            Assert.IsNotNull(target);

        }

        [TestMethod]

        public void Test_servicelayer_CreateSubscriber()
        {
            Mock<ISubscriberManager> businessManager = new Mock<ISubscriberManager>();
            businessManager.Setup(x => x.create_Subscriber(It.IsAny<string>(), It.IsAny<string>(), new Subscriber { UserName = "hello" }));
            SubscriberServiceManager serviceManager = new SubscriberServiceManager(businessManager.Object);
            var target = serviceManager.create_Subscriber(It.IsAny<string>(), It.IsAny<string>(), new ServiceLayer.DataContract.Subscriber { UserName = "hello" });
            Assert.IsNotNull(target);

        }

        [TestMethod]

        public void Test_To_Get_Notifications_List()
        {
            Database Db = new Database();
            var target = Db.GetNotifications();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(new List<Publisher>(), target.GetType());
        }

        [TestMethod]

        public void Test_BusinessLayer_To_Get_Notifications_List()
        {
            Mock<ISubscriber> db = new Mock<ISubscriber>();
            db.Setup(x => x.GetNotifications()).Returns(new List<Publisher>());
            SubscriberManager businessManager = new SubscriberManager(db.Object);
            var target = businessManager.GetNotifications();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(new List<Publisher>(), target.GetType());
        }
        [TestMethod]

        public void Test_ServiceLayer_To_Get_Notifications_List()
        {
            Mock<ISubscriberManager> businessManager = new Mock<ISubscriberManager>();
            businessManager.Setup(x => x.GetNotifications()).Returns(new List<Publisher>());
            SubscriberServiceManager serviceManager = new SubscriberServiceManager(businessManager.Object);
            var target = serviceManager.GetNotifications();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(new List<ServiceLayer.DataContract.Publisher>(), target.GetType());

        }

        [TestMethod]

        public void Test_Notification_count()
        {
            
            Database Db = new Database();
            var target = Db.GetNotificationCount("Divya");
            Assert.IsNotNull(target);
        }

        [TestMethod]

        public void Test_BusinessLayer_To_Get_Notification_count()
        {

            Mock<ISubscriber> db = new Mock<ISubscriber>();
            db.Setup(x => x.GetNotificationCount("Divya")).Returns(It.IsAny<int>());
            SubscriberManager businessManager = new SubscriberManager(db.Object);
            var target = businessManager.GetNotificationCount("Divya");
            Assert.IsNotNull(target);
        }

        [TestMethod]

        public void Test_ServiceLayer_To_Get_Notification_Count()
        {
            Mock<ISubscriberManager> businessManager = new Mock<ISubscriberManager>();
            businessManager.Setup(x => x.GetNotificationCount("Divya")).Returns(It.IsAny<int>());
            SubscriberServiceManager serviceManager = new SubscriberServiceManager(businessManager.Object);
            var target = serviceManager.GetNotificationCount("Divya");
            Assert.IsNotNull(target);
        }

        [TestMethod]

        public void Test_If_UnreadCount_resets()
        {
            Database Db = new Database();
            var target = Db.ResetUnreadCount("Divya");
            Assert.AreEqual(true, target);
        }

        [TestMethod]

        public void Test_BusinessLayer_To_Reset_Unread_count()
        {

            Mock<ISubscriber> db = new Mock<ISubscriber>();
            db.Setup(x => x.ResetUnreadCount("Divya")).Returns(true);
            SubscriberManager businessManager = new SubscriberManager(db.Object);
            var target = businessManager.ResetUnreadCount("Divya");
            Assert.AreEqual(true, target);
        }

        [TestMethod]

        public void Test_ServiceLayer_To_Reset_Unread_count()
        {
            Mock<ISubscriberManager> businessManager = new Mock<ISubscriberManager>();
            businessManager.Setup(x => x.ResetUnreadCount("Divya")).Returns(true);
            SubscriberServiceManager serviceManager = new SubscriberServiceManager(businessManager.Object);
            var target = serviceManager.ResetUnreadCount("Divya");
            Assert.AreEqual(true, target);
        }

        [TestMethod]

        public void Test_Publisher_Translator_ModelToDataContract()
        {
            ServiceLayer.DataContract.Publisher contract_publisher = new ServiceLayer.DataContract.Publisher();
            Model.Publisher model_publisher = new Model.Publisher();
            var result = ServiceLayer.Translators.PublisherTranslator.ModelToDataContract(model_publisher);
            Assert.IsInstanceOfType(contract_publisher, result.GetType());
        }

        [TestMethod]

        public void Test_Publisher_Translator_DataContractToModel()
        {
            ServiceLayer.DataContract.Publisher contract_publisher = new ServiceLayer.DataContract.Publisher();
            Model.Publisher model_publisher = new Model.Publisher();
            var result = ServiceLayer.Translators.PublisherTranslator.DataContractToModel(contract_publisher);
            Assert.IsInstanceOfType(model_publisher, result.GetType());
        }


        [TestMethod]

        public void Fail_Test_Publisher_without_Translators()
        {
            ServiceLayer.DataContract.Publisher contract_publisher = new ServiceLayer.DataContract.Publisher();
            Model.Publisher model_publisher = new Model.Publisher();
            Assert.IsNotInstanceOfType(contract_publisher, model_publisher.GetType());
        }

      
        [TestMethod]

        public void Fail_Test_Subscrier_without_Translator_DataContractToModel()
        {
            ServiceLayer.DataContract.Subscriber contract_Subscriber = new ServiceLayer.DataContract.Subscriber();
            Model.Subscriber model_Subscriber = new Model.Subscriber();
            Assert.IsNotInstanceOfType(contract_Subscriber, model_Subscriber.GetType());
        }

        [TestMethod]

        public void Test_Subscriber_Translator_ModelToDataContract()
        {
            ServiceLayer.DataContract.Subscriber contract_Subscriber = new ServiceLayer.DataContract.Subscriber();
            Model.Subscriber model_Subscriber = new Model.Subscriber();
            var result = ServiceLayer.Translators.SubscriberTranslator.ModelToDataContract(model_Subscriber);
            Assert.IsInstanceOfType(contract_Subscriber, result.GetType());
        }

        [TestMethod]

        public void Test_Subscriber_Translator_DataContractToModel()
        {
            ServiceLayer.DataContract.Subscriber contract_Subscriber = new ServiceLayer.DataContract.Subscriber();
            Model.Subscriber model_Subscriber = new Model.Subscriber();
            var result = ServiceLayer.Translators.SubscriberTranslator.DataContractToModel(contract_Subscriber);
            Assert.IsInstanceOfType(model_Subscriber, result.GetType());
        }

    }
}
