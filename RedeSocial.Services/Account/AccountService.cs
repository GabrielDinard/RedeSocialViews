using Microsoft.EntityFrameworkCore.Diagnostics;
using RedeSocial.Domain.Account.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RedeSocial.Services.Account
{
    public class AccountService : IAccountService
    {
        /*private static Dictionary<Type, Type> VeiculoService = new Dictionary<Type, Type>
        {
            [typeof(IVeiculo)] = typeof(VeiculoRepository)
        };*/

        private IAccountRepository AccountRepository { get; set; }

        public AccountService(IAccountRepository accountRepository)
        {
            this.AccountRepository = accountRepository;
        }

        public void save(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            this.AccountRepository.CreateAsync(user, cancellationToken);
        }

        public void edit(Domain.Account.Account user, CancellationToken cancellationToken)
        {
            this.AccountRepository.UpdateAsync(user, cancellationToken);
        }

        public void details(string userId, CancellationToken cancellationToken)
        {
            this.AccountRepository.FindByIdAsync(userId, cancellationToken);
        }
    }
}
