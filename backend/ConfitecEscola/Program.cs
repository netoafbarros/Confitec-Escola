using AutoMapper;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using ConfitecEscola.Core.Repositories.Base;
using ConfitecEscola.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Database connection
var connectionString = builder.Configuration.GetConnectionString("dbEscola");
builder.Services.AddDbContext<ConfitecEscolaContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IValidationService, ValidationService>();
// Adding MediatR
builder.Services.AddMediatR();

// Adding repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IEscolaridadeRepository, EscolaridadeRepository>();
builder.Services.AddTransient<IHistoricoEscolarRepository, HistoricoEscolarRepository>();
builder.Services.AddTransient<IUsuarioHistoricoEscolarRepository, UsuarioHistoricoEscolarRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c => {
//    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
//    c.IgnoreObsoleteActions();
//    c.IgnoreObsoleteProperties();
//    c.CustomSchemaIds(type => type.FullName);
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowEverything", // This just for the test
        builder =>
        {
            builder.WithOrigins("https://localhost:7156")
                .AllowAnyOrigin() // Any origin is welcome...
                .AllowAnyHeader() // With any type of headers...
                .AllowAnyMethod(); // And any HTTP methods. Such a jolly party indeed!
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
