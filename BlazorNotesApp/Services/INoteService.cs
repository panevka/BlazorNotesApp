using BlazorNotesApp.Models;

namespace BlazorNotesApp.Services;

public interface INoteService
{
    Task CreateNote(Note note);
    
    Task<Note> GetNoteById(int id);
    
    bool deleteNote(int id);
    
    bool updateNote(Note note);
    
    Task<List<Note>> GetAllNotes();
}