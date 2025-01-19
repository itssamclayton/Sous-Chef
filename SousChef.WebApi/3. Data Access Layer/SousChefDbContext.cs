using System;
using Microsoft.EntityFrameworkCore;
using SousChef.WebApi._0._Models___DTOs;

namespace SousChef.WebApi._3._Data_Access_Layer;

public class SousChefDbContext : DbContext
{
    public SousChefDbContext(DbContextOptions<SousChefDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users {get; set;}
    public DbSet<MealPlan> MealPlans {get; set;}
    public DbSet<MealPlanMeals> MealPlanMeals {get; set;}
    public DbSet<Meal> Meals {get; set;}
    public DbSet<MealIngredients> MealIngredients {get; set;}
    public DbSet<MealRecipeStep> MealRecipeSteps {get; set;}
    public DbSet<Ingredient> Ingredients {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
        
    // Many-to-many: MealPlan <-> Meal
    modelBuilder.Entity<MealPlanMeals>()
        .HasKey(mp => new { mp.MealPlanId, mp.MealId });

    modelBuilder.Entity<MealPlanMeals>()
        .HasOne(mp => mp.MealPlan)
        .WithMany(m => m.MealPlanMeals)
        .HasForeignKey(mp => mp.MealPlanId);

    modelBuilder.Entity<MealPlanMeals>()
        .HasOne(mp => mp.Meal)
        .WithMany() // No MealPlanMeals as a navigation property in Meal
        .HasForeignKey(mp => mp.MealId);

    // One-to-many: Meal <-> RecipeStep
        modelBuilder.Entity<MealRecipeStep>()
        .HasOne(rs => rs.Meal)
        .WithMany(m => m.MealRecipeSteps)
        .HasForeignKey(rs => rs.MealId);

    // Many-to-many: Meal <-> Ingredient via MealIngredients

 // Configure MealIngredients as a join table
    modelBuilder.Entity<MealIngredients>()
        .HasKey(mi => mi.MealIngredientId);

    modelBuilder.Entity<MealIngredients>()
        .HasOne(mi => mi.Meal)
        .WithMany(m => m.MealIngredients)
        .HasForeignKey(mi => mi.MealId);

    modelBuilder.Entity<MealIngredients>()
        .HasOne(mi => mi.Ingredient)
        .WithMany()
        .HasForeignKey(mi => mi.IngredientId);

    // Configure one-to-many: Meal <-> RecipeStep
    modelBuilder.Entity<MealRecipeStep>()
        .HasOne(rs => rs.Meal)
        .WithMany(m => m.MealRecipeSteps)
        .HasForeignKey(rs => rs.MealId);
    }
}
