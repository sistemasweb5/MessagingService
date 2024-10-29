using MessagingService.src.Data.Interfaces;
using MessagingService.src.EventHandlers;
using MessagingService.src.Events;
using MessagingService.src.Events.Interfaces;

namespace MessagingService.src.RequestPipeline;

public static class WebApplicationExtensions
{
    public static WebApplication InitializeDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();

            dbInitializer.InitializeDatabase();

            return app;
        }
    }

    public static WebApplication InitializeEventHandlers(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var eventBus = scope.ServiceProvider.GetRequiredService<IEventBus>();
            var messageSentHandler = scope.ServiceProvider.GetRequiredService<MesageSentEventHandler>();
            var messageReadHandler = scope.ServiceProvider.GetRequiredService<MessageReadEventHandler>();
            var userConnectHandler = scope.ServiceProvider.GetRequiredService<UserConnectedEventHandler>();

            eventBus.Subscribe<MessageSentEvent>(messageSentHandler.Handle);
            eventBus.Subscribe<MessageReadEvent>(messageReadHandler.Handle);
            eventBus.Subscribe<UserConnectedEvent>(userConnectHandler.Handle);

            return app;
        }
    }
}
