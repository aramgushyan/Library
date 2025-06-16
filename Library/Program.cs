using Library.Domain.Interfaces;
using Library.Extensions;
using Library.Infastructure;
using Library.Infastructure.Extensions;
using Library.Infastructure.Repository;
using Library.Middlewares;
using Library.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddContext(builder.Configuration);

builder.Services.AddLibraryMap();
builder.Services.AddLibraryRepository();
builder.Services.AddLibraryServices();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
