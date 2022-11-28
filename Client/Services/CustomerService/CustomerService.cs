using CustomersApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CustomersApp.Client.Services.CustomerService
{
	public class CustomerService : ICustomerService
	{
		public List<Customer> Customers { get; set; } = new List<Customer>();
		public List<CustomerCategory> Categories { get; set; } = new List<CustomerCategory>();

		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManager;
		public CustomerService(HttpClient http, NavigationManager navigationManager)
		{
			_http = http;
			_navigationManager = navigationManager;
		}

		public async Task GetCategories()
		{
			var result = await _http.GetFromJsonAsync<List<CustomerCategory>>("api/customer/categories");
			if (result != null)
			{
				Categories = result;
			}
		}

		public async Task GetCustomers()
		{
			var result = await _http.GetFromJsonAsync<List<Customer>>("api/customer");
			if (result != null)
			{
				Customers = result;
			}
		}

		public async Task<Customer> GetSingleCustomer(string id)
		{
			var result = await _http.GetFromJsonAsync<Customer>($"api/customer/{id}");
			return result ?? throw new Exception("Customer not found");
		}

		public async Task CreateCustomer(Customer customer)
		{
			var result = await _http.PostAsJsonAsync("api/customer", customer);
			await SetCustomers(result);
		}

		private async Task SetCustomers(HttpResponseMessage result)
		{
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception($"{await result.Content.ReadAsStringAsync()}");
			}
			var response = await result.Content.ReadFromJsonAsync<List<Customer>>();
			Customers = response;
			_navigationManager.NavigateTo("customers");
		}

		public async Task UpdateCustomer(Customer customer)
		{
			var result = await _http.PutAsJsonAsync($"api/customer/{customer.Id}", customer);
			await SetCustomers(result);
		}

		public async Task DeleteCustomer(string id)
		{
			var result = await _http.DeleteAsync($"api/customer/{id}");
			await SetCustomers(result);
		}
	}
}
