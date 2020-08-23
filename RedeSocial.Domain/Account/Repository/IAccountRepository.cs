using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedeSocial.Domain.Account.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByEmailPassword(string email, string password);

        Task<Domain.Account.Account> GetAccountByUserNamePassword(string userName, string password);

        public Task<IdentityResult> CreateAsync(Domain.Account.Account user, CancellationToken cancellationToken);

        public void save(Domain.Account.Account user);

        public Task<IdentityResult> UpdateAsync(Domain.Account.Account user, CancellationToken cancellationToken);

        public Task<Domain.Account.Account> FindByIdAsync(string userId, CancellationToken cancellationToken);

        public Task<string> GetUserIdAsync(Domain.Account.Account user, CancellationToken cancellationToken);
    }
}
