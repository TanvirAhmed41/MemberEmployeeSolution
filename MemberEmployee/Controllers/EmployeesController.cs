using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MemberEmployee.Models.Data;
using MemberEmployee.Models.Entities;

namespace MemberEmployee.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Employees
      public ActionResult Index()
{
            // Include related Member data if needed
            var employees = db.Employees.Include(e => e.Member).ToList();
            return View(employees);
}


        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Member member = db.Members.Include("Employee").FirstOrDefault(m => m.MemberId == id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }


        // GET: Employees/Create
        public ActionResult Create()
        {
            // Retrieve data from the Members table
            ViewBag.Members = db.Members.ToList(); 
            return View();
        }



        // POST: Employees/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Attach the Member entity to the context
                var member = db.Members.Find(employee.MemberId);
                if (member == null)
                {
                    ModelState.AddModelError("", "The selected Member does not exist.");
                    ViewBag.Members = db.Members.ToList();
                    return View(employee);
                }

                employee.Member = member; // Associate Member with Employee
                db.Employees.Add(employee);
                db.SaveChanges(); // Should work without errors now
                return RedirectToAction("Index");
            }

            ViewBag.Members = db.Members.ToList();
            return View(employee);
        }



        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
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
