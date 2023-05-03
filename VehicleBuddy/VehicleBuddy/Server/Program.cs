using Microsoft.AspNetCore.ResponseCompression;
using VehicleBuddy.Server.Data;
using VehicleBuddy.Server.Data.Interfaces;
using VehicleBuddy.Server.Repositories;
using VehicleBuddy.Server.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    builder.Services.AddTransient<IDbConnectionFactory, SqlConnectionFactory>();
    builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
}



var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();


    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html");
}
app.Run();
