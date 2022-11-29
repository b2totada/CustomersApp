global using CustomersApp.Shared;
global using CustomersApp.Client.Services.CustomerService;
using CustomersApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//registration of CustomerService
builder.Services.AddScoped<ICustomerService, CustomerService>();

await builder.Build().RunAsync();
