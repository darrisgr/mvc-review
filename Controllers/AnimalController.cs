using Microsoft.AspNetCore.Mvc;
using mvc_review.Models;
using mvc_review.Data;

namespace mvc_review.Controllers
{
    public class AnimalController : Controller
    {
        [HttpGet("/animals")]
        // GET: "/animal/index"
        public IActionResult Index()
        {
            ViewBag.animals = AnimalData.GetAll();

            return View();
        }

        [HttpGet("/animals/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("animals/add")]
        public IActionResult NewAnimal(Animal newAnimal)
        {
            AnimalData.Add(newAnimal);

            return Redirect("/animals");
        }

        [HttpGet("/animals/delete")]
        public IActionResult Delete()
        {
            ViewBag.animals = AnimalData.GetAll();

            return View();
        }

        [HttpPost("animals/delete")]
        public IActionResult SendHome(int[] animalIds)
        {
            foreach (int animalId in animalIds)
            {
                AnimalData.Remove(animalId);
            }

            return Redirect("/animals");
        }
    }
}
