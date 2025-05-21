using Hangfire;
using Hangfire.Console;
using Hangfire.PostgreSql;
using HangRabbit.Hangfire.Jobs;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(x => x.UseNpgsqlConnection(connectionString)).UseConsole());

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();


builder.Services.AddMassTransit(busConfigurator =>
{
    var entryAssembly = Assembly.GetExecutingAssembly();

    busConfigurator.AddConsumers(entryAssembly);
    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        config.ConfigureEndpoints(context);
    });
});




builder.Services.AddScoped<ITestJob, TestJob>();
builder.Services.AddScoped<ITestRecurringJob, TestRecurringJob>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<ITestRecurringJob>("Test Recurring Job", x => x.DoRecurringThing(CancellationToken.None, null), "0 2 * * *", new RecurringJobOptions { TimeZone = TimeZoneInfo.Local });

app.Run();