
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Categery> Categeries { get; set; }
    }
}
