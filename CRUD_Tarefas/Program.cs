using CRUD_Tarefas.Configurations;
using CRUD_Tarefas.Middlewares;
using Domain.Interfaces.Datas;
using Domain.Interfaces.Services;
using Infrastructure.Data.Repository;
using Service.Mapper;
using Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ListaTarefaMapper).GetTypeInfo().Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddHealthChecksConfig(builder.Configuration);
builder.Services.AddTransient<ExceptionValidatorMiddleware>();
builder.Services.AddEntityFramework(builder.Configuration);

//Inject Services
builder.Services.AddScoped<IListaTarefaService, ListaTarefaService>();

//Inject Repositories
builder.Services.AddScoped<IListaTarefaRepository, ListaTarefaRepository>();
builder.Services.AddScoped<IListaTarefaAggregateRepository, ListaTarefaAggregateRepository>();

var app = builder.Build();

app.UseSwaggerConfig();
app.UseHealthChecksConfig();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCustomExceptionMiddleware();

app.Run();