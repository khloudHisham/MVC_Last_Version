using lab2MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace lab2MVC.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ITIContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public InstructorController(ITIContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<instructor> InstructorListModel = context.instructor.ToList();
            return View("Index", InstructorListModel);
        }

        public IActionResult New()
        {
            var departments = context.Department.ToList();
            ViewBag.Departments = departments;

            var courses = context.Course.ToList();
            ViewBag.Courses = courses;

            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(instructor inst, IFormFile imageFile)
        {
            if (inst.Name != null && imageFile != null && imageFile.Length > 0)
            {
                // Generate a unique filename for the uploaded image
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);

                // Define the path where you want to save the uploaded image
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

                // Ensure the folder exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Combine the uploads folder path with the unique filename to get the full file path
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Copy the uploaded image to the specified location
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

                // Set the ImageUrl property to the path where the image is saved
                inst.ImageURl = uniqueFileName;

                // Save the instructor to the database
                context.Add(inst);
                context.SaveChanges();

                // Redirect to the index action
                return RedirectToAction("Index");
            }

            // If the name or image file is not provided, return to the "New" view
            return View();
        }


        public IActionResult ShowAll(int id)
        {
            var instructor = context.instructor.FirstOrDefault(i => i.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View("ShowDetails", instructor);
        }
    }
}
