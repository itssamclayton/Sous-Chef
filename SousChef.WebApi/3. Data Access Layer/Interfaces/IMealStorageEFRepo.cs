using System;

namespace SousChef.WebApi._3._Data_Access_Layer.Interfaces;

public interface IMealStorageEFRepo
{
    public Task PopulateInitialMealsAsync();
}
