namespace Comp2084_Assignment2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AzureDatabase : DbContext
    {
        public AzureDatabase()
            : base("name=AzureDatabase")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AuctionItem> AuctionItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AuctionItems)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<AuctionItem>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<AuctionItem>()
                .Property(e => e.price_expected)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AuctionItem>()
                .Property(e => e.price_sold)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AuctionItem>()
                .Property(e => e.profit)
                .HasPrecision(9, 2);

            modelBuilder.Entity<AuctionItem>()
                .Property(e => e.pic)
                .IsUnicode(false);
        }
    }
}
