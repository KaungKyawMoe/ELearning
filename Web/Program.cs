using Core;
using Core.Controllers;
using Core.Entities;
using Core.Extensions;
using Core.Mappings;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Hangfire;
using Hangfire.MySql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<Context>(options =>
{
    options.UseMySql(builder.Configuration["DbConnections:MySqlConnection"], ServerVersion.Parse("5.0.7"));
});

// Add Hangfire services
var hangfireConnection = builder.Configuration["DbConnections:HangfireConnection"];
builder.Services.AddHangfire(configuration =>
            configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseStorage(new MySqlStorage(
                    hangfireConnection,
                    new MySqlStorageOptions
                    {
                        InvisibilityTimeout = TimeSpan.FromHours(4),
                        TablesPrefix = "hangfire_"
                    })));

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

//builder.Services.AddDbContext<Context>(options =>
//    options.UseMySql(builder.Configuration["DbConnections:MySqlConnection"],ServerVersion.Parse("5.0.7"))
//);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "XSRF-TOKEN";
    options.SuppressXFrameOptionsHeader = false;
});

builder.Services.AddExtService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Add Hangfire Dashboard
app.UseHangfireDashboard();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
