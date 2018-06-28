using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.GraphQLNet.App
{   
    public class GraphQLQuery
    {
        public GraphQLQuery()
        {
            Variables = new Dictionary<string, object>();
        }

        public string OperationName { get; set; }

        public string NamedQuery { get; set; }

        public string Query { get; set; }

        public Dictionary<string, object> Variables { get; set; }
    }

}
