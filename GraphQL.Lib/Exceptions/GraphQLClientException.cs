using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Client.GraphQL.Lib.Exceptions
{
    /// <summary>
    /// custom exception for GraphQL Exceptions
    /// </summary>
    public class GraphQLClientException : Exception
    {
        /// <summary>
        /// Default constructor. Initializes a new instance of the <see cref="GraphQLClientException"/> class
        /// </summary>
        public GraphQLClientException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphQLClientException"/> class with a specified error message
        /// </summary>
        /// <param name="message">Error message</param>
        public GraphQLClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphQLClientException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception that is the cause of this exception</param>
        public GraphQLClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
