using System;
using System.ComponentModel.DataAnnotations;

namespace SousChef.WebApi._0._Models___DTOs;

public class MealIngredients
{
    [Key]
    public Guid MealIngredientId {get; set;} // Primary key
    public Guid MealId {get; set;} // Foreign key
    public Guid IngredientId {get; set;} // Foreign key
    public double IngredientQuantity {get; set;}
    public string? IngredientUnit {get; set;}
    public string Purchased {get; set;} = "No";
    //Navigation properties
    public Meal? Meal {get; set;}
    public Ingredient? Ingredient {get; set;}
    // Constructor
    public MealIngredients(){}
    public MealIngredients(Meal meal, Ingredient ingredient, double ingredientQuantity, string ingredientUnit)
    {
        MealIngredientId = Guid.NewGuid();
        MealId = meal.MealId;
        IngredientId = ingredient.IngredientId;
        IngredientQuantity = ingredientQuantity;
        IngredientUnit = ingredientUnit;
    }
}
