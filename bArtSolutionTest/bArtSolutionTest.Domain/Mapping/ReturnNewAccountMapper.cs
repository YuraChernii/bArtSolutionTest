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
    public class ReturnNewAccountMapper: Profile
    {
        public ReturnNewAccountMapper()
        {
            CreateMap<Account, ReturnNewAccountDto>()
                .ForMember(c => c.Id, a => a.MapFrom(b => b.Id))
                .ForMember(c => c.Name, a => a.MapFrom(b => b.Name));
        }
    }
}
