using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Domain.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ReturnNewAccountDto> AddNewAccountAsync(AddNewAccountDto addNewAccountDto);

        Task<Account> UpdateAccountAsync(Account newAccount);

        Task<Account> CheckIfExistByNameAsync(string name);

        Task<Account> LinkNewContactAsync(string name, Contact newContact);
    }
}
