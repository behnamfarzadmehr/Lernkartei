using Lernkartei.Domain.Entities;
using Lernkartei.InfraStructure.Mappings.Card;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Swish.InfraStructure.context
{
    public partial class LernkarteiContext : IdentityDbContext
    {
        public DbSet<Card> Card { get; set; }
        public DbSet<CardHouse> CardHouse { get; set; }
        
        public LernkarteiContext(DbContextOptions<LernkarteiContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetMappings(modelBuilder);
        }
        private void SetMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardMapping());
            modelBuilder.ApplyConfiguration(new CardHousMapping());
        }
    }
}
