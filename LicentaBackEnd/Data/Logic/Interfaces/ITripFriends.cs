using Emr.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.API.Data.Logic.Interfaces
{
    interface ITripFriends
    {
        UserInfoModel getUserInformation(string username);
        bool editUserInformation(UserInfoModel model);

        bool postTrip(string username, TripInfoModel model);

        bool postFeedback(FeedbackInfoModel model);

        List<FeedbackReceivedInfoModel> getUserFeedbackInformation(string username);

        List<FullTripsInfoModel> getTripsData();

        List<TripInfoModel> getUserActivityTripsData(string username);

    }
}
