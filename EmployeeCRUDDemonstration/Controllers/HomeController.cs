using EmployeeCRUDDemonstration.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCRUDDemonstration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeRepository repo = new EmployeeRepository();

            var list = repo.GetAllEmployees();

            return View(list);
        }

        public async Task<ActionResult> Index2()
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "select count(*) from EmpInfo";
            SqlCommand cmd = new SqlCommand(query, conn);

            await conn.OpenAsync();

            int noOfUser = (int)await cmd.ExecuteScalarAsync();

            conn.Close();

            ViewBag.NoOfEmployees = noOfUser;

            return View();
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository repo = new EmployeeRepository();

                bool isCreated = false;

                string errorMessageIfAny = "";
                try
                {
                    isCreated = repo.Create(emp);
                }
                catch (Exception ex)
                {
                    errorMessageIfAny = ex.Message;
                }

                if (isCreated)
                {
                    TempData["ResultMessage"] = "New Employee is Created Successfully";

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("InsertFailed", "New Employee Insertion is failed, " + errorMessageIfAny);
                }
            }

            return View();
        }

        public ActionResult DeleteEmployee(int Id)
        {
            EmployeeRepository repo = new EmployeeRepository();

            bool isDeleted = repo.Delete(Id);

            if (isDeleted)
            {
                TempData["ResultMessage"] = "Record is Deleted Successfully";

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EditEmployee(int Id)
        {
            EmployeeRepository repo = new EmployeeRepository();

            var emp = repo.GetEmployeeById(Id);

            return View(emp);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository repo = new EmployeeRepository();

                bool isUpdated = repo.Update(emp);

                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("UpdateFailed", "Update Failed");
                }
            }

            return View();
        }
    }
}