using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tinyCRM.Models;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace tinyCRM.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Task
        public async Task<ActionResult> Index()
        {
            string currentUser = User.Identity.GetUserName();
            string currentId = User.Identity.GetUserId();
            var ww = User.Identity;
            
            if (currentUser != "admin")
            {
                var item = await db.TaskItems.Where(t => t.UserId == currentId).ToListAsync();
                //var dto= Mapper.Map<TaskItemDto>(item);
                return View(item);
            }
            return View(await db.TaskItems.ToListAsync());
        }

        // GET: Task/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string currentUser = User.Identity.GetUserName();
            string currentId = User.Identity.GetUserId();
            TaskItem taskItem = await db.TaskItems.SingleOrDefaultAsync(t=>t.UserId==currentId && t.Id ==id);
            if (taskItem == null)
            {
                return HttpNotFound();
            }
            return View(taskItem);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,StartDate,DeadLine,Progress")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                taskItem.UserId = User.Identity.GetUserId();
                db.TaskItems.Add(taskItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(taskItem);
        }

        // GET: Task/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string currentUser = User.Identity.GetUserId();
            TaskItem taskItem = await db.TaskItems.SingleOrDefaultAsync(t => t.UserId == currentUser && t.Id == id);
            if (taskItem == null)
            {
                return HttpNotFound();
            }
            return View(taskItem);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,StartDate,DeadLine,Progress")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taskItem);
        }

        // GET: Task/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string currentUser = User.Identity.GetUserId();
            TaskItem taskItem = await db.TaskItems.SingleOrDefaultAsync(t => t.UserId == currentUser && t.Id == id);
            if (taskItem == null)
            {
                return HttpNotFound();
            }
            return View(taskItem);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            string currentUser = User.Identity.GetUserId();
            TaskItem taskItem = await db.TaskItems.SingleOrDefaultAsync(t => t.UserId == currentUser && t.Id == id);
            db.TaskItems.Remove(taskItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
