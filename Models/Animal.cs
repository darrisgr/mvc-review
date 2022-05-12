using Microsoft.AspNetCore.Mvc;

namespace mvc_review.Models
{
    public class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
        public int Id { get; }
        private static int nextId = 1;

        public Animal()
        {
            Id = nextId;
            nextId++;
        }

        public Animal(string name, string species, string description): this()
        {
            Name = name;
            Species = species;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} is a(n) {Species}";
        }
    }
}
