using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreDBContext>(options => {
    options.UseInMemoryDatabase(databaseName:"BookStoreDB");
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();

var app = builder.Build();
// using(var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     DataGenerator.Initialize(services);
// }
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
DataGenerator.Initialize(services);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//my custom middleware
app.UseCustomExceptionMiddleware();

app.MapControllers();

app.Run();
