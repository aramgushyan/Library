using Library.Domain.Interfaces;
using Library.Extensions;
using Library.Infastructure;
using Library.Infastructure.Extensions;
using Library.Infastructure.Repository;
using Library.Middlewares;
using Library.Application.Extensions;
using Library.Application;
using Library.Services.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Services.AddHttpLogging(logging => {});

builder.Services.AddContext(builder.Configuration);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddLibraryMap();
builder.Services.AddLibraryRepository();
builder.Services.AddLibraryServices();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseHttpLogging();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
