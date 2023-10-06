using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Client.GraphQL.Lib.Extension
{
    public class GraphQLGatewaySettings
    {
        /// <summary>
        /// GraphQL Gateway endpoint Url address
        /// </summary>
        public string EndpointUrl { get; set; }

        /// <summary>
        /// To specify the timeout, in seconds, for the graphQl queries and mutations
        /// </summary>
        public string Timeout { get; set; }
    }
}
