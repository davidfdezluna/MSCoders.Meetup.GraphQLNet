using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.GraphQLNet.App
{
    public class SeriesSchema : Schema
    {
        public SeriesSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<SeriesQuery>();            
        }
    }
}
