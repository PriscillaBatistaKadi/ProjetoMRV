using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMRV.Domain.CommandResult
{
    public class SpaResult
    {
        public int Id { get; set; }
        public string ContactFirstName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public string ContactFullName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }

        public int Status { get; set; }
    }
}
