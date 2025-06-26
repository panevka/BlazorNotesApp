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
    
    public async Task createNote(Note note)
    {
        _context ??= await _contextFactory.CreateDbContextAsync();
        _context?.Notes.Add(note);
        await _context.SaveChangesAsync(); 
    }

    public Note getNote(int id)
    {
        throw new NotImplementedException();
    }

    public bool deleteNote(int id)
    {
        throw new NotImplementedException();
    }

    public bool updateNote(Note note)
    {
        throw new NotImplementedException();
    }

    public List<Note> getAllNotes()
    {
        throw new NotImplementedException();
    }
}