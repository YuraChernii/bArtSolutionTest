using AutoMapper;
using Microsoft.AspNetCore.Http;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Data.Infrastructure;
using bArtSolutionTest.Domain.Dto;
using bArtSolutionTest.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentEntity = bArtSolutionTest.Data.Entities.Incident;

namespace bArtSolutionTest.Domain.Services.Implementation
{
    public class IncidentService: IIncidentService
    {
        
        private readonly IRepository<IncidentEntity> incidentRepository;
        private readonly IAccountService accountService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public IncidentService(
            IRepository<IncidentEntity> incidentRepository, 
            IAccountService accountService, 
            IMapper mapper)
        {
            this.incidentRepository = incidentRepository;
            this.accountService = accountService;
            this.mapper = mapper;
        }



        public async Task<IncidentEntity> AddNewIncidentAsync(AddNewIncidentDto addNewIncidentDto)
        {
            var newIncident = mapper.Map<AddNewIncidentDto, Incident>(addNewIncidentDto);
            var newAccount = mapper.Map<AddNewIncidentDto, Account>(addNewIncidentDto);
            var newContact = mapper.Map<AddNewIncidentDto, Contact>(addNewIncidentDto);

            var account = await accountService.CheckIfExistByNameAsync(newAccount.Name);
            if (account == null)
            {
                return null;
            }

            await accountService.LinkNewContactAsync(account.Name, newContact);

            newIncident.Accounts = new List<Account> { account };

            var addedIncident = await incidentRepository.AddAsync(newIncident);

            await incidentRepository.SaveChangesAsync();

            return addedIncident;
        }

       
    }
}
