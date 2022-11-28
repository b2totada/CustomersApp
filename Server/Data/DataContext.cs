namespace CustomersApp.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomerCategory>().HasData(
				new CustomerCategory { Id = 1, Name = "Lakossagi" },
				new CustomerCategory { Id = 2, Name = "Ceges" }
			);
			modelBuilder.Entity<Customer>().HasData(
				new Customer
				{
					Id = "1",
					FirstName = "Elso",
					LastName = "Ember",
					Tel = "0123456",
					Address = "Budapest",
					CategoryId = 1
				},
				new Customer
				{
					Id = "2",
					FirstName = "Masodik",
					LastName = "Emberke",
					Tel = "987654",
					Address = "Szeged",
					CategoryId = 2
				}
			);
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<CustomerCategory> Categories { get; set; }
	}
}
