using ECommerce.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.CompilerServices;

namespace ECommerce.Discount.Context
{
    public class DapperContext: DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= SEYMA\\SQLEXPRESS; initial Catalog= ECommerceDiscount.Db; Integrated Security= true; TrustServerCertificate=true;");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection()=> new SqlConnection(_connectionString); 

    }
}
