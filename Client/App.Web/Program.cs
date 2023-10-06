using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using TaskManager.Client.App.SignalR;
using TaskManager.Client.Bus;
using TaskManager.Client.Business.Handlers;
using TaskManager.Client.Core.Constants;
using TaskManager.Client.GraphQL.Lib.Extension;
using TaskManager.Client.Providers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200", "https://localhost:44303")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services
    .AddMvc()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy=null);
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly((typeof(GetTaskQueryHandler).Assembly)));
builder.Services.AddGraphQLClient(builder.Configuration, AppConstants.GatewayApiKey);
builder.Services.AddServiceBus();
builder.Services.AddSignalR();
builder.Services.AddProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseRouting();
app.UseCors("CorsPolicy"    );
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Environment.CurrentDirectory),
    RequestPath = new PathString("")
});
app.MapControllers();
app.MapHub<TaskManagerSignalRHub>("/taskManagerHub");
app.Run();
