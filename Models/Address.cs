using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SYSTEMCMTD_WEB_API_SERVER_SIDE.Models
{
    public class Address
    {

        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime Creted { get; set; } = DateTime.Now;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public Customer?Customer { get; set; }
    }
}
