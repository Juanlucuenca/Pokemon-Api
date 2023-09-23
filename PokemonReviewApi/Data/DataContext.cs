using Microsoft.EntityFrameworkCore;
using PokemonReviewApi.Models;

namespace PokemonReviewApi.Data
{
    public class DataContext : DbContext
    {
         
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Category> Cateogries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PokemonCategory> PokemonsCategories { get; set; }
        public DbSet<PokemonOwner> PokemonsOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new {pc.PokemonId, pc.CateogoryId});
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(c => c.Category)
                .WithMany(pc => pc.PokemonCategory)
                .HasForeignKey(c => c.CateogoryId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(o => o.Owner)
                .WithMany(po => po.PokemonOwner)
                .HasForeignKey(o => o.OwnerId);

        }
    }
}
