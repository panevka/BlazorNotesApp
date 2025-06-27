using BlazorNotesApp.BlazorNotesAppContext;
using BlazorNotesApp.Models;
using BlazorNotesApp.Services.Impl;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BlazorNotesApp;

[TestFixture]
public class Test
{
    private SqliteConnection _connection;
    private DbContextOptions<NoteDataContext> _options;

    [SetUp]
    public void Setup()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        
        _options = new DbContextOptionsBuilder<NoteDataContext>()
            .UseSqlite(_connection)
            .EnableSensitiveDataLogging()
            .Options;
    }
    
     [Test]
    public void GetNoteById_ReturnsCorrectNote2()
    {
        var mockDbFactory = new Mock<IDbContextFactory<NoteDataContext>>();
        mockDbFactory.Setup(f => f.CreateDbContextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(() => new NoteDataContext(_options));
        
        var context = new NoteDataContext(_options);
        
        context.Database.EnsureCreated();

        int arrLength = 10;
        Note[] notes = new Note[arrLength];
        Random rnd = new Random();
        for (int i = 0; i < arrLength; i++)
        {
            notes[i] = new Note()
            {
                Id = i + 1,
                Title = "Title " + rnd.Next(0, 1000),
                Content = "Content " + rnd.Next(0, 1000),
                CreatedAt = DateTime.Now,
            };
            
            context.Notes.Add(notes[i]);
            context.SaveChanges();
        }
        
        NoteServiceImpl
            noteService = new NoteServiceImpl(context, mockDbFactory.Object);

        for (int i = 0; i < arrLength; i++)
        {
            var result = noteService.GetNoteById(i + 1);
            Note arrNote = notes[i];
            Assert.That(result.Result.Id, Is.EqualTo(arrNote.Id));
            Assert.That(result.Result.Title, Is.EqualTo(arrNote.Title));
            Assert.That(result.Result.Content, Is.EqualTo(arrNote.Content));
            Assert.That(result.Result.CreatedAt, Is.EqualTo(arrNote.CreatedAt));
        }
        
    }
    
}