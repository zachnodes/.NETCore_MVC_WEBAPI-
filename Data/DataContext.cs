/** 
 * File date: 11/12/2024
 * Purpose: This code defines an DataContext class which acts as a bride between your application and the SQL server db.
 * DataContext is used to manage the connection to the database, represent database tables as C# objects, and configure relationships
 * between these objects.
 * **/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PokemonWebApi.Models;

namespace PokemonWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        // DbSet<TEntity> Creates table in sql server database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>().HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemonCategory>().HasOne(p => p.Pokemon).WithMany(pc => pc.PokemonCategories).HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<PokemonCategory>().HasOne(p => p.Category).WithMany(pc => pc.PokemonCategories).HasForeignKey(c => c.CategoryId);



            modelBuilder.Entity<PokemonOwner>().HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>().HasOne(p => p.Pokemon).WithMany(pc => pc.PokemonOwners).HasForeignKey(c => c.OwnerId);
            modelBuilder.Entity<PokemonOwner>().HasOne(p => p.Owner).WithMany(pc => pc.PokemonOwners).HasForeignKey(c => c.PokemonId);
        }
    }
}
