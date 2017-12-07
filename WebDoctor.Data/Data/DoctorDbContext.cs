using System.Data.Entity;

namespace WebDoctor.Data
{
    public class DoctorDbContext : DbContext, IDoctorDbContext
    {

        public DoctorDbContext() : base("name = DoctorDbContext")
        {

        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Rule> Rule{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
