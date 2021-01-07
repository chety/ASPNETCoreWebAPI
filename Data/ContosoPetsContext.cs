using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Data
{
    public class ContosoPetsContext : DbContext
    {
        public ContosoPetsContext(DbContextOptions<ContosoPetsContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; init; }
    }
}