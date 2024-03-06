using lab2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // Add this if it's not already included

namespace lab2MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ITIContext db;

        public CourseController(ITIContext context)
        {
            db = context;
        }

        // GET: Course/ShowCourses
        public IActionResult ShowCourses()
        {

            var courses = db.Course.Include(c => c.Department).ToList();

            return View(courses);
        }
        public IActionResult AddCourse()
        {
            ViewBag.Departments = db.Department.ToList();
            return View();
        }


        //[HttpPost]
        //public IActionResult SaveNew(Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Course.Add(course);
        //        db.SaveChanges();
        //        return RedirectToAction("ShowCourses"); // Redirect to the list of courses after adding the new course
        //    }
        //    // If model state is not valid, redisplay the form with validation errors
        //    return View("AddCourse", course);
        //}
        [HttpPost]
        // POST: Course/SaveNew
        [HttpPost]
        public IActionResult SaveNew(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Course.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("ShowCourses"); // Redirect to the list of courses after adding the new course
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error occurred while saving the course: " + ex.Message);
                }
            }

            // If model state is not valid or an error occurred, redisplay the form with validation errors
            ViewBag.Departments = db.Department.ToList();
            return View("AddCourse", course);
        }




    }


}

