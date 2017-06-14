using BusinessLayer.BusinessImplementation;
using BusinessLayer.BusinessLogic;
using Provider_Layer.StorageManager;
using ServiceLayer.DataContract;
using ServiceLayer.DataImplementation;
using ServiceLayer.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Notification_System.Controllers
{
    [RoutePrefix("api/notification")]
    public class NotificationController : ApiController
    {
        IPublisherServiceManager _businessManager;

        public NotificationController()
        {

        }
        public NotificationController(IPublisherServiceManager businessManager)
        {
            _businessManager = businessManager;


        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post([FromBody] Publisher message)
        {

            var result = _businessManager.Save_Notification(message.NotificationId, message);
            return Ok();
        }



    }
}
