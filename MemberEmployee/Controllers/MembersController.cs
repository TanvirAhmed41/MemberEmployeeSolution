using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MemberEmployee.Models.Data;
using MemberEmployee.Models.Entities;
using Rotativa;

namespace MemberEmployee.Controllers
{
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); //Interact with database

        // GET: Members
        public ActionResult Index()
        {
            // Ensure the Employee data is included when retrieving Members
            var members = db.Members.Include(m => m.Employee).ToList();
            return View(members);
        }


        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.Members = new SelectList(db.Members, "Id", "Name");
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,DateOfBirth")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,DateOfBirth")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //for filtering 
        public ActionResult FilterBySalary(decimal? minSalary, decimal? maxSalary)
        {
            if (minSalary == null || maxSalary == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var filteredMembers = db.Members
                .Include("Employee") // Ensures Employee is loaded with Member
                .Where(m => m.Employee != null &&
                            m.Employee.Salary >= minSalary &&
                            m.Employee.Salary <= maxSalary)
                .ToList();

            return View("FilterBySalary", filteredMembers); 
        }

        //for printing members details

        public ActionResult PrintDetails()
        {
            var members = db.Members.Include(m => m.Employee).ToList(); // Load related Employee data
            return View(members); // Render the view with the members' data
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
