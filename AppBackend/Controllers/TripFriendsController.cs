using Emr.API.Data.Logic.Implementations;
using Emr.API.Data.Logic.Interfaces;
using Emr.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Emr.API.Controllers
{
    public class TripFriendsController : ApiController
    {
        private readonly ITripFriends tripFriends;

        public TripFriendsController()
        {
            tripFriends = new TripFriends();
        }

        [HttpGet]
        [ResponseType(typeof(UserInfoModel))]
        [Route("users/get/information/username/{username}")]
        public IHttpActionResult GetUserInformation([FromUri] string username)
        {
            var result = tripFriends.getUserInformation(username);
            return Ok(result);
        }

        [HttpGet]
        [ResponseType(typeof(FeedbackInfoModel))]
        [Route("user/get-userfeedback/{username}")]
        public IHttpActionResult GetUserFeedbackInformation([FromUri] string username)
        {
            var result = tripFriends.getUserFeedbackInformation(username);
            return Ok(result);
        }

        [HttpGet]
        [ResponseType(typeof(FullTripsInfoModel))]
        [Route("user/get-trips")]
        public IHttpActionResult GetTripsInformation()
        {
            var result = tripFriends.getTripsData();
            return Ok(result);
        }

        [HttpGet]
        [ResponseType(typeof(FullTripsInfoModel))]
        [Route("user/get-trips/{username}")]
        public IHttpActionResult GetUserActivityTripsInformation([FromUri] string username)
        {
            var result = tripFriends.getUserActivityTripsData(username);
            return Ok(result);
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("users/edit/information/username")]
        public IHttpActionResult EditUserInformation([FromBody] UserInfoModel model)
        {
            var result = tripFriends.editUserInformation(model);
            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("user/post-tripinfo/{username}")]
        public IHttpActionResult PostTripInformation([FromUri] string username, [FromBody] TripInfoModel model)
        {
            var result = tripFriends.postTrip(username,model);
            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("user/post-tripfeedback")]
        public IHttpActionResult PostFeedback([FromBody] FeedbackInfoModel model)
        {
            var result = tripFriends.postFeedback(model);
            return Ok(result);
        }
    }
}
