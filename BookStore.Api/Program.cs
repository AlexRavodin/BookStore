using Microsoft.EntityFrameworkCore;
using BookStore.Api.Data;
using BookStore.Api.Extensions;
using BookStore.Api.Repositories.Books;
using BookStore.Api.Services.Books;
using BookStore.Api.Services.Carts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(c => c.UseNpgsql(
    connectionString: builder.Configuration.GetConnectionString("UsersDb")));

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

//builder.AddCors();
builder.AddCustomIdentity();
builder.AddCustomPolices();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

var app = builder.BuildWithSpa();
app.SeedDefaultUsers();
app.UseSerilogRequestLogging();

app.Run();