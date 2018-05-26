namespace ASPBatNet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ASPBatNetModel : DbContext
    {
        public ASPBatNetModel()
            : base("name=ASPBatNetModel")
        {
        }

        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Notifikacije> Notifikacije { get; set; }
        public virtual DbSet<Poruke> Poruke { get; set; }
        public virtual DbSet<Projekti> Projekti { get; set; }
        public virtual DbSet<Tehnologije> Tehnologije { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnici>()
                .Property(e => e.datum)
                .HasPrecision(3);

            modelBuilder.Entity<Korisnici>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Notifikacije>()
                .Property(e => e.datum)
                .HasPrecision(3);

            modelBuilder.Entity<Notifikacije>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Poruke>()
                .Property(e => e.datum_slanja)
                .HasPrecision(3);

            modelBuilder.Entity<Poruke>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Projekti>()
                .Property(e => e.datum_kreiranja)
                .HasPrecision(3);

            modelBuilder.Entity<Projekti>()
                .Property(e => e.datum_zavrsetka)
                .HasPrecision(3);

            modelBuilder.Entity<Projekti>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Tehnologije>()
                .Property(e => e.version)
                .IsFixedLength();
        }
    }
}
