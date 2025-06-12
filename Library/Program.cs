using Library.Domain.Interfaces;
using Library.Infastructure;
using Library.Infastructure.Repository;
using Library.Services;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LibraryDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultString")));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler(o => o.Run(
    async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/plain";

        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();

        if (null != exceptionObject)
        {
            var errorMessage = $"Error: {exceptionObject.Error.Message}";
            await context.Response.WriteAsync(errorMessage);

        }
    }
));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
