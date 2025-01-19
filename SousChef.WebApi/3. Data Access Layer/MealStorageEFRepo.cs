using System;
using Microsoft.EntityFrameworkCore;
using SousChef.WebApi._0._Models___DTOs;
using SousChef.WebApi._3._Data_Access_Layer.Interfaces;

namespace SousChef.WebApi._3._Data_Access_Layer;

public class MealStorageEFRepo : IMealStorageEFRepo
{
    private readonly SousChefDbContext sousChefDbContext;
    public MealStorageEFRepo(SousChefDbContext _sousChefDbContext)
    {
        sousChefDbContext = _sousChefDbContext;
    }
    public async Task PopulateInitialMealsAsync()
    {
        if (!await sousChefDbContext.Meals.AnyAsync())
        {
            // Recipe 1: Girl Dinner
            Meal GirlDinner = new Meal("Girl Dinner", "Sous Chef");
         
            Ingredient Crackers = new Ingredient("Crackers");
            Ingredient CheddarCheese = new Ingredient("Cheddar Cheese");
            Ingredient Salami = new Ingredient("Salami");
            Ingredient Olives = new Ingredient("Olives");
            Ingredient Grapes = new Ingredient("Grapes");

            MealIngredients recipe1ingredient1 = new MealIngredients(GirlDinner, Crackers, 10, "");
            MealIngredients recipe1ingredient2 = new MealIngredients(GirlDinner, CheddarCheese, 10, "slices");
            MealIngredients recipe1ingredient3 = new MealIngredients(GirlDinner, Salami, 10, "slices");
            MealIngredients recipe1ingredient4 = new MealIngredients(GirlDinner, Olives, 10, "");
            MealIngredients recipe1ingredient5 = new MealIngredients(GirlDinner, Grapes, 0.5, "cups");
            GirlDinner.MealIngredients = new List<MealIngredients>()
                {
                    recipe1ingredient1,
                    recipe1ingredient2,
                    recipe1ingredient3,
                    recipe1ingredient4,
                    recipe1ingredient5
                };
            
            MealRecipeStep recipe1step1 = new MealRecipeStep(GirlDinner, 1, "Assemble all ingredients on a plate.");
            MealRecipeStep recipe1step2 = new MealRecipeStep(GirlDinner, 2, "Pour yourself a glass of your favorite beverage, put on your favorite show, and enjoy!");
            GirlDinner.MealRecipeSteps = new List<MealRecipeStep>(){recipe1step1, recipe1step2};

            GirlDinner.MealDietaryRestrictions = DietaryRestriction.None;
            
            // Recipe 2: Chicken & Broccoli Stir Fry
            Meal ChickenStirFry = new Meal("Chicken and Broccoli Stir Fry", "Sous Chef");
            
            Ingredient ChickenBreasts = new Ingredient("Chicken Breasts");
            Ingredient Broccoli = new Ingredient("Broccoli");
            Ingredient AvocadoOil = new Ingredient ("Avocado Oil");
            Ingredient GarlicPowder = new Ingredient("Garlic Powder");
            Ingredient Salt = new Ingredient("Salt");
            Ingredient Pepper = new Ingredient("Pepper");
            
            MealIngredients recipe2ingredient1 = new MealIngredients(ChickenStirFry, ChickenBreasts, 1, "pound");
            MealIngredients recipe2ingredient2 = new MealIngredients(ChickenStirFry, Broccoli, 1, "head");
            MealIngredients recipe2ingredient3 = new MealIngredients(ChickenStirFry, AvocadoOil, 2, "tbsp.");
            MealIngredients recipe2ingredient4 = new MealIngredients(ChickenStirFry, GarlicPowder, 1, "tsp.");
            MealIngredients recipe2ingredient5 = new MealIngredients(ChickenStirFry, Salt, 1, "tsp.");
            MealIngredients recipe2ingredient6 = new MealIngredients(ChickenStirFry, Pepper, 1, "tsp.");
            ChickenStirFry.MealIngredients = new List<MealIngredients>()
                {
                recipe2ingredient1,
                recipe2ingredient2,
                recipe2ingredient3,
                recipe2ingredient4,
                recipe2ingredient5,
                recipe2ingredient6
                };

            MealRecipeStep recipe2step1 = new MealRecipeStep(ChickenStirFry, 1, "Cut chicken into 1\" cubes.");
            MealRecipeStep recipe2step2 = new MealRecipeStep(ChickenStirFry, 2, "Cut broccoli into bite-sized florets.");
            MealRecipeStep recipe2step3 = new MealRecipeStep(ChickenStirFry, 3, "Heat avocado oil in saute pan on medium-high heat.");
            MealRecipeStep recipe2step4 = new MealRecipeStep(ChickenStirFry, 4, "Add chicken and broccoli to pan and cook until chicken reaches an internal temperature of 165 degrees Fahrenheit.");
            
            ChickenStirFry.MealRecipeSteps = new List<MealRecipeStep>()
            {
                recipe2step1,
                recipe2step2,
                recipe2step3,
                recipe2step4
            };
           
            ChickenStirFry.MealDietaryRestrictions = DietaryRestriction.GlutenFree | DietaryRestriction.DairyFree | DietaryRestriction.Paleo | DietaryRestriction.NutFree;
            
            // Recipe 3: Pasta with Homemade Pesto
            Meal PastaWithPesto = new Meal("Pasta with Homemade Pesto", "Sous Chef");
            
            Ingredient Spaghetti = new Ingredient("Spaghetti");
            Ingredient Basil = new Ingredient("Basil");
            Ingredient Garlic = new Ingredient("Garlic");
            Ingredient PineNuts = new Ingredient("Pine Nuts");
            Ingredient OliveOil = new Ingredient("Olive Oil");

            MealIngredients recipe3ingredient1 = new MealIngredients(PastaWithPesto, Spaghetti, 1, "box");
            MealIngredients recipe3ingredient2 = new MealIngredients(PastaWithPesto, Basil, 2, "cups");
            MealIngredients recipe3ingredient3 = new MealIngredients(PastaWithPesto, Garlic, 4, "cloves");
            MealIngredients recipe3ingredient4 = new MealIngredients(PastaWithPesto, PineNuts, 1, "cup");
            MealIngredients recipe3ingredient5 = new MealIngredients(PastaWithPesto, OliveOil, 0.5, "cup");
            MealIngredients recipe3ingredient6 = new MealIngredients(PastaWithPesto, Salt, 1, "tsp.");
            
            PastaWithPesto.MealIngredients = new List<MealIngredients>()
                {
                recipe3ingredient1,
                recipe3ingredient2,
                recipe3ingredient3,
                recipe3ingredient4,
                recipe3ingredient5,
                recipe3ingredient6
                };
            
            MealRecipeStep recipe3step1 = new MealRecipeStep(PastaWithPesto, 1, "Bring a large pot of water to boil.");
            MealRecipeStep recipe3step2 = new MealRecipeStep(PastaWithPesto, 2, "Add spaghetti and cook for length of time recommended on package.");
            MealRecipeStep recipe3step3 = new MealRecipeStep(PastaWithPesto, 3, "While spaghetti cooks, add all other ingredients to a blender or food processor and blend.");
            MealRecipeStep recipe3step4 = new MealRecipeStep(PastaWithPesto, 4, "Drain pasta\n5. Stir pesto and pasta together and serve.");
            PastaWithPesto.MealRecipeSteps = new List<MealRecipeStep>()
            {
                recipe3step1,
                recipe3step2,
                recipe3step3,
                recipe3step4
            };
            PastaWithPesto.MealDietaryRestrictions = DietaryRestriction.DairyFree | DietaryRestriction.Vegan | DietaryRestriction.Vegetarian;

            // Recipe 4: Buffalo Chicken Stuffed Basked Potatoes
            Meal BuffaloChicken = new Meal("Buffalo Chicken Stuffed Baked Potatoes", "Sous Chef");
            Ingredient BuffaloSauce = new Ingredient("Buffalo Sauce");
            Ingredient Potato = new Ingredient("Potato");
            Ingredient Ranch = new Ingredient("Ranch");
            Ingredient Butter = new Ingredient("Butter");

            MealIngredients recipe4ingredient1 = new MealIngredients(BuffaloChicken, ChickenBreasts, 1, "pound");
            MealIngredients recipe4ingredient2 = new MealIngredients(BuffaloChicken, BuffaloSauce, 1, "8 oz. jar");
            MealIngredients recipe4ingredient3 = new MealIngredients(BuffaloChicken, Potato, 4, "");
            MealIngredients recipe4ingredient4 = new MealIngredients(BuffaloChicken, Ranch, 0.5, "cup");
            MealIngredients recipe4ingredient5 = new MealIngredients(BuffaloChicken, Pepper, 1, "tsp.");
            MealIngredients recipe4ingredient6 = new MealIngredients(BuffaloChicken, Salt, 1, "tsp.");
            MealIngredients recipe4ingredient7 = new MealIngredients(BuffaloChicken, Butter, 1, "tbsp.");
            BuffaloChicken.MealIngredients = new List<MealIngredients>()
            {
                recipe4ingredient1,
                recipe4ingredient2,
                recipe4ingredient3,
                recipe4ingredient4,
                recipe4ingredient5,
                recipe4ingredient6,
                recipe4ingredient7
            };

            
            MealRecipeStep recipe4step1 = new MealRecipeStep(BuffaloChicken, 1, "Pre-heat oven to 400 degrees.");
            MealRecipeStep recipe4step2 = new MealRecipeStep(BuffaloChicken, 2, "Wash potatoes and wrap each one in foil and place in oven.");
            MealRecipeStep recipe4step3 = new MealRecipeStep(BuffaloChicken, 3, "Let the potatoes cook for about 30 minutes and then start on the next steps.");
            MealRecipeStep recipe4step4 = new MealRecipeStep(BuffaloChicken, 4, "Put chicken in a large pot and fill it with water until the chicken is fully covered and then some.");
            MealRecipeStep recipe4step5 = new MealRecipeStep(BuffaloChicken, 5, "Put pot on the stove on medium high heat until the water boils.");
            MealRecipeStep recipe4step6 = new MealRecipeStep(BuffaloChicken, 6, "Once the water boils, turn the heat down to medium and cook until the chicken is cooked through.");
            MealRecipeStep recipe4step7 = new MealRecipeStep(BuffaloChicken, 7, "Once the chicken is cooked through, shred the chicken.");
            MealRecipeStep recipe4step8 = new MealRecipeStep(BuffaloChicken, 8, "Stir the buffalo and chicken to coat the chicken in sauce.");
            MealRecipeStep recipe4step9 = new MealRecipeStep(BuffaloChicken, 9, "When the potatoes are done, cut each potato down the center and"+
                                                    "top with butter, salt, pepper, the shredded chicken coated in sauce, and ranch.");

            List<MealRecipeStep> recipe4steps = new List<MealRecipeStep>()
            {
                recipe4step1,
                recipe4step2,
                recipe4step3,
                recipe4step4,
                recipe4step5,
                recipe4step6,
                recipe4step7,
                recipe4step8,
                recipe4step9
            };

            BuffaloChicken.MealRecipeSteps = recipe4steps;
            BuffaloChicken.MealDietaryRestrictions = DietaryRestriction.GlutenFree | DietaryRestriction.NutFree;
            

            // Recipe 5: Grilled Cheese Sandwich
            Meal GrilledCheese = new Meal("Grilled Cheese Sandwich", "Sous Chef");
            Ingredient MuensterCheese = new Ingredient("Muenster Cheese");
            Ingredient WhiteBread = new Ingredient("White Bread");


            MealIngredients recipe5ingredient1 = new MealIngredients(GrilledCheese, MuensterCheese, 2, "slices");
            MealIngredients recipe5ingredient2 = new MealIngredients(GrilledCheese, WhiteBread, 2, "slices");
            MealIngredients recipe5ingredient3= new MealIngredients(GrilledCheese, Butter, 0.5, "tbsp.");

            List<MealIngredients> recipe5ingredients = new List<MealIngredients>()
            {
                recipe5ingredient1,
                recipe5ingredient2,
                recipe5ingredient3
            };
            GrilledCheese.MealIngredients = recipe5ingredients;

            MealRecipeStep recipe5step1 = new MealRecipeStep(GrilledCheese, 1, "Butter 1 side of each slice of bread");
            MealRecipeStep recipe5step2 = new MealRecipeStep(GrilledCheese, 2, "Place the buttered side of 1 slice of bread into a hot pan on medium heat.");
            MealRecipeStep recipe5step3 = new MealRecipeStep(GrilledCheese, 3, "Add the cheese slices on top of the bread");
            MealRecipeStep recipe5step4 = new MealRecipeStep(GrilledCheese, 4, "Put the other slice of bread on top with the buttered side facing up.");
            MealRecipeStep recipe5step5 = new MealRecipeStep(GrilledCheese, 5, "Cook until the bottom is golden brown");
            MealRecipeStep recipe5step6 = new MealRecipeStep(GrilledCheese, 6, "Flip sandwich over and cook until the other side is golden brown too.");

            List<MealRecipeStep> recipe5steps = new List<MealRecipeStep>()
                                            {recipe5step1,
                                            recipe5step2,
                                            recipe5step3,
                                            recipe5step4,
                                            recipe5step5,
                                            recipe5step6};

            GrilledCheese.MealRecipeSteps = recipe5steps;
            GrilledCheese.MealDietaryRestrictions = DietaryRestriction.NutFree | DietaryRestriction.Vegetarian;
            
            // Recipe 6: Turkey BLTA Sandwich
            Meal TurkeyBLTA = new Meal("Turkey BLTA Sandwich", "Sous Chef");
            Ingredient TurkeyBreast = new Ingredient("Turkey Breast");
            Ingredient Bacon = new Ingredient("Bacon");
            Ingredient RomaineLettuce = new Ingredient("Romaine Lettuce");
            Ingredient Mayonnaise = new Ingredient("Mayonnaise");
            Ingredient Avocado = new Ingredient("Avocado");
            Ingredient Tomato = new Ingredient("Tomato");

            MealIngredients recipe6ingredient1 = new MealIngredients(TurkeyBLTA, WhiteBread, 2, "slices");
            MealIngredients recipe6ingredient2 = new MealIngredients(TurkeyBLTA, TurkeyBreast, 3, "slices");
            MealIngredients recipe6ingredient3 = new MealIngredients(TurkeyBLTA, Bacon, 2, "slices");
            MealIngredients recipe6ingredient4 = new MealIngredients(TurkeyBLTA, RomaineLettuce, 2, "leaves");
            MealIngredients recipe6ingredient5 = new MealIngredients(TurkeyBLTA, Mayonnaise, 0.5, "tbsp.");
            MealIngredients recipe6ingredient6 = new MealIngredients(TurkeyBLTA, Avocado, 0.5, "");
            MealIngredients recipe6ingredient7 = new MealIngredients(TurkeyBLTA, Tomato, 0.5, "");


            List<MealIngredients> recipe6ingredients = new List<MealIngredients>()
            {
                recipe6ingredient1,
                recipe6ingredient2,
                recipe6ingredient3,
                recipe6ingredient4,
                recipe6ingredient5,
                recipe6ingredient6,
                recipe6ingredient7
            };
            TurkeyBLTA.MealIngredients = recipe6ingredients;

            MealRecipeStep recipe6step1 = new MealRecipeStep(TurkeyBLTA, 1, "Slice the tomato and avocado.");
            MealRecipeStep recipe6step2 = new MealRecipeStep(TurkeyBLTA, 2, "Assemble the sandwich.");


            List<MealRecipeStep> recipe6steps = new List<MealRecipeStep>()
            {
                recipe6step1,
                recipe6step2
            };

            TurkeyBLTA.MealRecipeSteps = recipe6steps;
            TurkeyBLTA.MealDietaryRestrictions = DietaryRestriction.NutFree;

            
            // Recipe 7: Caprese Salad
            Meal CapreseSalad = new Meal("Caprese Salad", "Sous Chef");
            Ingredient Mozzarella = new Ingredient("Mozzarella");
            Ingredient GrapeTomato = new Ingredient("GrapeTomato");
            Ingredient BalsamicVinegar = new Ingredient("Balsamic Vinegar");

            MealIngredients recipe7ingredient1 = new MealIngredients(CapreseSalad, Mozzarella, 2, "ounces");
            MealIngredients recipe7ingredient2 = new MealIngredients(CapreseSalad, GrapeTomato, 8, "ounces");
            MealIngredients recipe7ingredient3 = new MealIngredients(CapreseSalad, Basil, 2, "cups");
            MealIngredients recipe7ingredient4 = new MealIngredients(CapreseSalad, OliveOil, 1, "tbsp.");
            MealIngredients recipe7ingredient5 = new MealIngredients(CapreseSalad, BalsamicVinegar, 1, "tbsp.");
            MealIngredients recipe7ingredient6 = new MealIngredients(CapreseSalad, Salt, 0.5, "tsp.");
            MealIngredients recipe7ingredient7 = new MealIngredients(CapreseSalad, Pepper, 0.5, "tsp.");


            List<MealIngredients> recipe7ingredients = new List<MealIngredients>()
            {
                recipe7ingredient1,
                recipe7ingredient2,
                recipe7ingredient3,
                recipe7ingredient4,
                recipe7ingredient5,
                recipe7ingredient6,
                recipe7ingredient7
            };
            CapreseSalad.MealIngredients = recipe7ingredients;

            MealRecipeStep recipe7step1 = new MealRecipeStep(CapreseSalad, 1, "Cut the mozzarella into bite-sized pieces.");
            MealRecipeStep recipe7step2 = new MealRecipeStep(CapreseSalad, 2, "Tear (or roughly chop) the basil.");
            MealRecipeStep recipe7step3 = new MealRecipeStep(CapreseSalad, 3, "Add all ingredients to a salad bowl and mix well.");


            List<MealRecipeStep> recipe7steps = new List<MealRecipeStep>()
            {
                recipe7step1,
                recipe7step2,
                recipe7step3
            };

            CapreseSalad.MealRecipeSteps = recipe7steps;

            CapreseSalad.MealDietaryRestrictions = DietaryRestriction.GlutenFree | DietaryRestriction.NutFree | DietaryRestriction.Vegetarian;
            
            List<Ingredient> IngredientsToAddToDatabase = new List<Ingredient>()
            {
                Crackers,
                CheddarCheese,
                Salami,
                Olives,
                Grapes,
                ChickenBreasts,
                Broccoli,
                AvocadoOil,
                GarlicPowder,
                Salt,
                Pepper,
                Spaghetti,
                Basil,
                Garlic,
                PineNuts,
                OliveOil,
                BuffaloSauce,
                Potato,
                Ranch,
                Butter,
                MuensterCheese,
                WhiteBread,
                TurkeyBreast,
                Bacon,
                RomaineLettuce,
                Mayonnaise,
                Avocado,
                Tomato,
                Mozzarella,
                GrapeTomato,
                BalsamicVinegar
            };
            List<Meal> MealsToAddToDatabase = new List<Meal>()
                {
                    GirlDinner,
                    ChickenStirFry,
                    PastaWithPesto,
                    BuffaloChicken,
                    GrilledCheese,
                    TurkeyBLTA,
                    CapreseSalad
                };

        await sousChefDbContext.Ingredients.AddRangeAsync(IngredientsToAddToDatabase);
        await sousChefDbContext.Meals.AddRangeAsync(MealsToAddToDatabase);
        await sousChefDbContext.SaveChangesAsync();
        }
    }
}