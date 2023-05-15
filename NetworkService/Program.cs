using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using NetworkService.Data;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

var DatabaseConfig = builder.Configuration.GetSection(nameof(NetworkService.Models.DatabaseConfig)).Get<NetworkService.Models.DatabaseConfig>();

builder.Services.AddDbContext<NetworkServiceDbContext>(option => option.UseMySql(
    DatabaseConfig.ConnectionString,
    ServerVersion.Parse(DatabaseConfig.DBVersion)
));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<QueryService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
