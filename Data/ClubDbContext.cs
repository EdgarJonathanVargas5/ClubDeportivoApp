using Microsoft.EntityFrameworkCore;
using ClubDeportivoApp.Models;
using Microsoft.Extensions.Configuration;

namespace ClubDeportivoApp.Data;

public class ClubDbContext : DbContext
{
    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Jugador> Jugadores { get; set; }
    public DbSet<Entrenador> Entrenadores { get; set; }
    public DbSet<Equipo> Equipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration root = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string? connectionString = root.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no fue encontrada.");
        }

        var serverVersion = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participante>().ToTable("Participantes");
        modelBuilder.Entity<Jugador>().ToTable("Jugadores");
        modelBuilder.Entity<Entrenador>().ToTable("Entrenadores");
        modelBuilder.Entity<Equipo>().ToTable("Equipos");

        modelBuilder.Entity<Participante>().HasKey(p => p.Id);
        modelBuilder.Entity<Equipo>().HasKey(e => e.Id);

        modelBuilder.Entity<Participante>().HasIndex(p => p.Dni).IsUnique();
        modelBuilder.Entity<Equipo>().HasIndex(e => e.Codigo).IsUnique();

        modelBuilder.Entity<Equipo>()
            .HasOne(e => e.Entrenador)
            .WithOne(ent => ent.EquipoDirigido)
            .HasForeignKey<Equipo>(e => e.EntrenadorId);

        modelBuilder.Entity<Equipo>()
            .HasMany(e => e.Jugadores)
            .WithOne(j => j.Equipo)
            .HasForeignKey(j => j.EquipoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}