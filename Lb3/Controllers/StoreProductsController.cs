using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lb3.Controllers
{
    public class StoreProductsController : Controller
    {
        private readonly Connection _db = new Connection();

        // GET: StoreProducts
        public async Task<ActionResult> Index()
        {
            var storeProducts = _db.StoreProducts.Include(s => s.Product).Include(s => s.Store);
            return View(await storeProducts.ToListAsync());
        }

        // GET: StoreProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var storeProduct = await _db.StoreProducts.FindAsync(id);
            if (storeProduct == null) return HttpNotFound();
            return View(storeProduct);
        }

        // GET: StoreProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            ViewBag.StoreId = new SelectList(_db.Stores, "Id", "Address");
            return View();
        }

        // POST: StoreProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Count,Price,ProductId,StoreId")]
            StoreProduct storeProduct)
        {
            if (ModelState.IsValid)
            {
                _db.StoreProducts.Add(storeProduct);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name", storeProduct.ProductId);
            ViewBag.StoreId = new SelectList(_db.Stores, "Id", "Address", storeProduct.StoreId);
            return View(storeProduct);
        }

        // GET: StoreProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var storeProduct = await _db.StoreProducts.FindAsync(id);
            if (storeProduct == null) return HttpNotFound();
            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name", storeProduct.ProductId);
            ViewBag.StoreId = new SelectList(_db.Stores, "Id", "Address", storeProduct.StoreId);
            return View(storeProduct);
        }

        // POST: StoreProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Count,Price,ProductId,StoreId")]
            StoreProduct storeProduct)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(storeProduct).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name", storeProduct.ProductId);
            ViewBag.StoreId = new SelectList(_db.Stores, "Id", "Address", storeProduct.StoreId);
            return View(storeProduct);
        }

        // GET: StoreProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var storeProduct = await _db.StoreProducts.FindAsync(id);
            if (storeProduct == null) return HttpNotFound();
            return View(storeProduct);
        }

        // POST: StoreProducts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var storeProduct = await _db.StoreProducts.FindAsync(id);
            _db.StoreProducts.Remove(storeProduct);
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