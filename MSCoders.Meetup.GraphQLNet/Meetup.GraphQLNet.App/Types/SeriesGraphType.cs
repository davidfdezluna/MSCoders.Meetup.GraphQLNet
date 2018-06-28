using GraphQL.Types;
using Meetup.GraphQLNet.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Meetup.GraphQLNet.App.Types
{
    public class SeriesGraphType : ObjectGraphType<Serie>
    {
        public SeriesGraphType()
        {
            Name = "Series";
            Description = "Entidad series";

            Field(x => x.Id).Description("Id de la Serie");
            Field(x => x.Name).Description("Nombre de la Serie");
            Field(x => x.ImageUrl);
            Field(x => x.FirstAired, nullable: true);
            Field(x => x.Overview);
            Field(x => x.TheTVDBId);

            Field<ListGraphType<ActorsGraphType>>("actors", resolve: context =>
            {
                return context.Source.SerieActors.OrderBy(sa => sa.SortOrder).Select(sa => sa.Actor);
            });

        }
    }
}
