using Core;
using Core.Controllers;
using Core.Entities;
using Core.Extensions;
using Core.Mappings;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<e_learningContext>(options =>
    options.UseMySql(builder.Configuration["DbConnections:MySqlConnection"],ServerVersion.Parse("5.0.7"))
);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddExtService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
