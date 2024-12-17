using Microsoft.EntityFrameworkCore;
using EducationForum.DataAccess;
using EducationForum.Services.Interface;
using EducationForum.Services;
using EducationForum.Repository.Interface;
using EducationForum.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<EForumDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EForumConnection"),b => b.MigrationsAssembly("EducationForum"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICoursesServices,CoursesServices>();
builder.Services.AddScoped<ICoursesRepository,CoursesRepository>();
builder.Services.AddScoped<IContactServices, ContactServices>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IDashboardServices, DashboardServices>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(60));

var app = builder.Build();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Dashboard}/{id?}");

app.Run();
