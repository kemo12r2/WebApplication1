using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApplication1.Models;

namespace WebApplication1.data
{
    public class Dbconnectian:DbContext
    {
        public Dbconnectian(DbContextOptions<Dbconnectian> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetelis> OrderDetails { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
