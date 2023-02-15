using LMS.CoreBusiness.Entities;
using LMS.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Bookcase> Bookcases { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Authorship> Authorships { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<PublishingCompany> PublishingCompanies { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorshipConfiguration());
            modelBuilder.ApplyConfiguration(new BookcaseConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new LibrarianConfiguration());
            modelBuilder.ApplyConfiguration(new PublishingCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ReaderConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
        }
    }
}
