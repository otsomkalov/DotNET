using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lb3.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly Connection _db = new Connection();

        // GET: Companies
        public async Task<ActionResult> Index()
        {
            return View(await _db.Companies.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = await _db.Companies.FindAsync(id);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Companies.Add(company);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = await _db.Companies.FindAsync(id);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(company).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var company = await _db.Companies.FindAsync(id);
            if (company == null) return HttpNotFound();
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            var company = await _db.Companies.FindAsync(id);

            foreach (var companyStore in company.Stores) _db.StoreProducts.RemoveRange(companyStore.StoreProducts);

            _db.Stores.RemoveRange(company.Stores);
            _db.Companies.Remove(company);
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