using Microsoft.EntityFrameworkCore;
using TaskManager.Server.DataAccess;
using TaskManager.Server.App.Web.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();

// Get Connection string from app settings 
var connectionString = builder.Configuration.GetConnectionString("Default");
// Using AddPooledDbContextFactory instead of AddDbContext
// Registering a factory instead of registering the context type directly allows for easy creation of new TaskManagerDBContext instances 
// Registering a factory is recommended where the dependency injection scope is not aligned with the context lifetime.
// Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance.
// This includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
// Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute in parallel
builder.Services.AddPooledDbContextFactory<TaskManagerDBContext>(options =>
                options.UseSqlServer(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

//GraphQLServer 
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapGraphQL();
}
// Configure the HTTP request pipeline.
app.UseGraphQLVoyager("/graphql-voyager");
app.UseWebSockets();
app.UseHttpsRedirection();

app.Run();
