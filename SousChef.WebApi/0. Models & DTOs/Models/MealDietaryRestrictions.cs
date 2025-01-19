/*using System;
using System.ComponentModel.DataAnnotations;

namespace SousChef.WebApi._0._Models___DTOs;

public class MealDietaryRestrictions
{
    [Key]
    public Guid MealDietaryRestrictionId {get; set;} // Primary key
    public Guid MealId {get; set;}
    public DietaryRestriction DietaryRestriction {get; set;}

    // Navigation property
    // public Meal Meal {get; set;}

    // Methods
    public MealDietaryRestrictions(Meal meal, DietaryRestriction dietaryRestriction)
    {
        MealDietaryRestrictionId = Guid.NewGuid();
        MealId = meal.MealId;
        DietaryRestriction = dietaryRestriction;
    }
}
*/