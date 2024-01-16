using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace SYSTEMCMTD_WEB_API_SERVER_SIDE.Models
{
    public class Customer
    {

        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Creted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HP { get; set; } = string.Empty;
        public ICollection<Contact> Contacts { get; } = new List<Contact>();
        public ICollection<Address> Address { get; } = new List<Address>();

    }
}
