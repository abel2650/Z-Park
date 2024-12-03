using Microsoft.EntityFrameworkCore;

namespace Z_ParkLib;
// Denne klasse konfigurerer entity framework til user databasen

// formålet med partial er at vi har 2 classes(inkl denne) men rør kun den ene her og ikke den anden.

// DbContext er en klasse fra entity framework, som vi bruger til at kommunikere med databasen
public partial class EFUserContext : DbContext
{                             // her laver vi en constructor
    public EFUserContext(DbContextOptions<EFUserContext> options) 
        : base(options)
    {
    }
               // den bliver brugt til repræsentere tabellen 
    public virtual DbSet<User> Users { get; set; }


// Defaultconnection er navnet på appsetings.json som den finder selv
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("DefaultConnection");
    


    
}