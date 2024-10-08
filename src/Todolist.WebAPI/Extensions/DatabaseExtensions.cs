using Microsoft.EntityFrameworkCore;
using Todolist.Infrastructure.Data.Context;

namespace Todolist.WebAPI.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodolistDbContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
