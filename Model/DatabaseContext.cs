using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext{

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Thread> Threads { get; set; }

}