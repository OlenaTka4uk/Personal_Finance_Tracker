using NLog;
using PersonalFinance.Extensions;
using PersonalFinance.Service.Interfaces.Logger;
using PersonalFinance.Extensions;
using PersonalFinance.Service.Services.Logger;
using PersonalFinance.Persistense.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RepositoryContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});
// Logger
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();

builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI

//builder.Services.AddScoped<ILoggerManager, LoggerManager>();


// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
