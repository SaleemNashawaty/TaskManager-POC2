using TaskManager.Client.Bus;
using TaskManager.Client.Business.Handlers;
using TaskManager.Client.Core.Constants;
using TaskManager.Client.GraphQL.Lib.Extension;
using TaskManager.Client.Providers;
using TaskManager.Client.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly((typeof(GetTaskQueryHandler).Assembly)));
        services.AddGraphQLClient(configuration, AppConstants.GatewayApiKey);
        services.AddProviders();
        services.AddSignalR();
        services.AddServiceBus();
        services.AddWorkers();
    })
    .Build();

await host.RunAsync();