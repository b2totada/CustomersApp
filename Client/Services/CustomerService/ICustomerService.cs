namespace CustomersApp.Client.Services.CustomerService
{
	public interface ICustomerService
	{
		List<Customer> Customers { get; set; }
		List<CustomerCategory> Categories { get; set; }
		Task GetCategories();
		Task GetCustomers();
		Task<Customer> GetSingleCustomer(string id);
		Task CreateCustomer(Customer customer);
		Task UpdateCustomer(Customer customer);
		Task DeleteCustomer(string id);
	}
}
