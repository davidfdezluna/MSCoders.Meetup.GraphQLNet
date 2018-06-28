using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Meetup.GraphQLNet.DataAccess;
using Meetup.GraphQLNet.App.Types;
using Meetup.GraphQLNet.Domain;
using System.Collections.Generic;

namespace Meetup.GraphQLNet.App
{
    public class SeriesQuery : ObjectGraphType
    {
        public SeriesQuery(SeriesContext seriesDB)
        {
            Name = "Query";

            Field<StringGraphType>("Ping", resolve: context => "Ping ok");

            Field<ListGraphType<SeriesGraphType>>("allseries", resolve: context =>
            {
                return seriesDB.Series.Include(sa => sa.SerieActors).ThenInclude(sa => sa.Actor).ToList();
            });

            Field<ListGraphType<ActorsGraphType>>("allactors", resolve: context =>
            {
                return seriesDB.Actors.Include(sa => sa.SerieActors).ThenInclude(sa => sa.Serie).ToList();
            });

            Field<ListGraphType<SerieActorGraphType>>("allserieactor", resolve: context =>
            {
                return seriesDB.SerieActor.ToList();
            });

            Field<ListGraphType<SeriesGraphType>>("series",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name="id", Description ="Id de la serie" },
                    new QueryArgument<StringGraphType> {Name="name" }),
               resolve: context =>
               {
                   int? id = context.GetArgument<int?>("id");
                   string name = context.GetArgument<string>("name");

                   var result = seriesDB.Series.Include(s => s.SerieActors).ThenInclude(s => s.Actor)
                        .Where(s => ((!id.HasValue || s.Id == id) && (string.IsNullOrWhiteSpace(name) || s.Name.Contains(name))));

                   return result;
               });
                 
        }
    }
}
