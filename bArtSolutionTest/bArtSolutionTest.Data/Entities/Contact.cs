using bArtSolutionTest.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bArtSolutionTest.Data.Entities
{
    public class Contact: IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? AccountId { get; set; }

        public Account Account { get; set; }
    }
}
