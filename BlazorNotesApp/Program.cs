using BlazorNotesApp.BlazorNotesAppContext;
using BlazorNotesApp.Components;
using BlazorNotesApp.Models;
using BlazorNotesApp.Services;
using BlazorNotesApp.Services.Impl;
using BlazorNotesApp.Utils;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BlazorNotesApp");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContextFactory<NoteDataContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<INoteService, NoteServiceImpl>();

builder.Services.AddTransient<IValidator<Note>, NoteValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();