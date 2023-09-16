using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Newtonsoft.Json;

namespace CatBreedService.Infrastructure
{
    public class CatBreedDbContext : DbContext
    {
        public CatBreedDbContext(DbContextOptions<CatBreedDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public CatBreedDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No SQL

            //modelBuilder.Entity<Breed>()
            //    .ToContainer("Breeds");

            //modelBuilder.Entity<Breed>()
            //    .HasKey(f => f.Id);

            //modelBuilder.Entity<Breed>()
            //    .HasPartitionKey(nameof(Breed.Id));

            //modelBuilder.Entity<Breed>().OwnsMany(
            //    p => p.Images, a =>
            //    {
            //        a.WithOwner().HasForeignKey("BreedId");
            //        a.HasKey("Id");
            //    });

            //modelBuilder.Entity<Breed>()
            //    .OwnsOne(f => f.Weight);


            //Relational

            modelBuilder.Entity<Breed>()
                .ToContainer("Breeds")
                .HasPartitionKey(x => x.Id);

            modelBuilder.Entity<Image>()
                .ToContainer("Images")
                .HasPartitionKey(x => x.Id);

            modelBuilder.Entity<Image>()
                .HasNoDiscriminator()
                .Property(f => f.Id)
                .HasConversion<string>()
                .HasValueGenerator<SequentialGuidValueGenerator>();

            modelBuilder.Entity<Breed>()
                .OwnsOne(f => f.Weight);
        }

        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}