using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using User.Microservice.Application.Behaviours;
using User.Microservice.Infrastructure.Data;
using User.Microservice.Infrastructure.Mapper;
using User.Microservice.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddDbContext<ApplicationCommandDBContext>(options =>
options.UseNpgsql(
       builder.Configuration.GetConnectionString("WebApiCommandDatabase"),
       b => b.MigrationsAssembly(typeof(ApplicationCommandDBContext).Assembly.FullName)));
builder.Services.AddScoped<IApplicationCommandDBContext>(provider => provider.GetService<ApplicationCommandDBContext>());
builder.Services.AddScoped<IDummyJsonRepository, DummyJsonRepository>();
builder.Services.AddDbContext<ApplicationQueryDBContext>(options =>
options.UseNpgsql(
   builder.Configuration.GetConnectionString("WebApiQueryDatabase"),
   b => b.MigrationsAssembly(typeof(ApplicationQueryDBContext).Assembly.FullName)));
builder.Services.AddScoped<IApplicationQueryDBContext>(provider => provider.GetService<ApplicationQueryDBContext>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionLoggingBehaviour<,,>));
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "User.Microservice");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var contextcommand = services.GetRequiredService<ApplicationCommandDBContext>();
    if (contextcommand.Database.GetPendingMigrations().Any())
    {
        contextcommand.Database.Migrate();
    }
    var contextquery = services.GetRequiredService<ApplicationQueryDBContext>();
    if (contextquery.Database.GetPendingMigrations().Any())
    {
        contextquery.Database.Migrate();
    }
}
app.Run();


