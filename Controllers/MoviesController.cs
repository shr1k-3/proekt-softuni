using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.Data;
using MovieCatalog.Models;

namespace MovieCatalog.Controllers;

public class MoviesController : Controller
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context) => _context = context;

    // READ (list)
    public async Task<IActionResult> Index()
    {
        var movies = await _context.Movies
            .Include(m => m.Genre)
            .Include(m => m.Director)
            .OrderBy(m => m.Title)
            .ToListAsync();
        return View(movies);
    }

    // READ (one)
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var movie = await _context.Movies
            .Include(m => m.Genre)
            .Include(m => m.Director)
            .FirstOrDefaultAsync(m => m.Id == id);
        return movie == null ? NotFound() : View(movie);
    }

    // CREATE
    public IActionResult Create()
    {
        LoadLists();
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Year,Rating,Description,GenreId,DirectorId")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        LoadLists(movie.GenreId, movie.DirectorId);
        return View(movie);
    }

    // UPDATE
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        LoadLists(movie.GenreId, movie.DirectorId);
        return View(movie);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Year,Rating,Description,GenreId,DirectorId")] Movie movie)
    {
        if (id != movie.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        LoadLists(movie.GenreId, movie.DirectorId);
        return View(movie);
    }

    // DELETE
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var movie = await _context.Movies
            .Include(m => m.Genre)
            .Include(m => m.Director)
            .FirstOrDefaultAsync(m => m.Id == id);
        return movie == null ? NotFound() : View(movie);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private void LoadLists(int? genreId = null, int? directorId = null)
    {
        ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Name", genreId);
        ViewBag.DirectorId = new SelectList(_context.Directors, "Id", "Name", directorId);
    }
}
