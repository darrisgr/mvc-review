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

        // GET: "/animals/edit/{id}"
        [HttpGet("/animals/{id}/editname")]
        public IActionResult EditName(int id)
        {
            ViewBag.selectedAnimal = AnimalData.GetById(id);

            ViewBag.name = $"{AnimalData.GetById(id).Name}'s";

            return View();
        }

        [HttpPost("animals/{id}/editname")]
        public IActionResult NewName(int id, string name)
        {
            AnimalData.ChangeName(id, name);

            return Redirect("/animals");
        }

        [HttpGet("/animals/{id}/editdescription")]
        public IActionResult EditDescription(int id)
        {
            ViewBag.selectedAnimal = AnimalData.GetById(id);

            ViewBag.description = $"{AnimalData.GetById(id).Description}'s";

            return View();
        }

        [HttpPost("animals/{id}/editdescription")]
        public IActionResult NewDescription(int id, string description)
        {
            AnimalData.ChangeDescription(id, description);

            return Redirect("/animals");
        }
    }
}
