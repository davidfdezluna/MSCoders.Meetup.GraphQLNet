using GraphQL.Types;
using Meetup.GraphQLNet.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Meetup.GraphQLNet.App.Types
{
    public class SerieActorGraphType : ObjectGraphType<SerieActor>
    {
        public SerieActorGraphType()
        {
            Name = "SerieActor";
            Description = "Entidad SerieActor";

            Field(x => x.SerieId);
            Field(x => x.ActorId);
            Field(x => x.SortOrder);
        }
    }
}
