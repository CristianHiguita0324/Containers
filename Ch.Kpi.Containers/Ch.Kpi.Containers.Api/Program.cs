using Ch.Kpi.Containers.Aplication.Interfaces;
using Ch.Kpi.Containers.Aplication.Services;
using Ch.Kpi.Containers.DataAccess.Context;
using Ch.Kpi.Containers.DataAccess.Interfaces;
using Ch.Kpi.Containers.DataAccess.Persistence;
using Ch.Kpi.Containers.DataAccess.Repositories;
using Ch.Kpi.Containers.DataAccess.UoW;
using Ch.Kpi.Containers.Domain.Interfaces;
using Ch.Kpi.Containers.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.AddTransient<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddTransient<IStatsAplication, StatsAplication>();
builder.Services.AddTransient<IStatsDomain, StatsDomain>();
builder.Services.AddTransient<IContainerAplication, ContainerAplication>();
builder.Services.AddTransient<IContainerDomain, ContainerDomain>();





MongoDbPersistence.Configure();

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
