using Liftr.Components;
using Microsoft.EntityFrameworkCore;
using Tailwind;

var builder = WebApplication.CreateBuilder(args);

// TODO: read config 
builder.Services.AddDbContextFactory<LiftrContext>(opt =>
    opt.UseNpgsql(@"Host=localhost;Username=user;Password=password;Database=liftr_db;Port=5433"));

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
}

if (app.Environment.IsDevelopment())
{
    app.RunTailwind("tailwind", "./");
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
