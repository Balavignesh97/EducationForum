using Microsoft.EntityFrameworkCore;
using EducationForum.DataAccess;
using EducationForum.Services.Interface;
using EducationForum.Services;
using EducationForum.Repository.Interface;
using EducationForum.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextPool<EForumDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EForumConnection"),b => b.MigrationsAssembly("EducationForum"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<ICoursesServices,CoursesServices>();
builder.Services.AddScoped<ICoursesRepository,CoursesRepository>();
builder.Services.AddScoped<ISubjectServices, SubjectServices>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
