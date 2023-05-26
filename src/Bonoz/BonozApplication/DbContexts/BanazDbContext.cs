namespace BonozApplication.DbContexts
{
    public class BanazDbContext : DbContext
    {
        public BanazDbContext(DbContextOptions<BanazDbContext> options) : base(options) { }

        #region All Entities

        #region User

        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }
        public virtual DbSet<AppUserModule> AppUserModules { get; set; }
        //public virtual DbSet<Widget> Widgets { get; set; }
        public virtual DbSet<AppUserActivity> Activities { get; set; }
        public virtual DbSet<UserRestriction> UserRestrictions { get; set; }

        #endregion User

       // public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }

        #region Sales
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<ProductCategory> Categories { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        #endregion Sales

        #endregion All Entities

        #region ModelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserRole>()
            .HasKey(bc => new { bc.AppUserId, bc.AppRoleId });

            modelBuilder.Entity<AppUserRole>()
               .HasOne(bc => bc.AppUser)
               .WithMany(b => b.AppUserRoles)
               .HasForeignKey(bc => bc.AppUserId);

            modelBuilder.Entity<AppUserRole>()
               .HasOne(bc => bc.AppRole)
               .WithMany(b => b.AppUserRoles)
               .HasForeignKey(bc => bc.AppRoleId);

            base.OnModelCreating(modelBuilder);
        }

        #endregion ModelBuilder
    }
}
