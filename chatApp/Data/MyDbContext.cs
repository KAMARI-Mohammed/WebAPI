using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace chatApp.Data
{
    public class MyDbContext : DbContext
    {
        public string connectionString {get;}
         public MyDbContext()
        {   
            connectionString = "Data Source=DESKTOP-02TFH0J\\SQLEXPRESS;Initial Catalog=nbbk;Integrated Security=True;TrustServerCertificate=true;";
        }
                // public MyDbContext(DbContextOptions<MyDbContext> options)
                //     : base(options)
                // {
                // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ 
            optionsBuilder.UseSqlServer(connectionString);
        }



        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.Entity<Messages>()
            .HasOne<AppUser>(a=> a.Sender)
            .WithMany(d=> d.Message)
            .HasForeignKey(d=>d.UserId);
        }

        public DbSet<Messages> Message {get;set;}
    }
}