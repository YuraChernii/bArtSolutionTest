using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Domain.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<Incident> AddNewIncidentAsync(AddNewIncidentDto addNewIncidentDto);
    }
}
