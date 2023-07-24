using Marten;
using System.Text.Json.Serialization;
using TodosApi;
using TodosApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); // Microsoft stuff for creating instance of controllers ,etc.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dataConnectionString = builder.Configuration.GetConnectionString("todos") ?? throw new Exception("Need a database connection string");
Console.WriteLine($"Using the connection string {dataConnectionString}");

builder.Services.AddMarten(options =>
{
    options.Connection(dataConnectionString);



    options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All; // good for development, it creates the whole database.
});


// This says "Hey MVC, if you create anything that needs an IManageTheTodoListCatalog, use the MartinTodoListCatalog
builder.Services.AddTransient<IManageTheTodoListCatalog, MartenTodolistCatalog>();



// Everything above this line is configuring "Services" in our application.
var app = builder.Build();
// This is all configuring the "middleware" (this stuff down) - this is code that will see the incoming HTTP request
// and make a response

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // This is the OpenApi. This generates the documentation which is a JSON file (called a "Swagger file)
    app.UseSwaggerUI(); // Adds middleware that lets you interact with the documentation
}

app.UseAuthorization();

app.MapControllers(); // The Api, during startup, is going to look at all our Controller classes, read those attributes
// and create a "route table" - like a phone list that an old switch operator might have. e.g., TodoListController

/*
app.MapGet("/todo-list", () =>
{   
    return Results.Ok("Coming Soon");
});
*/

app.Run(); // start the Kestrel web server and listen for requests
