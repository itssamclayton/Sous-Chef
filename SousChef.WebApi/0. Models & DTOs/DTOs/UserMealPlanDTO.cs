using System;

namespace SousChef.WebApi._0._Models___DTOs.DTOs;

public class UserMealPlanDTO
{
    Guid UserMealPlanId {set; get;}
    Guid UserId {get; set;}
    List<MealDTO>? Meals {get; set;}


}
