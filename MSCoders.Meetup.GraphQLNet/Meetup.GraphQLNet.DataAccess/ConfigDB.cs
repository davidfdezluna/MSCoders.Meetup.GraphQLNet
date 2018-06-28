using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Meetup.GraphQLNet.Domain;

namespace Meetup.GraphQLNet.DataAccess
{
    public class ConfigDB
    {
        private const string ConnectionString
            = @"Server=(localdb)\mssqllocaldb;Database=GraphQLNet.DemoDB;Integrated Security=True;ConnectRetryCount=0";

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<SeriesContext>(
                c => c.UseSqlServer(ConnectionString)
                .UseLoggerFactory(new LoggerFactory()
                .AddConsole((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"))
                .AddDebug((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"))));

            var serviceProvider = services.BuildServiceProvider();

            var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<SeriesContext>();

            if (context.Database.EnsureCreated())
            {
                Console.WriteLine("DB Creada");
                FillDatabase(context);
            }
           
            services.AddSingleton(context);
        }

        private static void FillDatabase(SeriesContext context)
        {
            try
            {
                context.Series.AddRange(GetJson<Serie>(@"Data\series.json"));

                UpdateIdentityContext(context, "Series");

                context.Actors.AddRange(GetJson<Actor>(@"Data\actors.json"));

                UpdateIdentityContext(context, "Actors");

                context.SerieActor.AddRange(GetJson<SerieActor>(@"Data\seriesActors.json"));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                throw ex;
            }
        }

        private static void UpdateIdentityContext(SeriesContext context, string name)
        {
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand(string.Format("SET IDENTITY_INSERT dbo.{0} ON", name));
                context.SaveChanges();
                context.Database.ExecuteSqlCommand(string.Format("SET IDENTITY_INSERT dbo.{0} OFF", name));
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private static List<T> GetJson<T>(string fileJson)
        {
            List<T> entities = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(fileJson));
            return entities;
        }
    }
}
