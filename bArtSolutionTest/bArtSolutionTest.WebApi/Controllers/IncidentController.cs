using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Domain.Dto;
using bArtSolutionTest.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bArtSolutionTest.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            this.incidentService = incidentService;
        }

        /// <summary>
        /// Add new Incident
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddNewIncident([FromBody] AddNewIncidentDto addNewIncidentDto)
        { 
            var addedIncident = await incidentService.AddNewIncidentAsync(addNewIncidentDto);

            return addedIncident == null ? NotFound() : Ok(addedIncident);
        }

    }
}
