using BlazorNotesApp.BlazorNotesAppContext;
using BlazorNotesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotesApp.Services.Impl;

public class NoteServiceImpl  : INoteService
{
    private NoteDataContext? _context;
    private IDbContextFactory<NoteDataContext>  _contextFactory;
    
    public NoteServiceImpl(NoteDataContext context, IDbContextFactory<NoteDataContext> contextFactory)
    {
        _context = context;
        _contextFactory = contextFactory;
    }
    
    public async Task CreateNote(Note note)
    {
        _context ??= await _contextFactory.CreateDbContextAsync();
        _context?.Notes.Add(note);
        await _context.SaveChangesAsync(); 
    }

    public async Task<Note> GetNoteById(int id)
    {
        _context ??= await _contextFactory.CreateDbContextAsync();
        return _context?.Notes.Find(id);
    }

    public bool deleteNote(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateNote(Note note)
    {
        _context ??= await _contextFactory.CreateDbContextAsync();
        _context.Entry(note).State = EntityState.Modified;
        int affected = await _context.SaveChangesAsync();
        return affected > 0;
    }

    public async Task<List<Note>> GetAllNotes()
    {
        _context ??= await _contextFactory.CreateDbContextAsync();
        return _context?.Notes.ToList();
    }
}