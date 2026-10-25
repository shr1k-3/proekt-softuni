using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.Data;

namespace MovieCatalog.Controllers;

public class DirectorsController : Controller
{
    private readonly AppDbContext _context;

    public DirectorsController(AppDbContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        var directors = await _context.Directors
            .Include(d => d.Movies)
            .OrderBy(d => d.Name)
            .ToListAsync();
        return View(directors);
    }
}
