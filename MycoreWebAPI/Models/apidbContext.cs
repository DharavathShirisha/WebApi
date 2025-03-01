﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MycoreWebAPI.Models;

public partial class apidbContext : DbContext
{
    public apidbContext()
    {
    }

    public apidbContext(DbContextOptions<apidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ipl> Ipls { get; set; }

    public virtual DbSet<Winner> Winners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WKSPUN05GTR0907;Initial Catalog=apidb;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ipl>(entity =>
        {
            entity.HasKey(e => e.Teamno).HasName("PK__IPL__5ED2F4D800A67634");

            entity.ToTable("IPL");

            entity.Property(e => e.Teamno).HasColumnName("teamno");
            entity.Property(e => e.Captain)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("captain");
            entity.Property(e => e.Teamname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("teamname");
            entity.Property(e => e.Teamstate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("teamstate");
            entity.Property(e => e.Totalbudget).HasColumnName("totalbudget");
        });

        modelBuilder.Entity<Winner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__winners__3213E83F5E066F91");

            entity.ToTable("winners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Pom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pom");
            entity.Property(e => e.Runnerteam)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("runnerteam");
            entity.Property(e => e.Stadium)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("stadium");
            entity.Property(e => e.Winningteam)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("winningteam");
            entity.Property(e => e.Yearplayed).HasColumnName("yearplayed");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}