using DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using Model;
using Web_API.Servicies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���������� ���� ������.
builder.Services.AddDbContext<ApplicationContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// ���������� ��������.
builder.Services.AddScoped<CreationService>();
builder.Services.AddScoped<DataAccessService>();
builder.Services.AddScoped<BrowseService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseCors(policyBuilder =>
policyBuilder.WithOrigins("http://localhost:5173").AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
