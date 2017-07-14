using System.Data.Entity;
using LearningMVCWithCF.Models;

namespace LearningMVCWithCF
{
    public class MVCDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

    }
}