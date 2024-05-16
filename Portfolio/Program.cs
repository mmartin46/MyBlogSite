using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Razor;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Repositories;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDatabaseContext>(options => options.UseSqlServer(
    "Server=.;Database=Apps;Encrypt=False;Trusted_Connection=True;"
));

builder.Services.AddDbContext<SenderDatabaseContext>(options => options.UseSqlServer(
    "Server=.;Database=AllSenders;Encrypt=False;Trusted_Connection=True;"
));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<Portfolio.Services.IEmailSender, EmailSender>();

builder.Services.AddScoped<IAppRepository, AppRepository>();
builder.Services.AddScoped<ISenderRepository, SenderRepository>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
