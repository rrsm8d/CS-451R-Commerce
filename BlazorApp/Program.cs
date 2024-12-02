using BlazorApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<BlazorAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorAppContext") ?? throw new InvalidOperationException("Connection string 'BlazorAppContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddSingleton<BlazorApp.Services.OllamaService>();




// Authentication?
// I was following this video here: https://www.youtube.com/watch?v=GKvEuA80FAE
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token"; // Custom cookie name
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromDays(7);
        options.AccessDeniedPath = "/access-denied";
    });
// Authorization
builder.Services.AddAuthorization();
// Passing the authentication state thoughout the application
builder.Services.AddCascadingAuthenticationState();


//Blazor Bootstrap service
builder.Services.AddBlazorBootstrap();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

// Also for authentication and authorization
// https://www.youtube.com/watch?v=GKvEuA80FAE
app.UseAuthentication();
app.UseAuthorization();
// For some reason this has to be after authentication. If antiforgery issues are giving you trouble, this is the place to temporarily (or permanently) comment out
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
