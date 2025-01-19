using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SousChef.WebApi._0._Models___DTOs;

public class MealPlan
{
    [Key]
    public Guid MealPlanId {get; set;} // Primary key
    public Guid UserId {get; set;} // Foreign key
    public DateTime MealPlanDate {get; set;}

    // Navigation properties
    public List<MealPlanMeals> MealPlanMeals {get; set;} = new();
    public MealPlan(){}
}
