using CustomersApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
		private readonly DataContext _context;
		public CustomerController(DataContext context)
        {
			_context = context;
		}

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers
                .Include(c => c.Category)
                .ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetSingleCustomer(string id)
        {
            var customer = await _context.Customers
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            return customer == null ? NotFound("Customer not found") : Ok(customer);
        }

		[HttpGet("categories")]
		public async Task<ActionResult<List<CustomerCategory>>> GetCategories()
		{
			var categories = await _context.Categories.ToListAsync();
			return Ok(categories);
		}

		[HttpPost]
		public async Task<ActionResult<List<Customer>>> CreateCustomer(Customer customer)
		{
            customer.Category = null;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

			return Ok(await GetDbCustomers());
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer customer, string id)
		{
            var dbCustomer = await _context.Customers
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbCustomer == null)
            {
                return NotFound("Customer not found");
            }

            dbCustomer.Id = customer.Id;
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Tel = customer.Tel;
            dbCustomer.Address = customer.Address;
            dbCustomer.CategoryId = customer.CategoryId;

            await _context.SaveChangesAsync();

			return Ok(await GetDbCustomers());
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Customer>>> DeleteCustomer(string id)
		{
			var dbCustomer = await _context.Customers
				.Include(c => c.Category)
				.FirstOrDefaultAsync(c => c.Id == id);
			if (dbCustomer == null)
			{
				return NotFound("Customer not found");
			}

			_context.Customers.Remove(dbCustomer);
			await _context.SaveChangesAsync();

			return Ok(await GetDbCustomers());
		}

		private async Task<List<Customer>> GetDbCustomers()
        {
            return await _context.Customers.Include(c => c.Category).ToListAsync();
        }
	}
}
