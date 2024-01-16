using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using SYSTEMCMTD_WEB_API_SERVER_SIDE.Data;
using SYSTEMCMTD_WEB_API_SERVER_SIDE.Models;

namespace SYSTEMCMTD_WEB_API_SERVER_SIDE.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly FullStackDBContext _fullStackDBContext;

        public CustomersController(FullStackDBContext fullStackDbContext)
        {
            _fullStackDBContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GettAllCustomers()
        {
           
             var  customers = await _fullStackDBContext.CustomersDb.Where(x => x.IsDeleted == false).ToArrayAsync();
         
            return Ok(customers);
        }

        [Route("{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customerRequest)
        {
            var newName = customerRequest.Name;
            try
            {
                if (_fullStackDBContext.CustomersDb.Any(u => u.Name == customerRequest.Name))
                {
                    return BadRequest("Name is exist");
                }
                else
                {
                    customerRequest.Id = Guid.NewGuid();

                    customerRequest.IsDeleted = false;
                    customerRequest.Creted = DateTime.Now;
                    await _fullStackDBContext.CustomersDb.AddAsync(customerRequest);
                    await _fullStackDBContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Ok(customerRequest);

        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await _fullStackDBContext.CustomersDb.FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                if (customer == null)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok(customer);



        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, Customer updateCustomer)
        {
            var customer = await _fullStackDBContext.CustomersDb.FindAsync(id);
            try
            {
                if (customer == null)
                {
                    return NotFound();
                }
                customer.Name = updateCustomer.Name;
                customer.HP = updateCustomer.HP;
                await _fullStackDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok(customer);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var customer = await _fullStackDBContext.CustomersDb.FindAsync(id);
            try
            {
               
                if (customer == null)
                {
                    return NotFound();
                }
                customer.IsDeleted = true;
                _fullStackDBContext.Update(customer);
                await _fullStackDBContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        
            return Ok(customer);
        }
    }
}
