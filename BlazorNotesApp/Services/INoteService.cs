using BlazorNotesApp.Models;

namespace BlazorNotesApp.Services;

public interface INoteService
{
    Task createNote(Note note);
    
    Note getNote(int id);
    
    bool deleteNote(int id);
    
    bool updateNote(Note note);
    
    List<Note> getAllNotes();
}