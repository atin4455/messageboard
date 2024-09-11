using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace messageboard.Models.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<GuestBook> GuestBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GuestBook>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<GuestBook>()
                .Property(e => e.Cellphone)
                .IsUnicode(false);


        }
    }
}
