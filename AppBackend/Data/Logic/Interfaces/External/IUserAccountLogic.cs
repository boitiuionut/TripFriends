using Emr.API.Models;

namespace EMR.API.Data.Logic.Interfaces.External
{
    interface IUserAccountLogic
    {
        bool InsertNewUser(RegisterClientModel model);
    }
}
