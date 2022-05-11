using mvc_review.Models;
using System.Collections.Generic;

namespace mvc_review.Data
{
    public class AnimalData
    {
        static private Dictionary<int, Animal> Animals = new Dictionary<int, Animal>();
        // GetAll
        public static IEnumerable<Animal> GetAll()
        {
            return Animals.Values;
        }

        // Add
        public static void Add(Animal newAnimal)
        {
            Animals.Add(newAnimal.Id, newAnimal);
        }

        // Remove
        public static void Remove(int id)
        {
            Animals.Remove(id);
        }

        // GetById
        public static Animal GetById(int id)
        {
            return Animals[id];
        }

        // edit animal name
        // public static void ChangeName(int id, string newName)
        // Animals[id].Name = newName;

        // EditName
        public static void ChangeName(int id, string newName)
        {
            Animals[id].Name = newName;
        }
    }
}
