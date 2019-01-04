using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Model_DAL.Models;
using MVC_Model_DAL.Filters;

namespace MVC_Model_DAL.Controllers
{
    [Customauth]
    public class StudentController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)//Server Side Validation
            {
                StudentDAL dal = new StudentDAL();
                bool status = dal.Login(model);
                if(status==true)
                {
                    Session["loginid"] = model.LoginID;
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewBag.msg = "Invalid User ID or Password";
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            try
            {
                int loginid = Convert.ToInt32(Session["loginid1"]);//Read
                int x = 10;
                x = x / loginid;
                ViewBag.loginid = loginid;
                return View();
            }
            catch(Exception exp)
            {
                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "MVC App";
                log.WriteEntry("MVC Error :" + exp.Message);
                return View();
            }
        }
        public ActionResult NewStudent()
        {
            StudentDAL dal = new StudentDAL();
            ViewBag.cities = dal.GetCities();
            return View();
        }
        [HttpPost]
        public ActionResult NewStudent(StudentModel model)
        {
            if(ModelState.IsValid)
            {
                model.StudentImageAddress = "/Images/" + Guid.NewGuid() + ".jpg";
                model.StudentImageFile.SaveAs(Server.MapPath(model.StudentImageAddress));
                StudentDAL dal = new StudentDAL();
                int id = dal.AddStudent(model);
                ViewBag.msg = "Student Added : " + id;
                ModelState.Clear();
                ViewBag.cities = dal.GetCities();
                return View();
            }
            else
            {
                StudentDAL dal = new StudentDAL();
                ViewBag.cities = dal.GetCities();
                return View();
            }
        }
        public ActionResult Search()
        {
            List<StudentProjectionModel> list = new List<StudentProjectionModel>();
            return View(list);
        }
        [HttpPost]
        public ActionResult Search(string key)
        {
            StudentDAL dal = new StudentDAL();
            List<StudentProjectionModel> list = dal.Search(key);
            return View(list);
        }
        public ActionResult Find(int id)
        {
            StudentDAL dal = new StudentDAL();
            StudentModel model = dal.Find(id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            StudentDAL dal = new StudentDAL();
            bool status = dal.Delete(id);
            return View();
        }
        public ActionResult Edit(int id)
        {
            StudentDAL dal = new StudentDAL();
            StudentModel model = dal.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModel model)
        {
            StudentDAL dal = new StudentDAL();
            dal.Update(model.StudentID, model.StudentPassword, model.StudentMobileNo);
            return View("View_Updated");
        }
        [ChildActionOnly]
        public ActionResult GetProfileDetails()
        {
            int loginid = Convert.ToInt32(Session["loginid"]);
            StudentDAL dal = new StudentDAL();
            StudentModel model = dal.Find(loginid);
            ViewBag.id = model.StudentID;
            ViewBag.name = model.StudentName;
            ViewBag.imgaddress = model.StudentImageAddress;
            return PartialView("myprofilepartialview");
        }
    }
}