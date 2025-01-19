using System;
using System.ComponentModel.DataAnnotations;

namespace SousChef.WebApi._0._Models___DTOs;

public class MealPlanMeals
{
    [Key]
    public Guid MealPlanId {get; set;}
    public Guid MealId {get; set;}

    // Navigation properties
    public MealPlan? MealPlan{get; set;}
    public Meal? Meal {get; set;}

    // Constructor
    public MealPlanMeals(){}

}
