using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rsvp.Models.DB
{
    public partial class GuestsContext : DbContext
    {
        public GuestsContext()
        {
        }

        public GuestsContext(DbContextOptions<GuestsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<HotelRequirement> HotelRequirement { get; set; }
        public virtual DbSet<Household> Household { get; set; }
        public virtual DbSet<RsvpStatus> RsvpStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "guestsDb_user");

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("Guest", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DietaryRequirements).IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SongRequest).IsUnicode(false);

                entity.HasOne(d => d.Household)
                    .WithMany(p => p.Guest)
                    .HasForeignKey(d => d.HouseholdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_ToHousehold");

                entity.HasOne(d => d.RsvpStatus)
                    .WithMany(p => p.Guest)
                    .HasForeignKey(d => d.RsvpStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_ToRsvp");
            });

            modelBuilder.Entity<HotelRequirement>(entity =>
            {
                entity.ToTable("HotelRequirement", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Requirement)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Household>(entity =>
            {
                entity.ToTable("Household", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RsvpStatus>(entity =>
            {
                entity.ToTable("RsvpStatus", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
