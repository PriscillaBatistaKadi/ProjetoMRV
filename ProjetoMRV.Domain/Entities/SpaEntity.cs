using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMRV.Domain.Entities
{
    //[Table("SPA")]
    public class SpaEntity
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
