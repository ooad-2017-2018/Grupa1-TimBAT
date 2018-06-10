namespace ASPBatNet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Security;

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

        public static List<Projekti> SviProjekti { get; set; }
        public static List<string> Visibility { get; set; }

        public static string Username { get; set; }
        public static string Email { get; set; }
        public static string Github_Link { get; set; }
        public static double Bodovi { get; set; }
        public static string Naziv { get; set; }
        public static string Datum { get; set; }
        public static string CV { get; set; }
        public static string Website { get; set; }
        public static string Kod { get; set; }
        public static string Quote { get; set; }
        public static string Image { get; set; }

        public static List<Korisnici> Kontakti { get; set; }
        public static List<Tehnologije> ListaTehnologija { get; set; }
        public static List<Notifikacije> ListaNotifikacija { get; set; }
        public static List<Poruke> ListaPoruka { get; set; }
        public static List<Projekti> ListaProjekata { get; set; }


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
