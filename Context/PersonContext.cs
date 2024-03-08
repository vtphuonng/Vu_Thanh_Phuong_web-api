using Microsoft.EntityFrameworkCore;
using personinfor.Models;

public class personContex : DbContext
{
    public personContex(DbContextOptions<personContex> options) : base(options)
    {
    } 

    public DbSet<socialPlatformsModels> socailPl {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<socialPlatformsModels>().ToTable("socialplatforms", schema:"peopledata");
    }
}