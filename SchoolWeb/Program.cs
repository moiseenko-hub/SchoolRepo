using Microsoft.EntityFrameworkCore;
using StoreData;
using StoreData.Models;
using StoreData.Repostiroties;
using StoreData.Repostiroties.School;
using WebStoryFroEveryting.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(SchoolAuthService.AUTH_TYPE)
    .AddCookie(SchoolAuthService.AUTH_TYPE, config =>
    {
        config.LoginPath = "/SchoolAuth/Login";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddDbContext<SchoolDbContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SchoolDbContext))));
//builder.Services.AddScoped<LessonRepository>();

builder.Services.AddScoped<LessonRepository>();
builder.Services.AddScoped<LessonCommentRepository>();
builder.Services.AddScoped<BanWordRepository>();
builder.Services.AddScoped<BannedUserRepository>();

builder.Services.AddScoped<LessonRepository>();

builder.Services.AddScoped<SchoolUserRepository>();
builder.Services.AddScoped<SchoolRoleRepository>();
builder.Services.AddScoped<SchoolAuthService>();

builder.Services.AddHttpContextAccessor();




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

app.UseAuthentication(); // Who you are?
app.UseAuthorization();  // May I in?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
