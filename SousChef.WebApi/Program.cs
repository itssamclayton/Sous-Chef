using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using SousChef.WebApi._2._Service_Layer;
using SousChef.WebApi._2._Service_Layer.Interfaces;
using SousChef.WebApi._3._Data_Access_Layer;
using SousChef.WebApi._3._Data_Access_Layer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables form the .env file
// Remove this when I move to Azure
Env.Load();

// Get the connection string from the environment variable
string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
// CORS policy goes somewhere around here (whatever that means)

// Add services to the container.
builder.Services.AddDbContext<SousChefDbContext>(options =>options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserStorageEFRepo, UserStorageEFRepo>();
builder.Services.AddScoped<IMealStorageEFRepo, MealStorageEFRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UserCores(whateverInametheCORSPolicy);

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var mealService = scope.ServiceProvider.GetRequiredService<IMealStorageEFRepo>();
    await mealService.PopulateInitialMealsAsync();
}
app.Run();
