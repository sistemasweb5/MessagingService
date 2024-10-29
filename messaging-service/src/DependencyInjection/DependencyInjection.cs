using MessagingService.src.EventHandlers;
using MessagingService.src.Events;
using MessagingService.src.Events.Interfaces;
using MessagingService.src.Repositories;
using MongoDB.Driver;

namespace MessagingService.src.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddMongoDb(configuration)
            .AddRepositories();
        return services;
    }

    private static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoConnectionString = configuration.GetConnectionString("MongoDbConnection");
        var mongoClient = new MongoClient(mongoConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);

        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddSingleton(mongoDatabase);

        return services;
    }

    public static IServiceCollection AddEvents(this IServiceCollection services)
    {
        services.AddSingleton<IEventBus, EventBus>();
        services.AddTransient<NewMessageEventHandler>();
        services.AddTransient<MesageSentEventHandler>();
        services.AddTransient<MessageReadEventHandler>();
        services.AddTransient<UserConnectedEventHandler>();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ChannelRepository>();
        services.AddScoped<MessageRepository>();
        services.AddScoped<UserRepository>();

        return services;
    }
}
