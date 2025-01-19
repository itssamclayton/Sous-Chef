using System;
using SousChef.WebApi._0._Models___DTOs;

namespace SousChef.WebApi._2._Service_Layer.Helpers;

public class UserHelper
{
    public static UserType ConvertToUserType(string userType)
    {
        if (userType == "Admin")
        {
            return UserType.Admin;
        }
        else
        {
            return UserType.Normal;
        }
    }
}
