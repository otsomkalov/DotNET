using System.Web.Mvc;
using Pz3.Models;
using Pz3.Services.Interfaces;

namespace Pz3.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: Todo
        public ActionResult Index()
        {
            return View(_toDoService.Get());
        }

        // GET: Todo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpNotFoundResult();

            if (_toDoService.Get(id.Value) is ToDo toDo) return View(toDo);

            return new HttpNotFoundResult();
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDo toDo)
        {
            if (!ModelState.IsValid) return View(toDo);

            _toDoService.Add(toDo);

            return RedirectToAction(nameof(Index));
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpNotFoundResult();

            if (_toDoService.Get(id.Value) is ToDo toDo) return View(toDo);

            return new HttpNotFoundResult();
        }

        // POST: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDo toDo)
        {
            if (id != toDo.Id) return new HttpNotFoundResult();

            if (!ModelState.IsValid) return View(toDo);

            _toDoService.Update(id, toDo);

            return RedirectToAction(nameof(Index));
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpNotFoundResult();

            if (_toDoService.Get(id.Value) is ToDo toDo) return View(toDo);

            return new HttpNotFoundResult();
        }

        // POST: Todo/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _toDoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}