
using TaskManager.Services.Business;
using TaskManager.Services.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly((typeof(SendEmailQueryHandler).Assembly)));
        services.AddSignalR();
        services.AddWorkers();
    })
    .Build();

await host.RunAsync();