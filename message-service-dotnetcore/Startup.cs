using System;
using MessageService.Repositories;
using MessageService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.Endpoint.Health;

namespace MessageService
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // register services into container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDiscoveryClient(_configuration);
            services.AddDbContext<QuoteRepository>(options => options.UseSqlite(_configuration.GetConnectionString("quotedb")));
            services.AddHealthActuator(_configuration);
            services.AddSingleton<ExampleHealthIndicator>();
            services.AddSingleton<IHealthContributor>(x => x.GetService<ExampleHealthIndicator>());

            services.AddMvc();
            return services.BuildServiceProvider(validateScopes: false);
        }

        // activate services & setup middleware
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHealthActuator();
            app.UseStaticFiles();
            app.UseMvc();
            
            app.UseDiscoveryClient();
            app.EnsureMigrationOfContext<QuoteRepository>();
        }
    }

    public static class EnsureMigration
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            var context = app.ApplicationServices.GetService<T>();
            context.Database.Migrate();
        }
    }
}
