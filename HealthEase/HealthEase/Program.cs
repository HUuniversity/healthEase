using HealthEase.Models;
using HealthEase.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Admin = HealthEase.Models.Adminn;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddControllersWithViews();*/

builder.Services.AddMvc(x => x.EnableEndpointRouting = false);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IRepository<Adminn>,DbAdminnnRepository>();
builder.Services.AddScoped<IRepository<Appointment>, DbAppointmentRepository>();
builder.Services.AddScoped<IRepository<Department>, DbDepartmentRepository>();
builder.Services.AddScoped<IRepository<Doctor>, DbDoctorRepository>();
builder.Services.AddScoped<IRepository<Patient>, DbPatientRepository>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Account/Login";
});
builder.Services.AddDbContext<AppDbContext>(x =>
{

    x.UseSqlServer(builder.Configuration.GetConnectionString("sqlCon"));


});


builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;



});



var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}*/
/*app.UseHttpsRedirection();*/
app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Register}/{Id?}"
            );

});

app.Run();
