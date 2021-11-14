using bArtSolutionTest.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bArtSolutionTest.Data.Entities
{
    public class Incident : IEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
