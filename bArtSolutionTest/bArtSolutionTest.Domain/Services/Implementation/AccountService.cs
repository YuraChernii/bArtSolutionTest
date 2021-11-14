using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Data.Infrastructure;
using bArtSolutionTest.Domain.Dto;
using bArtSolutionTest.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountEntity = bArtSolutionTest.Data.Entities.Account;

namespace bArtSolutionTest.Domain.Services.Implementation
{
    public class AccountService: IAccountService
    {
        private readonly IRepository<AccountEntity> accountRepository;
        private readonly IContactService contactService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public AccountService(
            IRepository<AccountEntity> accountRepository,
            IContactService contactService,
            IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.contactService = contactService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Сreates a new account and links the contact, even if it has been linked.
        /// </summary>
        public async Task<ReturnNewAccountDto> AddNewAccountAsync(AddNewAccountDto addNewAccountDto)
        {
            var newAccount = mapper.Map<AccountEntity>(addNewAccountDto);
            var newContact = mapper.Map<Contact>(addNewAccountDto);

            var account = await accountRepository.Query().Where(x => x.Name == newAccount.Name).FirstOrDefaultAsync();
            if (account != null)
            {
                return null;
            }

            var contact = await contactService.CheckIfExistByEmailAsync(newContact.Email);

            if (contact == null)
            {
                contact = await contactService.AddNewContactAsync(newContact);
            }
            else
            {
                contact = await contactService.UpdateContactAsync(newContact);
            }

            newAccount.Contacts = new List<Contact> { contact };

            var addedAccount = await accountRepository.AddAsync(newAccount);
            await accountRepository.SaveChangesAsync();

            var returnNewAccountDto = mapper.Map<ReturnNewAccountDto>(addedAccount);
            return returnNewAccountDto;
        }

        public async Task<AccountEntity> UpdateAccountAsync(Account newAccount)
        {
            var addedAccount = await accountRepository.AddAsync(newAccount);

            await accountRepository.SaveChangesAsync();

            return addedAccount;
        }

        /// <summary>
        /// Links the contact if it is not linked to the account.
        /// </summary>
        public async Task<AccountEntity> LinkNewContactAsync(string name, Contact newContact)
        {
            var account = await accountRepository.Query().Where(x => x.Name == name).FirstOrDefaultAsync();
            if(account == null)
            {
                return null;
            }

            var contact = await contactService.CheckIfExistByEmailAsync(newContact.Email);

            if (contact == null)
            {
                contact = await contactService.AddNewContactAsync(newContact);
            }
            else
            {
                contact = await contactService.UpdateContactAsync(newContact);
            }

            if (contact.AccountId != null)
            {
                return null;
            }

            account.Contacts.Add(contact);
            
            await accountRepository.SaveChangesAsync();

            return account;
        }

        public async Task<AccountEntity> CheckIfExistByNameAsync(string name) => 
            await accountRepository.Query().Where(x => x.Name == name).FirstOrDefaultAsync();
        
    }
}
