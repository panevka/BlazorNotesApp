using BlazorNotesApp.Models;

namespace BlazorNotesApp.Services;

public interface INoteService
{
    Task CreateNote(Note note);
    
    Task<Note> GetNoteById(int id);
    
    Task<bool> DeleteNote(int id);
    
    Task<bool> UpdateNote(Note note);
    
    Task<List<Note>> GetAllNotes();
}