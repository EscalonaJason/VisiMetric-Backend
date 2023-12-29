using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

public class VMContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Wound> Wounds { get; set; }
    public DbSet<Measurement> Measurements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Set your database connection string here
        optionsBuilder.UseSqlServer("Server=localhost,35306;Database=visimetricdb;User Id=backend;Password=!Krems123;Encrypt=true;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wound>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<Wound>()
            .Property(w => w.Description)
            .IsRequired();

        modelBuilder.Entity<Wound>()
            .Property(w => w.UserId)
            .IsRequired();

        modelBuilder.Entity<Wound>()
            .HasOne(w => w.User)
            .WithMany(u => u.Wounds)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade); // The Wounds will be deleted, if the User they belong to is deleted
        
        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.Wound)
            .WithMany(w => w.Measurements)
            .HasForeignKey(m => m.WoundId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}