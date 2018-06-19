
using System;
using BillboardClient.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.Endpoint.CloudFoundry;
using Steeltoe.Management.Endpoint.Health;

namespace BillboardClient
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // register services into container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDiscoveryClient(_configuration);
            services.AddHealthActuator(_configuration);
            services.AddHttpClient("message-service", c =>
            {
                c.BaseAddress = new Uri("http://message-service/");
            })
                .ConfigurePrimaryHttpMessageHandler(provider => new DiscoveryHttpClientHandler(provider.GetRequiredService<IDiscoveryClient>()))
                .AddTypedClient<QuoteService>();

            services.AddMvc();
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
        }
    }
}
