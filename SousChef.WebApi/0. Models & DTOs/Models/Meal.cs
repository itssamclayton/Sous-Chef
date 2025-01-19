using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Expressions;

namespace SousChef.WebApi._0._Models___DTOs;

public class Meal
{
    [Key]
    public Guid MealId {get; set;} // Primary key
    public string MealName {get; set;}
    public string? Source {get; set;}

    // Navigation properties
    public DietaryRestriction MealDietaryRestrictions {get; set;} = DietaryRestriction.None;
    public List<MealIngredients> MealIngredients {get; set;} = new();
    public List<MealRecipeStep> MealRecipeSteps {get; set;} = new();

    // Methods
    public Meal(){}
    public Meal(string mealName, string source)
    {
        MealId = Guid.NewGuid();
        MealName = mealName;
        Source = source;
    }
    public Meal(string mealName, string source, DietaryRestriction mealDietaryRestrictions, List<MealIngredients> mealIngredients, List<MealRecipeStep> mealRecipeSteps)
    {
        MealId = Guid.NewGuid();
        MealName = mealName;
        Source = source;
        MealDietaryRestrictions = mealDietaryRestrictions;
        MealIngredients = mealIngredients;
        MealRecipeSteps = mealRecipeSteps;
    }
}
