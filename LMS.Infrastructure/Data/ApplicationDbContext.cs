using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.ViewModels;
using LMS.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<GetBookViewModel> GetBookViewModels { get; set; }
        public DbSet<Authorship> Authorships { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItems> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorshipConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GetBookViewModelConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LibrarianConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseItemsConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
