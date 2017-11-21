using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Klakier
{
    public partial class _1474_SmerfetkaContext : DbContext
    {
        public _1474_SmerfetkaContext(DbContextOptions<_1474_SmerfetkaContext> options)         
        :base(options)
        { }
        
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Portfel> Portfel { get; set; }
        public virtual DbSet <Place> Place { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=mssql01.dcsweb.pl,51433;Database=1474_Smerfetka; UID=1474_Smerfetka;Password=ZPI@2017;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "1474_Smerfetka");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID");
                    

                entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DiscardDate).HasColumnType("datetime");

                entity.Property(e => e.Expenses)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Income)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PortfelId).HasColumnName("PortfelID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Place>(entity => {

                // walidacja place to do
            });

            modelBuilder.Entity<Category>(entity =>
            {
              //  entity.HasIndex(e => e.Id)
                //    .HasName("Category_ID")
                //    .IsUnique();

               // entity.Property(e => e.Id).HasColumnName("ID");

             //   entity.Property(e => e.Description)
               //     .HasMaxLength(255)
               //     .IsUnicode(false);

              //  entity.Property(e => e.Name)
               //     .IsRequired()
                //    .HasMaxLength(255)
                //    .IsUnicode(false);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Currency1);

                entity.Property(e => e.Currency1)
                    .HasColumnName("Currency")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                //entity.HasIndex(e => e.Id)
                //    .HasName("Expense_ID")
                 //   .IsUnique();

               // entity.Property(e => e.Id).HasColumnName("ID");

             //   entity.Property(e => e.AccountId).HasColumnName("AccountID");

              //  entity.Property(e => e.Amount)
                 //   .HasColumnType("decimal(10, 2)")
                 //   .HasDefaultValueSql("((0))");

             //   entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

               // entity.Property(e => e.CurrencyCurrency)
                 //   .IsRequired(false)
                 //   .HasMaxLength(3)
                 //   .IsUnicode(false);

              //  entity.Property(e => e.DaysCycle).HasDefaultValueSql("((0))");

              //  entity.Property(e => e.Place)
                 //   .HasMaxLength(255)
                  //  .IsUnicode(false);

               // entity.Property(e => e.Time).HasColumnType("date");
            });

            modelBuilder.Entity<Income>(entity =>
            {
              //  entity.HasIndex(e => e.Id)
               //     .HasName("Income_ID")
               //     .IsUnique();

              //  entity.Property(e => e.Id).HasColumnName("ID");

             //   entity.Property(e => e.AccountId).HasColumnName("AccountID");

               // entity.Property(e => e.Amount)
                //    .HasColumnType("decimal(10, 2)")
                //     .HasDefaultValueSql("((0))");

             //   entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            //    entity.Property(e => e.CurrencyCurrency)
              //      .IsRequired()
              //      .HasMaxLength(3)
              //      .IsUnicode(false);
//
              //  entity.Property(e => e.DaysCycle).HasDefaultValueSql("((0))");

              //  entity.Property(e => e.Place)
                 //   .HasMaxLength(255)
                 //   .IsUnicode(false);

              //  entity.Property(e => e.Time).HasColumnType("date");
            });

            modelBuilder.Entity<Portfel>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });
        }
    }
}
