using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.Models;
using TaskManager.Client.Core.Providers;
using TaskManager.Client.GraphQL.Lib.Factory;
using TaskManager.Client.Providers.Tasks;

namespace TaskManager.Client.Providers.Users
{
    public class UserProvider : GatewayProvider, IUserProvider
    {
        protected override string UrlPrefix => "User";

        public UserProvider(IGraphQLClientFactory clientFactory) : base(clientFactory) { }
        public async Task<IList<UserModel>> ListUserAsync()
        {
            var data = await Client.ExecuteQueryAsync<UsersListResponse>(UserQueries.UsersListQuery, null);
            return data.Users;
        }
    }
}
