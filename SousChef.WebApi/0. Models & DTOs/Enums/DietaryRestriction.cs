namespace SousChef.WebApi._0._Models___DTOs;

[Flags]
/*
    This [Flags] annotation in combination with the numerical values assigned to each enum value below
    allow for combinations of restrictions to be selected. Using an enum is better here than having
    individual boolean properties on the User class (e.g., isGlutenFree = true) because if we want to
    add additional restriction options, we can do it here instead of having to go in and modify the
    User class at all. If we did the boolean properties on the User class itself, we'd have to add in the
    new boolean property (isNewDietFad) and then we'd have to have a way for this value to be set to true
    or false both by default and then for each individual user.
*/
public enum DietaryRestriction
{
    None = 0,
    GlutenFree = 1,
    DairyFree = 2,
    Vegan = 4,
    Vegetarian = 8,
    NutFree = 16,
    Paleo = 32
}
