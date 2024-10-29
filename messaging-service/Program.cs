using MongoDB.Driver;
using MessagingService.src.Repositories;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetValue<string>("MongoDB:ConnectionString");
var mongoClient = new MongoClient(mongoConnectionString);
var database = mongoClient.GetDatabase(builder.Configuration.GetValue<string>("MongoDB:DatabaseName"));

builder.Services.AddSingleton(database);

builder.Services.AddScoped<MessageRepository>();

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