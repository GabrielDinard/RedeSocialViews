using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RedeSocial.Services.Account
{
    public interface IAccountService
    {
        public void save(Domain.Account.Account user, CancellationToken cancellationToken);

        public void edit(Domain.Account.Account user, CancellationToken cancellationToken);

        public void detailsFindId(string userId, CancellationToken cancellationToken);

        public void detailsGetId(Domain.Account.Account user, CancellationToken cancellationToken);
    }
}
