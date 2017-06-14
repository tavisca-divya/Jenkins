using ServiceLayer.DataContract;
using ServiceLayer.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Notification_System.Controllers
{
    [RoutePrefix("api/Subscribers")]
    public class SubscriberController : ApiController
    {
        ISubscriberServiceManager _serviceManager;
        public SubscriberController(ISubscriberServiceManager serviceManager)
        {

            _serviceManager = serviceManager;

        }

        [HttpGet]
        [Route("Get")]
        public List<Publisher> Get()
        {
            return _serviceManager.GetNotifications();

        }
        [HttpPost]
        [Route("Validate")]
        public IHttpActionResult Post([FromBody] Subscriber subscriber)
        {
            var result = _serviceManager.validate_user(subscriber.UserName, subscriber.password);
            if (result == true)
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post_subscriber([FromBody] Subscriber subscriber)
        {

            var result = _serviceManager.create_Subscriber(subscriber.UserName, subscriber.password, subscriber);
            return Ok();
        }

        [HttpGet]
        [Route("Count/{username}")]
        public int Get_Count(string username)
        {
            return _serviceManager.GetNotificationCount(username);

        }

        [HttpGet]
        [Route("ResetCount/{username}")]
        public bool Get_ResetCount(string username)
        {
            return _serviceManager.ResetUnreadCount(username);

        }
    }
}
