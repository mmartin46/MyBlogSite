using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Razor;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Repositories;
using Portfolio.Services;
using Portfolio.Mapping;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddDbContext<AppDatabaseContext>(options => options.UseSqlServer(
    configuration.GetConnectionString("AppConnection")
));

builder.Services.AddDbContext<SenderDatabaseContext>(options => options.UseSqlServer(
    configuration.GetConnectionString("SenderConnection")
));

// Add services to the container.


builder.Services.AddControllersWithViews();

builder.Services.AddTransient<Portfolio.Services.IEmailSender, EmailSender>();

builder.Services.AddScoped<IAppRepository, AppRepository>();
builder.Services.AddScoped<ISenderRepository, SenderRepository>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


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
