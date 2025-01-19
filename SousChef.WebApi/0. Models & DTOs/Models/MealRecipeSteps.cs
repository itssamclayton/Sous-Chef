using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SousChef.WebApi._0._Models___DTOs;

public class MealRecipeStep
{
    [Key]
    public Guid RecipeStepId {get; set;} // Primary key
    public Guid MealId {get; set;} // Foreign key
    public int StepSequence {get; set;}
    public string? StepDescription {get; set;}

    public Meal? Meal {get; set;}

    // Constructor
    public MealRecipeStep() {}
    public MealRecipeStep(Meal meal, int stepSequence, string stepDescription)
    {
        RecipeStepId = Guid.NewGuid();
        MealId = meal.MealId;
        StepSequence = stepSequence;
        StepDescription = stepDescription;
    }
}
