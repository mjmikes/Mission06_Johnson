using Microsoft.EntityFrameworkCore;
using Mission06_Johnson.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Ensure we are loading the correct database
var connectionString = builder.Configuration.GetConnectionString("MovieFormConnection") 
                       ?? "Data Source=JoelHiltonMovieCollection.sqlite"; // Fallback if missing

// ✅ Use the correct SQLite database
builder.Services.AddDbContext<MovieFormContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Apply pending migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MovieFormContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();