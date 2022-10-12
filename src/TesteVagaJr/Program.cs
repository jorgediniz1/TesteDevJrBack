using Microsoft.EntityFrameworkCore;
using TesteVagaJr.Domain.Repositories;
using TesteVagaJr.Infrastructure;
using TesteVagaJr.Infrastructure.Repositories;
using TesteVagaJr.Services;
using TesteVagaJr.Services.Interfaces;
using TesteVagaJr.Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));
builder.Services.AddAutoMapper(typeof(EmpresaProfile).Assembly);
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
