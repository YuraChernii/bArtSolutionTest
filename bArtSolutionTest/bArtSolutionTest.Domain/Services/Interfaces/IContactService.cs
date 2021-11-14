using bArtSolutionTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Domain.Services.Interfaces
{
    public interface IContactService
    {
        Task<Contact> AddNewContactAsync(Contact newContact);

        Task<Contact> UpdateContactAsync(Contact contact);

        Task<Contact> CheckIfExistByEmailAsync(string email);
    }
}
