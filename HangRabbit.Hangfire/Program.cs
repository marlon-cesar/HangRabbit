using Hangfire;
using Hangfire.Console;
using Hangfire.PostgreSql;
using HangRabbit.Hangfire.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(x => x.UseNpgsqlConnection("Host=localhost;Port=5432;Database=Erick;User Id=postgres;Password=admin;")).UseConsole());

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

builder.Services.AddScoped<ITestJob, TestJob>();
builder.Services.AddScoped<ITestRecurringJob, TestRecurringJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<ITestRecurringJob>("Test Recurring Job", x => x.DoRecurringThing(CancellationToken.None, null), "0 2 * * *", new RecurringJobOptions { TimeZone = TimeZoneInfo.Local });

app.Run();