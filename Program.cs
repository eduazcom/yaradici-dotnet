using Microsoft.EntityFrameworkCore;
using YaradiciEduAz.Abstractions.IRepositories.IEntityRepositories;
using YaradiciEduAz.Abstractions.IServices;
using YaradiciEduAz.Abstractions.IUnitOfWorks;
using YaradiciEduAz.Contexts;
using YaradiciEduAz.Implementations.Repositories.EntityRepositories;
using YaradiciEduAz.Implementations.Services;
using YaradiciEduAz.Implementations.UnitOfWorks;
using YaradiciEduAz.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config));

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


var app = builder.Build();

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
