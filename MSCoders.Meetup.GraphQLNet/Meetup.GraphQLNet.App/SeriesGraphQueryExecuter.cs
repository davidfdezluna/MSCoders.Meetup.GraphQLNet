using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.GraphQLNet.App
{
    public class SeriesGraphQueryExecuter
    {
        private IDocumentExecuter executer { get; set; }
        private ISchema schema { get; set; }

        public SeriesGraphQueryExecuter(IDocumentExecuter documentExecuter, ISchema schemaQ)
        {
            executer = documentExecuter;
            schema = schemaQ;
        }

        public async Task<ExecutionResult> ExecuteQuery(GraphQLQuery query)
        {
            var executionOptions = new ExecutionOptions {
                Schema = schema,
                Query = query.Query,
                Inputs = query.Variables != null ? JObject.FromObject(query.Variables).ToString().ToInputs(): null
        };
            var result = await executer.ExecuteAsync(executionOptions).ConfigureAwait(false);
            return result;
        }
    }
}
