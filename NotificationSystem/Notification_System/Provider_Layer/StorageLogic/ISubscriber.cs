﻿using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider_Layer.StorageLogic
{
    public interface ISubscriber
    {
        Subscriber create_Subscriber(string name, string password, Subscriber subscriber);
        bool validate_user(string name, string password);

        List<Publisher> GetNotifications();

        int GetNotificationCount(string UserName);
        bool ResetUnreadCount(string UserName);
    }
}
