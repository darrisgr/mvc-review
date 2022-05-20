using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mvc_review.Models;
using mvc_review.Data;
using mvc_review.ViewModels;

namespace mvc_review.Controllers
{
    public class AnimalController : Controller
    {
        [HttpGet("/animals")]
        // GET: "/animal/index"
        public IActionResult Index()
        {
            List<Animal> animals = new List<Animal>(AnimalData.GetAll());

            return View(animals);
        }

        public IActionResult Add()
        {
            AddAnimalViewModel addAnimalViewModel = new AddAnimalViewModel();
            return View(addAnimalViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddAnimalViewModel addAnimalViewModel)
        {
           if (ModelState.IsValid)
            {
                Animal newAnimal = new Animal
                {
                    Name = addAnimalViewModel.Name,
                    Species = addAnimalViewModel.Species,
                    Description = addAnimalViewModel.Description
                };

                AnimalData.Add(newAnimal);

                return Redirect("/animals");
            }

            return View(addAnimalViewModel);
        }
        
        public IActionResult Delete()
        {
            ViewBag.animals = AnimalData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] animalIds)
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

    internal class AddEventViewModel
    {
    }
}
