using Microsoft.EntityFrameworkCore;


namespace amethyst.Data.DataBase
{
    public class DBContent : DbContext
    {
        public DbSet<sources> sources => Set<sources>();
        public DbSet<phones> phones => Set<phones>();
        public DbSet<emails> emails => Set<emails>();
        public DbSet<webs> webs => Set<webs>();
        public DbSet<employee> employee => Set<employee>();
        public DbSet<customer> customer => Set<customer>();
        public DbSet<users> users => Set<users>();
        public DbSet<admission> preferences => Set<admission>();
        public DbSet<appeals> appeals => Set<appeals>();
        public DbSet<appeal_statuses> appeal_statuses => Set<appeal_statuses>();

        public DBContent() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=erp_system;Username=postgres;Password=5924");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<users>().HasKey(users => new { users.person_id });

            //builder.Entity<appeals>().HasKey(appeals => new { appeals.id, appeals.customer_id });
        }
    }
}
