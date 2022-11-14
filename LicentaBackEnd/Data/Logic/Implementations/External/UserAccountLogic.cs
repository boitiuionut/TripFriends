using Emr.API;
using Emr.API.Models;
using EMR.API.Data.Logic.Interfaces.External;
using System;
using System.Linq;

namespace EMR.API.Data.Logic.Implementations.External
{
    public class UserAccountLogic: IUserAccountLogic
    {
        //private readonly string serverPathResetPassword = "http://localhost:55069/PasswordReset/ResetPassword/";

        public UserAccountLogic()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertNewUser(RegisterClientModel model)
        {
            using (var context = new TripFriendsDBEntities())
            {
                try
                {
                    //checks if the username provided (uid) does exist in the database
                    var existsUser = context.UsersDatas.Where(w => w.username == model.username).FirstOrDefault();

                    if (existsUser == null)
                    {
                        var newUser = new UsersData
                        {
                            username = model.username,
                            nume = model.nume,
                            prenume = model.prenume,
                            telefon = model.telefon,
                            email = model.email
                        };

                        context.UsersDatas.Add(newUser);
                        context.SaveChanges();

                        return true;
                    }

                    else return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //#endregion

        //#region PASSWORD RESET

        ///// <summary>
        ///// This method is responsible for the first call of the controller, it decide if the mail for password reset should be sent. 
        ///// Note: the check to see whether the Encrypt and Decrypt function returns an identic hash is made in the controller, using a filter
        ///// </summary>
        ///// <param name="tc"></param>
        ///// <param name="uid"></param>
        ///// <param name="hash"></param>
        ///// <returns></returns>
        //public bool PasswordResetRequest(string tc, string uid, string hash)
        //{
        //    //check if the email received as a parameter exists in the database
        //    var userExists = _contactsLogic.VerifyContactByEmail(uid);
        //    if (!userExists) { 
        //        return false;
        //    }

        //    //gets the clinicId based on the email address provided, it should be a positive integer
        //    var clinicId = _contactsLogic.GetClinicIdByUserEmailAddress(uid);
        //    if (clinicId < 0) { 
        //        return false;
        //    }

        //    //checks if the clinic is active, based on the clinicId received in the prior method call
        //    var clinicIsActive = new ClinicsLogic().CheckClinicIsActive(clinicId);
        //    if (!clinicIsActive) { 
        //        return false;
        //    }

        //    //if all of the above conditions are met, the method responsible for sending the email to the address received (uid) will be called
        //    SendEmailPasswordReset(uid);
        //    return true;
        //}

        ///// <summary>
        ///// This method is responsible of generating the link for password reset in the sent email message. 
        ///// It returns the link, as well as a random generated code that will be used for security later. Also, it creates a new entry in the EHR_PASSWORD_REQUESTS database table
        ///// </summary>
        ///// <param name="email"></param>
        ///// <returns></returns>
        //public KeyValuePair<string, string> GenerateLinkPasswordReset(string email)
        //{
        //    using (var context = new EmrEntities())
        //    {
        //        var request = new EMR_PASSWORD_RESET_REQUESTS
        //        {
        //            EMAIL = email,
        //            TIME_COMPONENT = DateTime.Now.Ticks.ToString()
        //        };
        //        request.HASH = new PasswordControl().Encode(request.TIME_COMPONENT, email);
        //        request.RANDOM_CODE = new Random().Next(10000000, 99999999).ToString();
        //        request.REC_CREATE_TS = DateTime.Now;

        //        var link = serverPathResetPassword + "?h=" + request.HASH;

        //        context.EMR_PASSWORD_RESET_REQUESTS.Add(request);
        //        context.SaveChanges();

        //        return new KeyValuePair<string, string>(link, request.RANDOM_CODE);
        //    }
        //}

        ///// <summary>
        ///// This method sends the email to the address given as a parameter.The body of the e-mail is written here. It also uses the above method: GenerateLinkPasswordReset
        ///// </summary>
        ///// <param name="email"></param>
        ///// <returns></returns>
        //public bool SendEmailPasswordReset(string email)
        //{
        //    try
        //    {
        //        MailMessage msg = new MailMessage();
        //        var generated = GenerateLinkPasswordReset(email);

        //        msg.From = new MailAddress("staff.clinic.emr@gmail.com", "EMR Staff");
        //        msg.To.Add(email);
        //        msg.Subject = "Password reset request.";
        //        msg.Body = "You recently requested to reset your password for your EMR account." +
        //            "<br />" +
        //            "<br />" +
        //            "Here is your reset password verification code: <b>" + generated.Value + "</b><br />Use it in <a href=" + generated.Key + " target='_blank'>this link</a> in order to create a new password.<br />" +
        //            "<br />" +
        //            "<b>This link is valid for 10 minutes from the moment you received this email, and it can only be used once.</b>" +
        //            "<br />" +
        //            "If you did not request a password reset, please let us know immediately by replying to this email." +
        //            "<br />" +
        //            "<br />" +
        //            "Yours," +
        //            "<br />" +
        //            "The EMR team";
        //        msg.Priority = MailPriority.High;
        //        msg.IsBodyHtml = true;

        //        var emailCredentials = new EmailCredentials();

        //        return SetStmpClientForEmail(msg);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// This method decides if the password will be changed to the new one provided by the user
        ///// </summary>
        ///// <param name="tc"></param>
        ///// <param name="uid"></param>
        ///// <param name="code"></param>
        ///// <param name="pass"></param>
        ///// <param name="hash"></param>
        ///// <returns></returns>
        //public bool ValidatePasswordResetRequest(string tc, string uid, string code, string pass, string hash)
        //{
        //    using (var context = new EmrEntities())
        //    {
        //        try
        //        {
        //            //checks if the username provided (uid) does exist in the database
        //            var existsUser = _contactsLogic.VerifyContactByUserName(uid);

        //            //gets the email address of the provided user(uid) from the database
        //            var email = _contactsLogic.GetUserEmailByUserName(uid);
        //            if (existsUser)
        //            {
        //                //checks if the random code sent in the email is the same with the random code typed by the person who wants to change
        //                //the password, also checks if the hash is the same and finally if the email who made the request for reset is the same 
        //                //as the email of the provided user(uid)
        //                var request = context.EMR_PASSWORD_RESET_REQUESTS.Where(w => w.RANDOM_CODE == code && w.HASH == hash && w.EMAIL == email).FirstOrDefault();
        //                if (request != null && request.RESET != true)
        //                {
        //                    //checks how much time has passed since the email has been sent and if the link has been used 
        //                    if ((ConvertTicksFromStringToMinutes(tc) - ConvertTicksFromStringToMinutes(request.TIME_COMPONENT) < 10) && (ConvertTicksFromStringToMinutes(tc) - ConvertTicksFromStringToMinutes(request.TIME_COMPONENT) >= 0) && request.RESET != true)
        //                    {
        //                        //saves the data to the EHR_PASSWORD_RESET_REQUESTS and call the method to change the password
        //                        request.USER_NAME = uid;
        //                        request.RESET = true;
        //                        context.Entry(request).State = EntityState.Modified;
        //                        context.SaveChanges();
        //                        var changepass = _contactsLogic.ChangePasswordRequest(uid, pass);
        //                        return changepass;
        //                    }
        //                    else return false;
        //                }
        //                else return false;
        //            }
        //            else return false;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Simple method to use in the ValidatePasswordResetRequest method above
        ///// </summary>
        ///// <param name="tc"></param>
        ///// <returns></returns>
        //private double ConvertTicksFromStringToMinutes(string tc)
        //{
        //    var parsed = long.TryParse(tc, out var convertTc);

        //    if (parsed == true)
        //    {
        //        return TimeSpan.FromTicks(convertTc).TotalMinutes;
        //    }
        //    else return -1;
        //}

        //private bool SetStmpClientForEmail(MailMessage msg)
        //{
        //    var emailCredentials = new EmailCredentials();

        //    using (SmtpClient client = new SmtpClient())
        //    {
        //        client.EnableSsl = true;
        //        client.UseDefaultCredentials = false;
        //        client.Credentials = new NetworkCredential(emailCredentials.GetEmailAccCredentials(), emailCredentials.GetEmailPassCredentials());
        //        client.Host = "smtp.googlemail.com";
        //        client.Port = 587;
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.Send(msg);

        //        return true;
        //    }
        //}

        //#endregion
    }
}