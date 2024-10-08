
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todolist.Application.Behaviors;
using Todolist.Application.ObjectMapping;
using Todolist.Application.UseCases.Queries.ListarProjetosUsuario;
using Todolist.Domain.Repositories;
using Todolist.Infrastructure.Data.Context;
using Todolist.Infrastructure.Data.Repository;
using Todolist.WebAPI.Extensions;
using Todolist.WebAPI.Middleware;

namespace Todolist.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDatabaseConfiguration(builder.Configuration);

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
            builder.Services.AddScoped<IRelatorioDesempenhoRepository, RelatorioDesempenhoRepository>();


            builder.Services.AddValidatorsFromAssemblyContaining<ListarProjetosUsuarioQueryValidator>();

            builder.Services.AddAutoMapper(typeof(ProjetoProfile));


            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ListarProjetosUsuarioHandler>();
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainExceptionBehavior<,>));


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TodolistDbContext>();
                try
                {
                    dbContext.Database.Migrate(); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao aplicar migrações: {ex.Message}");
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseMiddleware<ValidationExceptionMiddleware>();


            app.UseHttpsRedirection();
   
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
