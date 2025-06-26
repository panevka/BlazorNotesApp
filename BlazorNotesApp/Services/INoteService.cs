using BlazorNotesApp.Models;

namespace BlazorNotesApp.Services;

public interface INoteService
{
    bool createNote(Note note);
    
    Note getNote(int id);
    
    bool deleteNote(int id);
    
    bool updateNote(Note note);
    
    List<Note> getAllNotes();
}