using GraphQL.Types;
using Meetup.GraphQLNet.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Meetup.GraphQLNet.App.Types
{
    public class ActorsGraphType : ObjectGraphType<Actor>
    {
        public ActorsGraphType()
        {
            Name = "Actores";
            Description = "Entidad que representa los actores de una serie";

            Field(x => x.Id).Description("Id del Actor");
            Field(x => x.Name).Description("Nombre del Actor");
            Field(x => x.ImageUrl);
            Field(x => x.TheTVDBId);

            Field<ListGraphType<SeriesGraphType>>("series", resolve: context => {
                return context.Source.SerieActors.OrderBy(sa => sa.SortOrder).Select(sa => sa.Serie);
            });

        }
    }
}
