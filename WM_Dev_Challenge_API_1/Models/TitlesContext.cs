using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WM_Dev_Challenge_API_1
{
    public partial class TitlesContext : DbContext
    {
        public TitlesContext()
        {
        }

        public TitlesContext(DbContextOptions<TitlesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<OtherName> OtherNames { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<StoryLine> StoryLines { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<TitleGenre> TitleGenres { get; set; }
        public virtual DbSet<TitleParticipant> TitleParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=WMDevChallengeConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Award>(entity =>
            {
                entity.ToTable("Award");

                entity.Property(e => e.Award1)
                    .HasMaxLength(100)
                    .HasColumnName("Award");

                entity.Property(e => e.AwardCompany).HasMaxLength(100);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Awards)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Award_FK_Award_Title");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<OtherName>(entity =>
            {
                entity.ToTable("OtherName");

                entity.Property(e => e.TitleName).HasMaxLength(100);

                entity.Property(e => e.TitleNameLanguage).HasMaxLength(100);

                entity.Property(e => e.TitleNameSortable).HasMaxLength(100);

                entity.Property(e => e.TitleNameType).HasMaxLength(100);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.OtherNames)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("OtherName_FK_OtherName_Title");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ParticipantType).HasMaxLength(100);
            });

            modelBuilder.Entity<StoryLine>(entity =>
            {
                entity.ToTable("StoryLine");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Language).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.StoryLines)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StoryLine_FK_StoryLine_Title");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("Title");

                entity.Property(e => e.TitleId).ValueGeneratedNever();

                entity.Property(e => e.ProcessedDateTimeUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("ProcessedDateTimeUTC");

                entity.Property(e => e.TitleName).HasMaxLength(100);

                entity.Property(e => e.TitleNameSortable).HasMaxLength(100);
            });

            modelBuilder.Entity<TitleGenre>(entity =>
            {
                entity.ToTable("TitleGenre");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.TitleGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleGenre_FK_TitleGenre_Genre");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleGenres)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleGenre_FK_TitleGenre_Title");
            });

            modelBuilder.Entity<TitleParticipant>(entity =>
            {
                entity.ToTable("TitleParticipant");

                entity.Property(e => e.RoleType).HasMaxLength(100);

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.TitleParticipants)
                    .HasForeignKey(d => d.ParticipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleParticipant_FK_TitleParticipant_Participant");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleParticipants)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TitleParticipant_FK_TitleParticipant_Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
