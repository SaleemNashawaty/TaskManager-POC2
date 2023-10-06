using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Client.Core.Models;
using TaskManager.Client.Core.Providers;
using TaskManager.Client.Core.Queries;

namespace TaskManager.Client.Business.Handlers
{
    public class ListUserQueryHandler : IRequestHandler<ListUserQuery, IList<UserModel>>
    {
        private readonly IUserProvider _userProvider;
        public ListUserQueryHandler(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public async Task<IList<UserModel>> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            return await _userProvider.ListUserAsync();
        }
    }
}
