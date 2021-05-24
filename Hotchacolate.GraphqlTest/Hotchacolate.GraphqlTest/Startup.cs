using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotchacolate.GraphqlTest.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance.CosmosDb;
using Persistance.CosmosDb.Implementation;

namespace Hotchacolate.GraphqlTest
{
    public class Startup
    {
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _containerName;
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _connectionString = configuration.GetConnectionString("CosmosDbConnectionString");
            _databaseName = configuration.GetValue<string>("DatabaseName");
            _containerName = configuration.GetValue<string>("ContainerName");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var cosmosOptions = new CosmosClientOptions() { ApplicationRegion = Regions.EastUS2 };
            var cosmosClient = new CosmosClient(_connectionString, cosmosOptions);
            var database = cosmosClient.GetDatabase(_databaseName);

            services.AddGraphQLServer()
                .AddQueryType<ReceiptScanQueries>()
                .AddFiltering()
                .AddSorting()
                .SetRequestOptions(_ =>
                    new HotChocolate.Execution.Options.RequestExecutorOptions
                    {
                        ExecutionTimeout = TimeSpan.FromMinutes(3)
                    });

            services.AddSingleton<IReceiptsDao>(new ReceiptsDao(database, _containerName));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
