using System.Threading.Tasks;
using Lab5.Data;
using Lab5.Models;
using Lab5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Controllers
{
    public class MessagesController : Controller
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            return View(new IndexViewModel
            {
                Messages = await _context.Message.ToListAsync(),
                Message = new Message()
            });
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,Text")] Message message)
        {
            if (!ModelState.IsValid) return View("Index");
            _context.Add(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}