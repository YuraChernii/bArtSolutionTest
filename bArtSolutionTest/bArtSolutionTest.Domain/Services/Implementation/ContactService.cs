using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Data.Infrastructure;
using bArtSolutionTest.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactEntity = bArtSolutionTest.Data.Entities.Contact;

namespace bArtSolutionTest.Domain.Services.Implementation
{
    public class ContactService: IContactService
    {
        private readonly IRepository<ContactEntity> contactRepository;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ContactService(
            IRepository<ContactEntity> contactRepository, 
            IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }



        public async Task<ContactEntity> AddNewContactAsync(ContactEntity newContact)
        {
            var contact = await contactRepository.Query().Where(c => c.Email == newContact.Email)
                .FirstOrDefaultAsync();

            if (contact != null)
            {
                return null;
            }

            var addedContact = await contactRepository.AddAsync(newContact);

            await contactRepository.SaveChangesAsync();

            return addedContact;
        }

        public async Task<ContactEntity> UpdateContactAsync(ContactEntity updatedContact)
        {
            var contact = await contactRepository.Query().Where(c => c.Email == updatedContact.Email)
                .FirstOrDefaultAsync();

            if(contact == null)
            {
                return null;
            }

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;

            await contactRepository.SaveChangesAsync();

            return contact;
        }

        public async Task<ContactEntity> CheckIfExistByEmailAsync(string email) =>
            await contactRepository.Query().Where(x => x.Email == email).FirstOrDefaultAsync();

    }
}
