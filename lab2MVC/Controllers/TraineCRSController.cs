using lab2MVC.Models;
using lab2MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System;

namespace lab2MVC.Controllers
{
    public class TraineCRSController : Controller
    {
        private readonly ITIContext context;

        public TraineCRSController(ITIContext context)
        {
            this.context = context;
        }

        public IActionResult TraineeCourseAndGradWithVM(int id, int CrsId)
        {
            var Trainee = context.Trainee.FirstOrDefault(t => t.Id == id);
            var course = context.Course.FirstOrDefault(c => c.Id == CrsId);

            if (Trainee == null || course == null)
            {
                return NotFound();
            }
            Course crs = new Course();
            Trainee tr = new Trainee();
            crsResult crRes = context.crsResult.FirstOrDefault(n => n.TraineeId == id);

            var vm = new TraineCourseDegreeViewModel();

            vm.TraineeId = Trainee.Id;
            vm.TraineeName = Trainee.Name;
            vm.CourseName = course.Name;
            vm.CourseDegree = course.Degree;
            vm.Degree = crRes.degree;
            if (vm.Degree < course.MinDegree)
            {
                vm.color = "red";
            }
            else
            {
                vm.color = "green";
            }

            return View("TraineeCourseAndGradWithVM", vm);
        }

    }
}
