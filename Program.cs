using Blazored.Modal;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MusicShop.Components;
using MusicShop.Data;
using MusicShop.Repositories;
using MusicShop.Services;
using MusicShop.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped(typeof(IDataStore<>), typeof(DataStore<>));
builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IInstrumentService, InstrumentService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ISessionBuyerService, SessionBuyerService>();

builder.Services.AddValidatorsFromAssemblyContaining<OrderFormValidator>();
builder.Services.AddBlazoredModal();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ShopContext>();
    try
    {
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка применения миграций БД музыкального магазина");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
