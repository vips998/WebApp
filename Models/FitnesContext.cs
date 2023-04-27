using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using WebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public partial class FitnesContext : IdentityDbContext<User, IdentityRole<int>,int>
    {
        protected readonly IConfiguration Configuration;
        public FitnesContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        #region Constructor
        //public FitnesContext(DbContextOptions<FitnesContext> options) : base(options)
        //{ }
        #endregion

        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}
