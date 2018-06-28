using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Meetup.GraphQLNet.App;
using Meetup.GraphQLNet.App.Types;
using Meetup.GraphQLNet.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Meetup.GraphQLNet.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();

            //BD
            ConfigDB.ConfigureServices(services);

            //Dependence GraphQL
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            //Dependence Domain
            services.AddTransient<SeriesQuery>();
            services.AddTransient<SeriesGraphType>();
            services.AddTransient<ActorsGraphType>();
            services.AddTransient<SerieActorGraphType>();

            //Dependence Schema
            services.AddSingleton<ISchema>(s => new SeriesSchema(new FuncDependencyResolver(type => (GraphType)s.GetService(type))));
            services.AddTransient<SeriesGraphQueryExecuter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}
