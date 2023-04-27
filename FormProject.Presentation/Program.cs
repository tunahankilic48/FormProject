using Autofac;
using Autofac.Extensions.DependencyInjection;
using FormProject.Application.IoC;
using FormProject.Domain.Entities;
using FormProject.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); // Program çalýþýrken düzenleme yapýlabilmesi için razor runtime compilation paketi yüklendi ve burada sisteme dahil edildi.

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connection string will be taken from appsettings.json file

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); // Identity user kullanýldýðý için user konfigürasyon iþlemleri burada yapýldý. Giriþin kolay olmasý için kýsýtlamalar en aza indirildi.


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
}); // Dependency injection için kullanýlan container burada implimente edildi.



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

app.UseAuthentication(); // Giriþ yapýldýðý zaman sayfalara ulaþýlabilmesi için gerekli element eklendi.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=form}/{action=index}/{id?}");

app.Run();
