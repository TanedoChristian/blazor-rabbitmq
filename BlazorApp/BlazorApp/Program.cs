using DotNetEnv;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using BlazorApp.Repositories.UserRepository;
using BlazorApp.Services;
using BlazorApp.Pages;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<RabbitMQService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddSingleton<ContactOverview>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

DotNetEnv.Env.Load();

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
