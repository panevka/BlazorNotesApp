using BlazorNotesApp.BlazorNotesAppContext;
using BlazorNotesApp.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotesApp.Services.Impl;

public class NoteServiceImpl  : INoteService
{
    private NoteDataContext? _context;
    private IDbContextFactory<NoteDataContext>  _contextFactory;
    private readonly IValidator<Note> _validator;
    
    public NoteServiceImpl(NoteDataContext context, IDbContextFactory<NoteDataContext> contextFactory, IValidator<Note> validator)
    {
        _context = context;
        _contextFactory = contextFactory;
        _validator = validator;
    }
    
    public async Task CreateNote(Note note)
    {
        _validator.ValidateAndThrow(note);
        _context ??= await _contextFactory.CreateDbContextAsync();
        _context?.Notes.Add(note);
        await _context.SaveChangesAsync(); 
    }

    public async Task<Note> GetNoteById(int id)
    {
        _context ??= await _contextFactory.CreateDbContextAsync();
        return _context?.Notes.Find(id);
    }

    public async Task<bool> DeleteNote(int id)
    {
        _context ??= await _contextFactory.CreateDbContextAsync();
        _context.Notes.Where(n => n.Id == id).ExecuteDeleteAsync();
        return true;
    }

    public async Task<bool> UpdateNote(Note note)
    {
        _validator.ValidateAndThrow(note);
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