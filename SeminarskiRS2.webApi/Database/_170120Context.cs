using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SeminarskiRS2.webApi.Database
{
    public partial class _170120Context : DbContext
    {
        public _170120Context()
        {
        }

        public _170120Context(DbContextOptions<_170120Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<Gradovi> Gradovi { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Lige> Lige { get; set; }
        public virtual DbSet<Preporuke> Preporuke { get; set; }
        public virtual DbSet<Sektori> Sektori { get; set; }
        public virtual DbSet<Sjedala> Sjedala { get; set; }
        public virtual DbSet<Stadioni> Stadioni { get; set; }
        public virtual DbSet<Timovi> Timovi { get; set; }
        public virtual DbSet<Tribine> Tribine { get; set; }
        public virtual DbSet<Ulaznice> Ulaznice { get; set; }
        public virtual DbSet<Uplate> Uplate { get; set; }
        public virtual DbSet<Utakmice> Utakmice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=170120;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzave>(entity =>
            {
                entity.HasKey(e => e.DrzavaId);

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(35);
            });

            modelBuilder.Entity<Gradovi>(entity =>
            {
                entity.HasKey(e => e.GradId);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Gradovi)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gradovi__DrzavaI__398D8EEE");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.DatumRodjenja).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(35);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime).HasMaxLength(35);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(60);

                entity.Property(e => e.Prezime).HasMaxLength(35);

                entity.Property(e => e.Telefon).HasMaxLength(35);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Korisnici__GradI__3C69FB99");
            });

            modelBuilder.Entity<Lige>(entity =>
            {
                entity.HasKey(e => e.LigaId);

                entity.Property(e => e.LigaId).HasColumnName("LigaID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Lige)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lige__DrzavaID__3F466844");
            });

            modelBuilder.Entity<Preporuke>(entity =>
            {
                entity.HasKey(e => e.PreporukaId);

                entity.Property(e => e.PreporukaId).HasColumnName("PreporukaID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.TimId).HasColumnName("TimID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Preporuke)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preporuke__Koris__48CFD27E");

                entity.HasOne(d => d.Tim)
                    .WithMany(p => p.Preporuke)
                    .HasForeignKey(d => d.TimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preporuke__TimID__49C3F6B7");
            });

            modelBuilder.Entity<Sektori>(entity =>
            {
                entity.HasKey(e => e.SektorId);

                entity.Property(e => e.SektorId).HasColumnName("SektorID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.TribinaId).HasColumnName("TribinaID");

                entity.HasOne(d => d.Tribina)
                    .WithMany(p => p.Sektori)
                    .HasForeignKey(d => d.TribinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sektori__Tribina__4F7CD00D");
            });

            modelBuilder.Entity<Sjedala>(entity =>
            {
                entity.HasKey(e => e.SjedaloId);

                entity.Property(e => e.SjedaloId).HasColumnName("SjedaloID");

                entity.Property(e => e.Oznaka).IsRequired();

                entity.Property(e => e.SektorId).HasColumnName("SektorID");

                entity.HasOne(d => d.Sektor)
                    .WithMany(p => p.Sjedala)
                    .HasForeignKey(d => d.SektorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sjedala__SektorI__52593CB8");
            });

            modelBuilder.Entity<Stadioni>(entity =>
            {
                entity.HasKey(e => e.StadionId);

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Stadioni)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stadioni__GradID__4222D4EF");
            });

            modelBuilder.Entity<Timovi>(entity =>
            {
                entity.HasKey(e => e.TimId);

                entity.Property(e => e.TimId).HasColumnName("TimID");

                entity.Property(e => e.LigaId).HasColumnName("LigaID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.Slika).IsRequired();

                entity.Property(e => e.SlikaThumb).IsRequired();

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.HasOne(d => d.Liga)
                    .WithMany(p => p.Timovi)
                    .HasForeignKey(d => d.LigaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timovi__LigaID__45F365D3");

                entity.HasOne(d => d.Stadion)
                    .WithMany(p => p.Timovi)
                    .HasForeignKey(d => d.StadionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timovi__StadionI__44FF419A");
            });

            modelBuilder.Entity<Tribine>(entity =>
            {
                entity.HasKey(e => e.TribinaId);

                entity.Property(e => e.TribinaId).HasColumnName("TribinaID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.HasOne(d => d.Stadion)
                    .WithMany(p => p.Tribine)
                    .HasForeignKey(d => d.StadionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tribine__Stadion__4CA06362");
            });

            modelBuilder.Entity<Ulaznice>(entity =>
            {
                entity.HasKey(e => e.UlaznicaId);

                entity.Property(e => e.UlaznicaId).HasColumnName("UlaznicaID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.SjedaloId).HasColumnName("SjedaloID");

                entity.Property(e => e.UtakmicaId).HasColumnName("UtakmicaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Ulaznice)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ulaznice__Korisn__5CD6CB2B");

                entity.HasOne(d => d.Sjedalo)
                    .WithMany(p => p.Ulaznice)
                    .HasForeignKey(d => d.SjedaloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ulaznice__Sjedal__5AEE82B9");

                entity.HasOne(d => d.Utakmica)
                    .WithMany(p => p.Ulaznice)
                    .HasForeignKey(d => d.UtakmicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ulaznice__Utakmi__5BE2A6F2");
            });

            modelBuilder.Entity<Uplate>(entity =>
            {
                entity.HasKey(e => e.UplataId);

                entity.Property(e => e.UplataId).HasColumnName("UplataID");

                entity.Property(e => e.UlaznicaId).HasColumnName("UlaznicaID");

                entity.HasOne(d => d.Ulaznica)
                    .WithMany(p => p.Uplate)
                    .HasForeignKey(d => d.UlaznicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Uplate__Ulaznica__5FB337D6");
            });

            modelBuilder.Entity<Utakmice>(entity =>
            {
                entity.HasKey(e => e.UtakmicaId);

                entity.Property(e => e.UtakmicaId).HasColumnName("UtakmicaID");

                entity.Property(e => e.DomaciTimId).HasColumnName("DomaciTimID");

                entity.Property(e => e.GostujuciTimId).HasColumnName("GostujuciTimID");

                entity.Property(e => e.LigaId).HasColumnName("LigaID");

                entity.Property(e => e.StadionId).HasColumnName("StadionID");

                entity.HasOne(d => d.DomaciTim)
                    .WithMany(p => p.UtakmiceDomaciTim)
                    .HasForeignKey(d => d.DomaciTimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utakmice__Domaci__5535A963");

                entity.HasOne(d => d.GostujuciTim)
                    .WithMany(p => p.UtakmiceGostujuciTim)
                    .HasForeignKey(d => d.GostujuciTimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utakmice__Gostuj__5629CD9C");

                entity.HasOne(d => d.Liga)
                    .WithMany(p => p.Utakmice)
                    .HasForeignKey(d => d.LigaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utakmice__LigaID__571DF1D5");

                entity.HasOne(d => d.Stadion)
                    .WithMany(p => p.Utakmice)
                    .HasForeignKey(d => d.StadionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Utakmice__Stadio__5812160E");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
