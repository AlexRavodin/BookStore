using Microsoft.EntityFrameworkCore;
using BookStore.Api.Data;
using BookStore.Api.Extensions;
using BookStore.Api.Repositories.Authors;
using BookStore.Api.Repositories.Books;
using BookStore.Api.Repositories.Genres;
using BookStore.Api.Repositories.Images;
using BookStore.Api.Services.Authors;
using BookStore.Api.Services.Books;
using BookStore.Api.Services.Carts;
using BookStore.Api.Services.Images;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(c => c.UseNpgsql(
    connectionString: builder.Configuration.GetConnectionString("UsersDb")));

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

//TODO set for production
//builder.AddCors();
builder.AddCustomIdentity();
builder.AddCustomPolices();
builder.AddValidation();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddControllers();
//TODO check if needed
//builder.Services.AddHttpContextAccessor();

var app = builder.BuildWithSpa();
app.SeedDefaultUsers();
app.UseSerilogRequestLogging();

app.Run();