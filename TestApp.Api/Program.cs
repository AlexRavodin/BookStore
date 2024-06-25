using BookStoreTest.Api.Services.Books;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestApp.Api.Data;
using TestApp.Api.Extensions;
using TestApp.Api.Helpers;
using TestApp.Api.Repositories.Books;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(c => c.UseNpgsql(
    connectionString: builder.Configuration.GetConnectionString("UsersDb")));

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy  =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithExposedHeaders("X-Pagination");
        });
});*/

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.User.RequireUniqueEmail = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        }
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Constants.Moderator, pb => 
        pb.RequireClaim("level", Constants.Moderator));
    options.AddPolicy(Constants.Admin, pb => 
        pb.RequireClaim("level", Constants.Admin));
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

var app = builder.BuildWithSpa();

app.Run();