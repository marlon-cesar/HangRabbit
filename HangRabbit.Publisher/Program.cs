using HangRabbit.Models;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/test", async (IBus bus, CancellationToken CancellationToken) =>
{
    await bus.Publish(new TestEvent { CreatedAt = DateTime.UtcNow, Description = "Test event", EventId = Guid.NewGuid() }, CancellationToken);
    return Results.Created();
});

app.Run();
