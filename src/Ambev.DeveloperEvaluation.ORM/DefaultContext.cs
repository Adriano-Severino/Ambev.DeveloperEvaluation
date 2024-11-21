using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the application.
    /// </summary>
    public class DefaultContext : DbContext
    {
        /// <summary>
        /// Gets or sets the Users DbSet.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the Sales DbSet.
        /// </summary>
        public DbSet<Sale> Sales { get; set; }

        /// <summary>
        /// Gets or sets the SaleItems DbSet.
        /// </summary>
        public DbSet<SaleItem> SaleItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the DefaultContext class with specified options.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configures the model that was discovered by convention from the entity types
        /// exposed in DbSet properties on the derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Factory for creating instances of DefaultContext at design time.
    /// </summary>
    public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        /// <summary>
        /// Creates a new instance of DefaultContext with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments for creating the context.</param>
        /// <returns>A new instance of DefaultContext.</returns>
        public DefaultContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DefaultContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(
                   connectionString,
                   b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
            );

            return new DefaultContext(builder.Options);
        }
    }
}
