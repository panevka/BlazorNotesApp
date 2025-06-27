using BlazorNotesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotesApp.BlazorNotesAppContext;

public class NoteDataContext : DbContext
{
    protected readonly DbContextOptions<NoteDataContext> options;
    
    public NoteDataContext(DbContextOptions<NoteDataContext> options) : base(options)
    {
        this.options = options;
    }
    
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().ToTable("Notes");
    }
}