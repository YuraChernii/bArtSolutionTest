using AutoMapper;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArtSolutionTest.Domain.Mapping
{
    public class AddNewContactMapper: Profile
    {
        public AddNewContactMapper()
        {
            CreateMap<AddNewContactDto, Contact>()
                .ForMember(c => c.FirstName, a => a.MapFrom(b => b.FirstName))
                .ForMember(c => c.LastName, a => a.MapFrom(b => b.LastName))
                .ForMember(c => c.Email, a => a.MapFrom(b => b.Email));
        }
    }
}
