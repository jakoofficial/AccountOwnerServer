﻿using Contracts;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace AccountOwnerServer.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options => 
        {

        });          
    }
    
    public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
    {
        //var connectionString = config["mssqlconnection:connectionString"];
        var connectionString = config["MyConnection:connectionString"];

        services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString, x => x.MigrationsAssembly("Entities")));
    }
    
    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
    
    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}