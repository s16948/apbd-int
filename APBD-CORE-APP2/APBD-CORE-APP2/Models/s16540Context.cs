using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APBD_CORE_APP2.Models
{
    public partial class s16540Context : DbContext
    {
        //public s16540Context()
        //{
        //}

        public s16540Context(DbContextOptions<s16540Context> options)
            : base(options)
        {
        }
        

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Dydaktycy> Dydaktycy { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Gosc> Gosc { get; set; }
        public virtual DbSet<Handles> Handles { get; set; }
        public virtual DbSet<Kategoria> Kategoria { get; set; }
        public virtual DbSet<Multicomponents> Multicomponents { get; set; }
        public virtual DbSet<Multisoftware> Multisoftware { get; set; }
        public virtual DbSet<Oceny> Oceny { get; set; }
        public virtual DbSet<Osoby> Osoby { get; set; }
        public virtual DbSet<Pokoj> Pokoj { get; set; }
        public virtual DbSet<Przedmioty> Przedmioty { get; set; }
        public virtual DbSet<Rezerwacja> Rezerwacja { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<StationUsed> StationUsed { get; set; }
        public virtual DbSet<StopnieTytuly> StopnieTytuly { get; set; }
        public virtual DbSet<Studenci> Studenci { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentSubject> StudentSubject { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        // Unable to generate entity type for table 'dbo.EMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Magazyn'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.budzet'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source = db-mssql; Initial Catalog=s16540;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .HasColumnName("Client_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FistName)
                    .IsRequired()
                    .HasColumnName("Fist_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Components>(entity =>
            {
                entity.HasKey(e => e.ComponentId);

                entity.Property(e => e.ComponentId)
                    .HasColumnName("component_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dydaktycy>(entity =>
            {
                entity.HasKey(e => e.OsobaId);

                entity.Property(e => e.OsobaId)
                    .HasColumnName("Osoba_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnName("Data_zatrudnienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.StopienId).HasColumnName("Stopien_Id");

                entity.HasOne(d => d.Osoba)
                    .WithOne(p => p.Dydaktycy)
                    .HasForeignKey<Dydaktycy>(d => d.OsobaId)
                    .HasConstraintName("FK_osoba_Dydaktyk");

                entity.HasOne(d => d.PodlegaNavigation)
                    .WithMany(p => p.InversePodlegaNavigation)
                    .HasForeignKey(d => d.Podlega)
                    .HasConstraintName("FK_Dydaktyk_Dydaktyk");

                entity.HasOne(d => d.Stopien)
                    .WithMany(p => p.Dydaktycy)
                    .HasForeignKey(d => d.StopienId)
                    .HasConstraintName("FK_DydaktycyStopnie_tytuly");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gosc>(entity =>
            {
                entity.HasKey(e => e.IdGosc);

                entity.Property(e => e.IdGosc).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProcentRabatu).HasColumnName("Procent_rabatu");
            });

            modelBuilder.Entity<Handles>(entity =>
            {
                entity.HasKey(e => new { e.EmployeesEmployeeId, e.SessionsSessionId });

                entity.Property(e => e.EmployeesEmployeeId).HasColumnName("Employees_employee_id");

                entity.Property(e => e.SessionsSessionId).HasColumnName("Sessions_session_id");

                entity.HasOne(d => d.EmployeesEmployee)
                    .WithMany(p => p.Handles)
                    .HasForeignKey(d => d.EmployeesEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Handles_Employees");

                entity.HasOne(d => d.SessionsSession)
                    .WithMany(p => p.Handles)
                    .HasForeignKey(d => d.SessionsSessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Handles_Sessions");
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.HasKey(e => e.IdKategoria);

                entity.Property(e => e.IdKategoria).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Multicomponents>(entity =>
            {
                entity.HasKey(e => new { e.ComponentsComponentId, e.StationsStationId });

                entity.Property(e => e.ComponentsComponentId).HasColumnName("Components_component_id");

                entity.Property(e => e.StationsStationId).HasColumnName("Stations_station_id");

                entity.HasOne(d => d.ComponentsComponent)
                    .WithMany(p => p.Multicomponents)
                    .HasForeignKey(d => d.ComponentsComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Multicomponents_Components");

                entity.HasOne(d => d.StationsStation)
                    .WithMany(p => p.Multicomponents)
                    .HasForeignKey(d => d.StationsStationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Multicomponents_Stations");
            });

            modelBuilder.Entity<Multisoftware>(entity =>
            {
                entity.HasKey(e => new { e.StationsStationId, e.SoftwareSoftId });

                entity.Property(e => e.StationsStationId).HasColumnName("Stations_station_id");

                entity.Property(e => e.SoftwareSoftId).HasColumnName("Software_soft_id");

                entity.HasOne(d => d.SoftwareSoft)
                    .WithMany(p => p.Multisoftware)
                    .HasForeignKey(d => d.SoftwareSoftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Multisoftware_Software");

                entity.HasOne(d => d.StationsStation)
                    .WithMany(p => p.Multisoftware)
                    .HasForeignKey(d => d.StationsStationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Multisoftware_Stations");
            });

            modelBuilder.Entity<Oceny>(entity =>
            {
                entity.HasKey(e => new { e.PrzedmiotId, e.DataWystawienia, e.Student });

                entity.Property(e => e.PrzedmiotId).HasColumnName("Przedmiot_Id");

                entity.Property(e => e.DataWystawienia)
                    .HasColumnName("Data_wystawienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ocena).HasColumnType("numeric(2, 1)");

                entity.HasOne(d => d.DydaktykNavigation)
                    .WithMany(p => p.Oceny)
                    .HasForeignKey(d => d.Dydaktyk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oceny_Dydaktycy");

                entity.HasOne(d => d.Przedmiot)
                    .WithMany(p => p.Oceny)
                    .HasForeignKey(d => d.PrzedmiotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oceny_Przedmioty");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.Oceny)
                    .HasForeignKey(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocenytudenci");
            });

            modelBuilder.Entity<Osoby>(entity =>
            {
                entity.HasKey(e => e.OsobaId);

                entity.Property(e => e.OsobaId).HasColumnName("Osoba_Id");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pokoj>(entity =>
            {
                entity.HasKey(e => e.NrPokoju);

                entity.Property(e => e.NrPokoju).ValueGeneratedNever();

                entity.Property(e => e.LiczbaMiejsc).HasColumnName("Liczba_miejsc");

                entity.HasOne(d => d.IdKategoriaNavigation)
                    .WithMany(p => p.Pokoj)
                    .HasForeignKey(d => d.IdKategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pokoj__IdKategor__6383C8BA");
            });

            modelBuilder.Entity<Przedmioty>(entity =>
            {
                entity.HasKey(e => e.PrzedmiotId);

                entity.HasIndex(e => e.Przedmiot)
                    .HasName("Unique_Przedmiot_S")
                    .IsUnique();

                entity.HasIndex(e => e.PrzedmiotSkrot)
                    .HasName("Unique_Przedmiot_skrot_S")
                    .IsUnique();

                entity.Property(e => e.PrzedmiotId).HasColumnName("Przedmiot_Id");

                entity.Property(e => e.Przedmiot)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrzedmiotSkrot)
                    .IsRequired()
                    .HasColumnName("Przedmiot_skrot")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rezerwacja>(entity =>
            {
                entity.HasKey(e => e.IdRezerwacja);

                entity.Property(e => e.IdRezerwacja).ValueGeneratedNever();

                entity.Property(e => e.DataDo).HasColumnType("datetime");

                entity.Property(e => e.DataOd).HasColumnType("datetime");

                entity.HasOne(d => d.IdGoscNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.IdGosc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezerwacj__IdGos__66603565");

                entity.HasOne(d => d.NrPokojuNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.NrPokoju)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezerwacj__NrPok__6754599E");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientsClientId).HasColumnName("Clients_Client_ID");

                entity.Property(e => e.IsPaid).HasColumnName("isPaid");

                entity.Property(e => e.SDate)
                    .IsRequired()
                    .HasColumnName("S_DATE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientsClient)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.ClientsClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sessions_Clients");
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.HasKey(e => e.SoftId);

                entity.Property(e => e.SoftId)
                    .HasColumnName("soft_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SerialKey)
                    .IsRequired()
                    .HasColumnName("Serial_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.HasKey(e => e.StationId);

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<StationUsed>(entity =>
            {
                entity.HasKey(e => new { e.StationsStationId, e.SessionsSessionId });

                entity.Property(e => e.StationsStationId).HasColumnName("Stations_station_id");

                entity.Property(e => e.SessionsSessionId).HasColumnName("Sessions_session_id");

                entity.HasOne(d => d.SessionsSession)
                    .WithMany(p => p.StationUsed)
                    .HasForeignKey(d => d.SessionsSessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StationUsed_Sessions");

                entity.HasOne(d => d.StationsStation)
                    .WithMany(p => p.StationUsed)
                    .HasForeignKey(d => d.StationsStationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StationUsed_Stations");
            });

            modelBuilder.Entity<StopnieTytuly>(entity =>
            {
                entity.HasKey(e => e.StopienId);

                entity.ToTable("Stopnie_tytuly");

                entity.HasIndex(e => e.Stopien)
                    .HasName("Unique_Stopien")
                    .IsUnique();

                entity.HasIndex(e => e.StopienSkrot)
                    .HasName("Unique_Stopien_skrot")
                    .IsUnique();

                entity.Property(e => e.StopienId).HasColumnName("Stopien_Id");

                entity.Property(e => e.Stopien)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.StopienSkrot)
                    .IsRequired()
                    .HasColumnName("Stopien_skrot")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Studenci>(entity =>
            {
                entity.HasKey(e => e.OsobaId);

                entity.Property(e => e.OsobaId)
                    .HasColumnName("Osoba_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataRekrutacji)
                    .HasColumnName("Data_rekrutacji")
                    .HasColumnType("datetime");

                entity.Property(e => e.NrIndeksu)
                    .HasColumnName("Nr_Indeksu")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Osoba)
                    .WithOne(p => p.Studenci)
                    .HasForeignKey<Studenci>(d => d.OsobaId)
                    .HasConstraintName("FK_Osoba_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent);

                entity.Property(e => e.IdStudent);

                

                entity.ToTable("Student", "apbd");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IndexNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.HasKey(e => new { e.IdStudentSubject, e.IdStudent, e.IdSubject });

                entity.ToTable("Student_Subject", "apbd");

                entity.Property(e => e.IdStudentSubject).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudies);

                entity.ToTable("Studies", "apbd");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject);

                entity.ToTable("Subject", "apbd");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
