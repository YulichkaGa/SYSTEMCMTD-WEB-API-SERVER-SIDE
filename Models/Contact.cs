using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SYSTEMCMTD_WEB_API_SERVER_SIDE.Models
{
    public class Contact
    {

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Creted { get; set; } = DateTime.Now;
        public string FullName { get; set; } = string.Empty;
        public string OfficeNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Guid CustomerId { get; set; }

        public Customer? Customer { get; set; }
    }
}
