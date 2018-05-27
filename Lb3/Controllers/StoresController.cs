using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lb3.Controllers
{
    public class StoresController : Controller
    {
        private readonly Connection _db = new Connection();

        // GET: Stores
        public async Task<ActionResult> Index()
        {
            var stores = _db.Stores.Include(s => s.Company);
            return View(await stores.ToListAsync());
        }

        // GET: Stores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var store = await _db.Stores.FindAsync(id);
            if (store == null) return HttpNotFound();
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(_db.Companies, "Id", "Name");
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Address,CompanyId")]
            Store store)
        {
            if (ModelState.IsValid)
            {
                _db.Stores.Add(store);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(_db.Companies, "Id", "Name", store.CompanyId);
            return View(store);
        }

        // GET: Stores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var store = await _db.Stores.FindAsync(id);
            if (store == null) return HttpNotFound();
            ViewBag.CompanyId = new SelectList(_db.Companies, "Id", "Name", store.CompanyId);
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Address,CompanyId")]
            Store store)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(store).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(_db.Companies, "Id", "Name", store.CompanyId);
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var store = await _db.Stores.FindAsync(id);
            if (store == null) return HttpNotFound();
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var store = await _db.Stores.FindAsync(id);
            _db.StoreProducts.RemoveRange(store.StoreProducts);
            _db.Stores.Remove(store);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}