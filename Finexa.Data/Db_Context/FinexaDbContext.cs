using Finexa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Db_Context
{
    public class FinexaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<Platform> Platforms { get; set; } = null!;
        public DbSet<Card> Cards { get; set; } = null!;

        public DbSet<Wallet> Wallets { get; set; } = null!;
        public DbSet<FiatWallet> FiatWallets { get; set; } = null!;
        public DbSet<DigitalWallet> DigitalWallets { get; set; } = null!;

        public DbSet<Transaction> Transactions { get; set; } = null!;

        public DbSet<Year> Years { get; set; } = null!;
        public DbSet<Month> Months { get; set; } = null!;
        public DbSet<Week> Weeks { get; set; } = null!;
        public DbSet<Day> Days { get; set; } = null!;

        public FinexaDbContext(DbContextOptions<FinexaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Wallet inheritance mapping (TPH)
            modelBuilder.Entity<Wallet>()
                .HasDiscriminator<string>("WalletType")
                .HasValue<FiatWallet>("Fiat")
                .HasValue<DigitalWallet>("Digital");

            // Currency ↔ Wallet
            modelBuilder.Entity<FiatWallet>()
                .HasOne(w => w.Currency)
                .WithMany(c => c.FiatWallets)
                .HasForeignKey(w => w.CurrencyId);

            modelBuilder.Entity<DigitalWallet>()
                .HasOne(w => w.Currency)
                .WithMany(c => c.DigitalWallets)
                .HasForeignKey(w => w.CurrencyId);

            // Wallet ↔ Platform
            modelBuilder.Entity<DigitalWallet>()
                .HasOne(w => w.Platform)
                .WithMany(p => p.DigitalWallets)
                .HasForeignKey(w => w.PlatformId);

            // DigitalWallet ↔ Card
            modelBuilder.Entity<DigitalWallet>()
                .HasOne(w => w.Card)
                .WithMany()
                .HasForeignKey(w => w.CardId)
                .OnDelete(DeleteBehavior.SetNull);

            // Platform ↔ Supported Currencies (many-to-many)
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.SupportedCurrencies)
                .WithMany(c => c.SupportedPlatforms)
                .UsingEntity(j => j.ToTable("PlatformSupportedCurrencies"));

            // Platform ↔ Card
            modelBuilder.Entity<Card>()
                .HasOne(c => c.Platform)
                .WithMany(p => p.Cards)
                .HasForeignKey(c => c.PlatformId);

            // User ↔ Card
            modelBuilder.Entity<Card>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cards)
                .HasForeignKey(c => c.UserId);

            // User ↔ Wallet
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithMany(u => u.FiatWallets)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DigitalWallet>()
                .HasOne(w => w.User)
                .WithMany(u => u.DigitalWallets)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction mapping
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Wallet)
                .WithMany()
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.TargetWallet)
                .WithMany()
                .HasForeignKey(t => t.TargetWalletId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Day)
                .WithMany(d => d.Transactions)
                .HasForeignKey(t => t.DayId);

            // Calendar entities
            modelBuilder.Entity<Year>()
                .HasMany(y => y.Months)
                .WithOne(m => m.Year)
                .HasForeignKey(m => m.YearId);

            modelBuilder.Entity<Month>()
                .HasMany(m => m.Days)
                .WithOne(d => d.Month)
                .HasForeignKey(d => d.MonthId);

            modelBuilder.Entity<Month>()
                .HasMany(m => m.Weeks)
                .WithOne(w => w.Month)
                .HasForeignKey(w => w.MonthId);

            modelBuilder.Entity<Week>()
                .HasMany(w => w.Days)
                .WithOne(d => d.Week)
                .HasForeignKey(d => d.WeekId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
