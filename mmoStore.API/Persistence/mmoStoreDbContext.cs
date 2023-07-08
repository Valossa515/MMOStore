using Microsoft.EntityFrameworkCore;
using mmoStore.API.Entities;

namespace mmoStore.API.Persistence
{
    public interface IDbContext
    {
        DbSet<Categoria> Categorias { get; set; }
        int SaveChanges();
    }
    public class MmoStoreDbContext : DbContext, IDbContext
    {
        public MmoStoreDbContext(DbContextOptions<MmoStoreDbContext> options) : base(options) {

        }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(c =>
            {
                c.HasKey(ca => ca.Id);
                c.Property(ce => ce.Nome)
                    .IsRequired(true)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");
            });
        }

        int IDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }
        
    }
}
