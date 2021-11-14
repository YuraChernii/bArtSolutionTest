using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bArtSolutionTest.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        /// <summary>
        /// Add new Contact
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddNewContact([FromBody] Contact newContact) 
        {
            var addedContact = await contactService.AddNewContactAsync(newContact);

            return addedContact == null ? StatusCode(409, $"Contact already exists.") : Ok(addedContact);
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            var updatedContact = await contactService.UpdateContactAsync(contact);

            return updatedContact == null ? StatusCode(409, $"Contact already exists.") : Ok(updatedContact);
        }

    }
}
