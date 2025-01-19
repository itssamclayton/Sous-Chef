using System;
using System.ComponentModel.DataAnnotations;

namespace SousChef.WebApi._0._Models___DTOs;
public class Ingredient
{
    [Key]
    public Guid IngredientId {get; set;} // Primary key
    public string? Name {get; set;}

    // Navigation property for the many-to-many relationship
    public List<MealIngredients> MealIngredients{get;set;} = new();

    // Constructor
    public Ingredient() {}
    public Ingredient(string name)
    {
        IngredientId = Guid.NewGuid();
        Name = name;
    }
}
