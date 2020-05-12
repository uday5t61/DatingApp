using DatingApp.API.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> Options ) : base(Options) {}
        
        public DbSet<Value> Values { get; set; }
    }
}