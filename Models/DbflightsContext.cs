﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Flights.WebApplication;

public partial class DbflightsContext : DbContext
{
    public DbflightsContext()
    {
    }

    public DbflightsContext(DbContextOptions<DbflightsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<CategoriesFlight> CategoriesFlights { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E1L4539\\SQLEXPRESS; Database=DBFlights; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airport>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.Airports)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Airports_Cities");
        });

        modelBuilder.Entity<CategoriesFlight>(entity =>
        {
            entity.ToTable("Categories_Flights");

            entity.HasOne(d => d.Category).WithMany(p => p.CategoriesFlights)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categories_Flights_Categories");

            entity.HasOne(d => d.Flight).WithMany(p => p.CategoriesFlights)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categories_Flights_Flights");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cities_Countries");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.Property(e => e.Date)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.ArrivalAiroportNavigation).WithMany(p => p.FlightArrivalAiroportNavigations)
                .HasForeignKey(d => d.ArrivalAiroport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Flights_Airports1");

            entity.HasOne(d => d.DepartureAiroportNavigation).WithMany(p => p.FlightDepartureAiroportNavigations)
                .HasForeignKey(d => d.DepartureAiroport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Flights_Airports");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(e => e.CategoriesFlightsId).HasColumnName("Categories_FlightsId");
            entity.Property(e => e.PurchaseDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.CategoriesFlights).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CategoriesFlightsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Categories_Flights");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
