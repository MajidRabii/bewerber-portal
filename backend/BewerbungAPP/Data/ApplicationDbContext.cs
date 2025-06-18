using Microsoft.EntityFrameworkCore;
using BewerbungAPP.Models;
using BewerbungAPP.ViewModels;

namespace BewerbungAPP.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // DbSet Properties
    public DbSet<Person> Personen => Set<Person>();
    public DbSet<Profil> Profile => Set<Profil>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Stadt> Staedte => Set<Stadt>();
    public DbSet<Abschlussart> Abschlussarten => Set<Abschlussart>();
    public DbSet<Studiengang> Studiengaenge => Set<Studiengang>();
    public DbSet<Beruf> Berufe => Set<Beruf>();
    public DbSet<BewerberProfilViewModel> BewerberprofilModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Globale Einstellung für alle DateTime-Felder
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetColumnType("timestamptz");
                }
            }
        }

        ConfigureUser(modelBuilder);
        ConfigureStadt(modelBuilder);
        ConfigureAbschlussart(modelBuilder);
        ConfigureStudiengang(modelBuilder);
        ConfigureBeruf(modelBuilder);
        ConfigurePerson(modelBuilder);
        ConfigureProfil(modelBuilder);
        ConfigureBewerberProfilViewModel(modelBuilder);
    }

    private void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("varchar(100)");
            entity.Property(e => e.Email).HasColumnName("email").HasColumnType("varchar(255)").IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Password).HasColumnName("password").HasColumnType("varchar(255)").IsRequired();
            entity.Property(e => e.Type).HasColumnName("type").HasColumnType("varchar(20)").HasDefaultValue("user");
            entity.Property(e => e.Status).HasColumnName("status").HasColumnType("boolean").HasDefaultValue(true);
            entity.Property(e => e.Created_At).HasColumnName("created_at").HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Last_Active_At).HasColumnName("last_active_at").HasDefaultValueSql("NOW()");
        });
    }

    private void ConfigureStadt(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stadt>(entity =>
        {
            entity.ToTable("stadt");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Code).HasColumnType("smallint");
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Name).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Bundesland).HasColumnType("varchar(100)");
            entity.Property(e => e.Aktiv).HasDefaultValue(true);
        });
    }

    private void ConfigureAbschlussart(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abschlussart>(entity =>
        {
            entity.ToTable("abschlussart");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Code).HasColumnType("smallint");
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Name_DE).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Name_EN).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Aktiv).HasDefaultValue(true);
        });
    }

    private void ConfigureStudiengang(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Studiengang>(entity =>
        {
            entity.ToTable("studiengang");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Code).HasColumnType("smallint");
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Name_DE).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Name_EN).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Aktiv).HasDefaultValue(true);
        });
    }

    private void ConfigureBeruf(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beruf>(entity =>
        {
            entity.ToTable("beruf");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Code).HasColumnType("smallint");
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Name_DE).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Name_EN).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Aktiv).HasDefaultValue(true);
        });
    }

    private void ConfigurePerson(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Anrede).HasColumnType("char(1)");
            entity.Property(e => e.Vorname).HasColumnType("varchar(100)").IsRequired();
            entity.Property(e => e.Nachname).HasColumnType("varchar(150)").IsRequired();
            entity.Property(e => e.Geburtstag).HasColumnType("date");
            entity.Property(e => e.Geburtsort_Id).HasColumnType("integer");
            entity.Property(e => e.Adresse).HasColumnType("varchar(150)").IsRequired();
            entity.Property(e => e.Laendercode).HasColumnType("varchar(10)").IsRequired();
            entity.Property(e => e.Handynummer).HasColumnType("varchar(20)").IsRequired();

            entity.Property(e => e.Bild);
            entity.Property(e => e.Bild_Datei).HasColumnType("bytea");
            entity.Property(e => e.Bild_Name).HasColumnType("varchar(255)");
            entity.Property(e => e.Bild_Type).HasColumnType("varchar(50)");

            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Erstellen_Date).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Zuletzt_Aktiv_Date).HasDefaultValueSql("NOW()");

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.User_Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Geburtsort)
                .WithMany()
                .HasForeignKey(e => e.Geburtsort_Id)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureProfil(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profil>(entity =>
        {
            entity.ToTable("profil");
            entity.HasKey(e => e.Id);

            // Properties
            entity.Property(e => e.Person_Id).HasColumnType("integer");
            entity.Property(e => e.Beruf1_Id).HasColumnType("integer");
            entity.Property(e => e.Erfahrung1).HasColumnType("smallint");
            entity.Property(e => e.Beruf2_Id).HasColumnType("integer");
            entity.Property(e => e.Erfahrung2).HasColumnType("smallint");
            entity.Property(e => e.Abschlussart_Id).HasColumnType("integer");
            entity.Property(e => e.Studiengang_Id).HasColumnType("integer");
            entity.Property(e => e.Einrichtung).HasColumnType("varchar(150)");
            entity.Property(e => e.Studienort_Id).HasColumnType("integer");

            entity.Property(e => e.Deutsch_Id).HasColumnType("smallint");
            entity.Property(e => e.Englisch_Id).HasColumnType("smallint");
            entity.Property(e => e.Niveau_Id).HasColumnType("smallint");
            entity.Property(e => e.Zertifikate_Id).HasColumnType("smallint");
            entity.Property(e => e.Persisch_Id).HasColumnType("smallint");
            entity.Property(e => e.Fuehrerschein_Id).HasColumnType("smallint");
            entity.Property(e => e.Auto).HasDefaultValue(false);
            entity.Property(e => e.Einsatzwunsch_Id).HasColumnType("smallint");

            entity.Property(e => e.Lebenslauf_Datei).HasColumnType("bytea");
            entity.Property(e => e.Lebenslauf_Name).HasColumnType("varchar(255)");
            entity.Property(e => e.Lebenslauf_Type).HasColumnType("varchar(50)");

            entity.Property(e => e.Bewerbung_Datei).HasColumnType("bytea");
            entity.Property(e => e.Bewerbung_Name).HasColumnType("varchar(255)");
            entity.Property(e => e.Bewerbung_Type).HasColumnType("varchar(50)");

            entity.Property(e => e.Sprachzertifikate_Datei).HasColumnType("bytea");
            entity.Property(e => e.Sprachzertifikate_Name).HasColumnType("varchar(255)");
            entity.Property(e => e.Sprachzertifikate_Type).HasColumnType("varchar(50)");

            entity.Property(e => e.Studiumzertifikate_Datei).HasColumnType("bytea");
            entity.Property(e => e.Studiumzertifikate_Name).HasColumnType("varchar(255)");
            entity.Property(e => e.Studiumzertifikate_Type).HasColumnType("varchar(50)");

            entity.Property(e => e.Arbeitserlaubnis).HasDefaultValue(false);
            entity.Property(e => e.Ankunftsdatum).HasColumnType("date");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Erstellen_Date).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Zuletzt_Aktiv_Date).HasDefaultValueSql("NOW()");

            // Relations
            entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.User_Id).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.Person_Id).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Studienort).WithMany().HasForeignKey(e => e.Studienort_Id).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Beruf1).WithMany().HasForeignKey(e => e.Beruf1_Id).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Beruf2).WithMany().HasForeignKey(e => e.Beruf2_Id).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Abschlussart).WithMany().HasForeignKey(e => e.Abschlussart_Id).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Studiengang).WithMany().HasForeignKey(e => e.Studiengang_Id).OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureBewerberProfilViewModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BewerberProfilViewModel>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("Bewerberprofil");
            entity.Property(e => e.PersonId).HasColumnName("PersonId");
        });
    }
}
