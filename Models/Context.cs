using Microsoft.EntityFrameworkCore;

public class Context:DbContext{


public DbSet<User> TblUser{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=.;Database=SuperMarket;MultipleActiveResultSets=true;TrustServerCertificate=True;Trusted_Connection=True;");
    }

}