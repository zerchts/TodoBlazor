using Microsoft.EntityFrameworkCore;
using TodoBlazor.Components;
using TodoBlazor.Data;
using TodoBlazor.Models;

var builder = WebApplication.CreateBuilder(args);

// Razor Components (Blazor Web App)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // kita pakai server interactivity

// EF Core + SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Mount komponen root (App.razor) sebagai endpoint
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

// (opsional) auto apply migrations/ create db
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
