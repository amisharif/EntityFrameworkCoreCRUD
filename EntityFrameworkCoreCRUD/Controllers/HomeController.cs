using EntityFrameworkCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntityFrameworkCoreCRUD.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly StudentDbContext _context;
        public HomeController(StudentDbContext context)
        {
            _context = context;
        }

        [Route("/")]
        [Route("[action]")]
        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);   
        }



        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Student std)
        {
            _context.Students.Add(std);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        [Route("[action]/{ID}")]
        public IActionResult Edit(int ID)
        {
            Student student = _context.Students.Find(ID);
           // Student student = _context.Students.FirstOrDefault(std => std.ID == ID);
            return View(student);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit(Student std)
        {
            _context.Students.Update(std);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Delete(int ID)
        {
            Student std = _context.Students.Find(ID);
            _context.Students.Remove(std);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }






    }
}
