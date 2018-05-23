using Microsoft.EntityFrameworkCore;

namespace UserDashboard.Models
{
    public class UDContext : DbContext
    {
        public UDContext(DbContextOptions<UDContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        
    }
}