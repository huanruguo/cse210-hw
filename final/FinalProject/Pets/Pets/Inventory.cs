using System;
using System.Collections.Generic;

namespace VirtualPetProject
{
    public class Inventory
    {
        private List<Food> foodItems;
        private List<Toy> toyItems;
        public Inventory()
        {
            foodItems = new List<Food>();
            toyItems = new List<Toy>();
        }
        public Inventory(List<Food> foods, List<Toy> toys)
        {
            foodItems = foods == null ? new List<Food>() : foods;
            toyItems = toys == null ? new List<Toy>() : toys;
        }
        public void AddFood(Food food)
        {
            foodItems.Add(food);
        }
        public void RemoveFood(Food food)
        {
            foodItems.Remove(food);
        }
        public List<Food> GetAllFood()
        {
            return foodItems;
        }
        public void AddToy(Toy toy)
        {
            toyItems.Add(toy);
        }
        public void RemoveToy(Toy toy)
        {
            toyItems.Remove(toy);
        }
        public List<Toy> GetAllToys()
        {
            return toyItems;
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            if (foodItems.Count == 0 && toyItems.Count == 0)
            {
                Console.WriteLine("Empty");
                return;
            }
            if (foodItems.Count > 0)
            {
                Console.WriteLine("Food:");
                foreach (var f in foodItems)
                {
                    Console.WriteLine(f.Name + " (Hunger +" + f.HungerChange + ", Mood " + (f.MoodChange >= 0 ? "+" : "") + f.MoodChange + ")");
                }
            }
            if (toyItems.Count > 0)
            {
                Console.WriteLine("Toys:");
                foreach (var t in toyItems)
                {
                    Console.WriteLine(t.Name + " (MoodBoost +" + t.MoodBoost + ", Uses " + t.RemainingUses + ")");
                }
            }
        }
    }
}
