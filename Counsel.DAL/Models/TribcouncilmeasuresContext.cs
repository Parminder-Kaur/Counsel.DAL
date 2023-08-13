using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Counsel.DAL.Models;

public partial class TribcouncilmeasuresContext : DbContext
{
    public TribcouncilmeasuresContext()
    {
    }

    public TribcouncilmeasuresContext(DbContextOptions<TribcouncilmeasuresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Measure> Measures { get; set; }

    public virtual DbSet<Vote> Votes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Measure>(entity =>
        {
            entity.HasKey(e => e.MeasureId).HasName("PK__Measure__8C56D080802E9E97");

            entity.ToTable("Measure");

            entity.Property(e => e.MeasureId).ValueGeneratedNever();
            entity.Property(e => e.MeasureDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MeasureName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MeasureResults)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MeasureStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MeasureSubject)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vote>(entity =>
        {
            entity.HasKey(e => e.VoteId).HasName("PK__Vote__52F015C2C36D398E");

            entity.ToTable("Vote");

            entity.HasIndex(e => new { e.VoterName, e.MeasureId }, "UC_VoterNameMeasureId").IsUnique();

            entity.Property(e => e.VoteId).ValueGeneratedNever();
            entity.Property(e => e.Vote1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Vote");
            entity.Property(e => e.VoterName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Measure).WithMany(p => p.Votes)
                .HasForeignKey(d => d.MeasureId)
                .HasConstraintName("FK__Vote__MeasureId__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
