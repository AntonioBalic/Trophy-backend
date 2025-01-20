using AntonioBalic_Lab_07.Logic;
using AntonioBalic_Lab_07.Repositories;
using AntonioBalic_Lab_07.Configuration;
using AntonioBalic_Lab_07.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorFilter>(); // Register globally
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITrophyRepository, TrophySqlRepository>();
builder.Services.AddSingleton<ITrophyLogic, TrophyLogic>();

builder.Services.Configure<DBConfiguration>(builder.Configuration.GetSection("Database"));
builder.Services.Configure<ValidationConfiguration>(builder.Configuration.GetSection("Validation"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
