using MessagingService.src.Repositories;
using MessagingService.src.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEvents();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/messages", async (MessageRepository repo) => await repo.GetAllAsync())
   .WithName("GetAllMessages")
   .WithOpenApi();

app.Run();