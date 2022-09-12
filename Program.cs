using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using VisitorManagement.Data;
using VisitorManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


//Singleton creates a single instance once and reuses the same object in all calls. Use Singletons where you need to maintain application wide state, for example, application configuration, logging service, caching of data, etc.
//Singletons are memory efficient as they are created once and reused everywhere.
builder.Services.AddTransient<ITextFileOperations, TextFileOperations>();

// adding the DBCalls class to the program
builder.Services.AddTransient<IDBCalls, DBCalls>();


//adding the dataSeeder class to the program  Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services. Since they are created every time, they will use more memory & resources and can have negative impact on performance.
builder.Services.AddTransient<IDataSeeder, DataSeeder>();

//Scoped lifetime services are created once per request. For example, in MVC it creates one instance for each HTTP request, but it uses the same instance in the other calls within the same web request.

//not used yet


//Adding automapper to the program  

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
