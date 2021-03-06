using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEndSmartContract.Models
{
    public partial class SmartPropDbContext : DbContext
    {
        public SmartPropDbContext()
        {
        }
        public DbSet<ImagesRealEstate> ImagesRealEstate { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<User> Users{ get; set; }
        

        public SmartPropDbContext(DbContextOptions<SmartPropDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=./SQLEXPRESS;Database=SmartProp;Integrated Security=SSPI;server=(local) ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<User>()
           .HasIndex(p => new { p.Email, p.PersonalID})
           .IsUnique(true);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
