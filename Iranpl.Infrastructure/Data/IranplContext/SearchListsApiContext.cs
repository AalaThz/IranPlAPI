using Iranpl.Domain.Models.Message;
using Iranpl.Domain.Models.SearchModels;
using Iranpl.Domain.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Data.IranplContext
{
    public class SearchListsApiContext : DbContext
    {
        public SearchListsApiContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BP_FehrestSearchResults>().HasNoKey();
            modelBuilder.Entity<Bp_ModelForSearch>().HasNoKey();
        }

        public DbSet<BP_FehrestSearchResults> BP_FehrestSearchResults { get; set; }
        public DbSet<Bp_ModelForSearch> BP_ModelForSearch { get; set; }


        // DbSet for Messages
        public DbSet<Message> Messages { get; set; }


        //public DbSet<TestLogin> TestLogins { get; set; }

    }
}
