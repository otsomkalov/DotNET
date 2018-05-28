using System.Threading.Tasks;
using Lab4.Models;
using Lab4.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: Todo
        public async Task<IActionResult> Index()
        {
            return View(await _toDoService.Get());
        }

        // GET: Todo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            if (await _toDoService.Get(id.Value) is ToDo toDo) return View(toDo);

            return NotFound();
        }

        // GET: Todo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsDone")] ToDo toDo)
        {
            if (!ModelState.IsValid) return View(toDo);

            await _toDoService.Add(toDo);

            return RedirectToAction(nameof(Index));
        }

        // GET: Todo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            if (await _toDoService.Get(id.Value) is ToDo toDo) return View(toDo);

            return NotFound();
        }

        // POST: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsDone")] ToDo toDo)
        {
            if (id != toDo.Id) return NotFound();

            if (!ModelState.IsValid) return View(toDo);

            await _toDoService.Update(toDo);

            return RedirectToAction(nameof(Index));
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            if (await _toDoService.Get(id.Value) is ToDo toDo) return View(toDo);

            return NotFound();
        }

        // POST: Todo/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _toDoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}