using Iranpl.Domain.Models.ApiModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Data.IranPlDbContext
{
    public class GeographicalApiContext : DbContext
    {
        public GeographicalApiContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<State> States { get; set; }
        public DbSet<Township> Townships { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Village> Villages { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
