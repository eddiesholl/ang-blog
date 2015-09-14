using ang_blog.Data;
using ang_blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ang_blog.Controllers
{
    public class BlogEntryController : Controller
    {
        // GET: BlogEntry
        public ActionResult Index()
        {
            var items = LoadBlogEntries();
            return PartialView(items);
        }

        public JsonResult GetBlogEntries()
        {
            var items = LoadBlogEntries();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<BlogEntryModel> LoadBlogEntries()
        {
            return DocumentDBRepository<BlogEntryModel>.GetItems(b => true/*b.IsApproved*/).OrderByDescending(b => b.ApprovedOn);
        }

        public ActionResult Details(string id)
        {
            var items = DocumentDBRepository<BlogEntryModel>.GetItem(b => b.IsApproved && b.ID.Equals(id));
            return View(items);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Content")] BlogEntryModel item)
        {
            if (ModelState.IsValid)
            {
                item.ID = string.Empty;// Guid.NewGuid().ToString();
                item.CreatedOn = DateTime.Now;
                item.IsApproved = true;
                item.ApprovedOn = DateTime.Now;

                await DocumentDBRepository<BlogEntryModel>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,Content,IsApproved,CreatedOn")] BlogEntryModel item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<BlogEntryModel>.UpdateItemAsync(item.ID, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogEntryModel item = DocumentDBRepository<BlogEntryModel>.GetItem(d => d.ID.Equals(id));

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include = "ID")] BlogEntryModel item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<BlogEntryModel>.DeleteItemAsync(item.ID);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogEntryModel item = DocumentDBRepository<BlogEntryModel>.GetItem(d => d.ID.Equals(id));

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }
    }
}