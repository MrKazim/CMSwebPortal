using CMSwebPortal.DataLayer.Data;
using CMSwebPortal.Models.DbModels;
using CMSwebPortal.Models.DbModels.Files;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {        
        }
        //initialize the file table
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<TokenInfo> TokenInfo { get; set; }
        public DbSet<App> App { get; set; }
        public DbSet<Activity> Activity1 { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Official> Official { get; set; }
        public DbSet<SecurityCommittee> SecurityCommittee { get; set; }
        public DbSet<Work> Work { get; set; }
        public DbSet<ContactPerson> ContactPerson { get; set; }
       
    }
}
