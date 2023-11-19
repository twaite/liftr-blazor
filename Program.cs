using Liftr.Components;
using Microsoft.EntityFrameworkCore;
using Tailwind;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// TODO: read config 
builder.Services.AddDbContextFactory<LiftrContext>(opt =>
    opt.UseNpgsql(@"Host=localhost;Username=user;Password=password;Database=liftr_db;Port=5433"));

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = BearerTokenDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddBearerToken()
    .AddGoogle(options =>
    {
        options.ClientId = "1063057726088-3svpnq2q35nq7738k20o44phu3gdtb3i.apps.googleusercontent.com";
        options.ClientSecret = "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";
        options.SaveTokens = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.RunTailwind("tailwind", "./");
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
