using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class WebDbContext : DbContext
    {
        public WebDbContext()
            : base("name=WebDbContext")
        {
        }

        public virtual DbSet<LoginUser> LoginUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<LoginUser>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);
        }
    }
}
