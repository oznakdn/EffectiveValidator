using Example.WebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace Example.WebApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    const string CONNECTION_STRING = "Data Source = C:\\Users\\USER\\Desktop\\EffectiveValidator\\example\\Example.WebApi\\Database\\PersonsDB.db";

    public DbSet<Person> Persons { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite(CONNECTION_STRING);
    }

}
