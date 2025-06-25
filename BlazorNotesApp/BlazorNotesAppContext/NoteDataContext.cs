using BlazorNotesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotesApp.BlazorNotesAppContext;

public class NoteDataContext : DbContext
{
    protected readonly IConfiguration _configuration;
    
    public NoteDataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("BlazorNotesApp"));
    }
    
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().ToTable("Notes");
    }
}