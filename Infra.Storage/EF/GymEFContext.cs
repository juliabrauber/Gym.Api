using Entities.Data;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Storage.EF
{
    public partial class GymEFContext : DbContext, IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public GymEFContext(DbContextOptions<GymEFContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymEFContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";

            optionsBuilder.UseSqlServer(connectionString);
        }
        public bool HasUnsavedChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                                      || e.State == EntityState.Modified
                                                      || e.State == EntityState.Deleted);
        }
        public async Task<bool> Commit()
        {       
           return await base.SaveChangesAsync() > 1;
        }
    }
}
