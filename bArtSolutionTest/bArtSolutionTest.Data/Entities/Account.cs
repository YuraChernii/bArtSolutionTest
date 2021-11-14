using bArtSolutionTest.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bArtSolutionTest.Data.Entities
{
    public class Account: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? IncidentId { get; set; }

        public Incident Incident { get; set; }
        [JsonIgnore]
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
