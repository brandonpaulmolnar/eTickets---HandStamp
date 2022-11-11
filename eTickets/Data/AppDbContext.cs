using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant_Event>().HasKey(am => new
            {
                am.ParticipantId,
                am.EventId
            });

            modelBuilder.Entity<Participant_Event>().HasOne(m => m.Event).WithMany(am => am.Participants_Events).HasForeignKey(m => m.EventId);
            modelBuilder.Entity<Participant_Event>().HasOne(m => m.Participant).WithMany(am => am.Participants_Events).HasForeignKey(m => m.ParticipantId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant_Event> Participants_Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
