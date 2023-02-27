using JupiterRoverExercise;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//DI 
builder.Services.AddSingleton<IRover, Rover>();
builder.Services.AddTransient<IRoverService, RoverService>();

//Setup Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jupiter Rover API", Version = "v1" });
});

//Setup Text.Json serializer
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

//Setup Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jupiter Rover Controlls API V1");
    });
}

//Register endpoints
app.MapGet("rover/possition", (IRoverService roverService) => Results.Ok(roverService.GetPossition().FromTupleToRoverPossitionModel()))
   .Produces<RoverPossitionModel>()
   .WithOpenApi(operation => new(operation)
   {
       Summary = "Get current rover possition"
   });

app.MapPost("rover/possition/reset", (IRoverService roverService) =>
{
    roverService.ResetPossition(); return Results.Ok(roverService.GetPossition().FromTupleToRoverPossitionModel());
}).Produces<RoverPossitionModel>()
  .WithOpenApi(operation => new(operation)
  {
      Summary = "Reset rover possition to the default (X: 0 ,Y: 0 ,Direction: N)"
  });

app.MapPost("rover/commands/bulk", (string commands, IRoverService roverService) =>
{
    try
    {
        roverService.ValidateAndExecuteCommandsFromCommandsString(commands);
    }
    catch (InvalidCommandsListException invalidCommandsListException)
    {
        return Results.BadRequest(invalidCommandsListException.Message);
    }

    return TypedResults.Ok(roverService.GetPossition().FromTupleToRoverPossitionModel());
}).Produces<RoverPossitionModel>()
  .Produces<BadRequest>(400)
  .WithOpenApi(operation => new(operation)
  {
      Summary = "Execute list of rover commands"
  });

app.Run();