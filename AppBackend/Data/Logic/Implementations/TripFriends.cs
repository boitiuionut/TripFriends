using Emr.API.Data.Logic.Interfaces;
using Emr.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

namespace Emr.API.Data.Logic.Implementations
{
    public class TripFriends: ITripFriends
    {
        public UserInfoModel getUserInformation (string username)
        {
            using (var database = new TripFriendsDBEntities())
            {
                try
                {
                    var result = database.UsersDatas.Where(w => w.username == username).FirstOrDefault();
                    UserInfoModel resultMapped = new UserInfoModel
                    {
                        userId = result.userId,
                        firstName = result.nume,
                        lastName = result.prenume,
                        phone = result.telefon,
                        email = result.email,
                        description = result.descriere,
                        username = result.username,
                        profilepicture = result.pozaprofil
                    };
                    return resultMapped;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return null;
                }
            }
        }


        public bool editUserInformation (UserInfoModel model)
        {
            using (var database = new TripFriendsDBEntities())
            {
                try
                {
                    var result = database.UsersDatas.Where(w => w.username == model.username).FirstOrDefault();
                    if (result == null)
                    {
                        return false;
                    }
                    result.nume = model.firstName;
                    result.prenume = model.lastName;
                    result.telefon = model.phone;
                    result.email = model.email;
                    result.descriere = model.description;
                    result.pozaprofil = model.profilepicture;

                    database.Entry(result).State = EntityState.Modified;
                    database.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return false;
                }
            }
        }

        public bool postTrip(string username, TripInfoModel model)
        {
            using (var database = new TripFriendsDBEntities())
            {
                try
                {
                    var usersData = database.UsersDatas.Where(w => w.username == username).FirstOrDefault();

                    if (usersData == null)
                    {
                        return false;
                    }

                    var tripTabel = new TripsData
                    {
                    userid = usersData.userId,
                    country = model.country,
                    town = model.town,
                    detailedaddress = model.address,
                    tripdate = model.date,
                    tripduration = model.duration,
                    availability = 1,
                    whycompany = model.description
                    };

                    database.TripsDatas.Add(tripTabel);
                    database.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return false;
                }
            }
        }

        public bool postFeedback(FeedbackInfoModel model)
        {
            using (var database = new TripFriendsDBEntities())
            {
                try
                {
                    var usersData = database.UsersDatas.Where(w => w.username == model.username).FirstOrDefault();

                    if (usersData == null)
                    {
                        return false;
                    }

                    var feedbackTabel = new FeedbacksData
                    {
                        userid = usersData.userId,
                        description = model.description,
                        rating = model.rating,
                    };

                    database.FeedbacksDatas.Add(feedbackTabel);
                    database.SaveChanges();
                    return true;

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return false;
                }
            }
        }

        public List<FeedbackReceivedInfoModel> getUserFeedbackInformation(string username)
        {
            using (var database = new TripFriendsDBEntities())
            {
                try
                {
                    var userData = database.UsersDatas.Where(w => w.username == username).FirstOrDefault();

                    if (userData == null)
                    {
                        return null;
                    }

                    var userFeedback = database.FeedbacksDatas.Where(w => w.userid == userData.userId).Select(f => new FeedbackReceivedInfoModel
                    {
                        description = f.description,
                        rating = f.rating
                    }).ToList();
                    
                    return userFeedback;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return null;
                }
            }
        }

        public List<FullTripsInfoModel> getTripsData()
        {
            using (var database = new TripFriendsDBEntities())
            {
                try
                {  
                    var userData = database.UsersDatas.ToList();

                    if (userData == null)
                    {
                        return null;
                    }
                    return getUserTripsInfo(database, userData);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return null;
                }
            }
        }

        List<FullTripsInfoModel> getUserTripsInfo(TripFriendsDBEntities database, List<UsersData> userData)
        {
            List<FullTripsInfoModel> usersInfoAllData = new List<FullTripsInfoModel>();
            foreach (var user in userData)
            {
                List<TripInfoModel> availableTrips = new List<TripInfoModel>();
                var userTrips = database.TripsDatas.Where(w => w.userid == user.userId).Select(t => new TripInfoModel
                {
                    country = t.country,
                    town = t.town,
                    address = t.detailedaddress,
                    date = t.tripdate,
                    duration = t.tripduration,
                    description = t.whycompany
                }).ToList();

                //compararea datei actuale a sistemului cu cea a vacantei. Daca vacanta e mai tarziu programate ca data actuala, o adaug in lista de vacante valide.
                int resultDateComparison = 0;
                DateTime tripDate;
                DateTime localDate = DateTime.Now;

                if (userTrips.Count() > 0)
                {
                    foreach (var userTrip in userTrips)
                    {
                        tripDate = DateTime.Parse(userTrip.date);
                        resultDateComparison = DateTime.Compare(localDate, tripDate);
                        if(resultDateComparison < 0)
                            availableTrips.Add(userTrip);
                    }  
                }

                int avgRate = 0, userRatingSum = 0;
                var userFeedbacks = database.FeedbacksDatas.Where(w => w.userid == user.userId).Select(f => new FeedbackReceivedInfoModel
                {
                    description = f.description,
                    rating = f.rating
                }).ToList();

                foreach(var userFeedback in userFeedbacks)
                {
                    userRatingSum += userFeedback.rating;
                }

                if (userFeedbacks.Count() != 0)
                {
                    avgRate = userRatingSum / userFeedbacks.Count();
                }

                for (int i = 0; i < availableTrips.Count(); i++) {
                    usersInfoAllData.Add(new FullTripsInfoModel
                    {
                        firstName = user.nume,
                        lastName = user.prenume,
                        email = user.email,
                        phone = user.telefon,
                        username = user.username,
                        description = user.descriere,
                        profilepicture = user.pozaprofil,
                        country = availableTrips[i].country,
                        town = availableTrips[i].town,
                        address = availableTrips[i].address,
                        date = availableTrips[i].date,
                        duration = availableTrips[i].duration,
                        descriptionTrip = availableTrips[i].description,
                        userFeedbackInfo = userFeedbacks,
                        avgRating = avgRate
                    });
                }
            }
            return usersInfoAllData;
        }

        List<TripInfoModel> trips =  new List<TripInfoModel>();
        public List<TripInfoModel> getUserActivityTripsData(string username)
        {
            using (var database = new TripFriendsDBEntities())
            {
                try
                {
                    trips.Clear();
                    var userData = database.UsersDatas.Where(w => w.username == username).FirstOrDefault();

                    if (userData == null)
                    {
                        return null;
                    }

                    var userTrips = database.TripsDatas.Where(w => w.userid == userData.userId).Select(f => new TripInfoModel
                    {
                        country = f.country,
                        town = f.town,
                        address = f.detailedaddress,
                        date = f.tripdate,
                        duration = f.tripduration,
                        description = f.whycompany
                    }).ToList();

                    int resultDateComparison = 0;
                    DateTime tripDate;
                    DateTime localDate = DateTime.Now;

                    if (userTrips.Count() > 0)
                    {
                        foreach (var userTrip in userTrips)
                        {
                            tripDate = DateTime.Parse(userTrip.date);
                            resultDateComparison = DateTime.Compare(localDate, tripDate);
                            if (resultDateComparison < 0)
                            {
                                userTrip.isFutureTrip = true;
                                trips.Add(userTrip);
                            }
                            else
                            {
                                userTrip.isFutureTrip = false;
                                trips.Add(userTrip);
                            }
                        }
                    }
                    return trips;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return null;
                }
            }
        }
    
    }
}