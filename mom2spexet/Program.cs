var builder = WebApplication.CreateBuilder(args);

// Activate MVC.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Activate static files
app.UseStaticFiles();

// Activate routing
app.UseRouting();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
