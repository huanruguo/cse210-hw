using System;
using System.Collections.Generic;

namespace VirtualPetProject
{
    public class Shop
    {
        private List<Food> availableFood;
        private List<Toy> availableToys;
        public Shop()
        {
            availableFood = new List<Food>
            {
                new Food("Normal Food", 5, 15, 0),
                new Food("Premium Food", 10, 25, 5)
            };
            availableToys = new List<Toy>
            {
                new Toy("Ball", 10, 15, 3),
                new Toy("Frisbee", 15, 20, 5)
            };
        }
        public void OpenShop(MoneySystem moneySystem, Inventory inventory)
        {
            bool shopping = true;
            while (shopping)
            {
                Console.WriteLine("SHOP MENU");
                Console.WriteLine("1. Food");
                Console.WriteLine("2. Toys");
                Console.WriteLine("3. Exit Shop");
                Console.Write("Choose: ");
                string c = Console.ReadLine().Trim().ToLower();
                if (c == "1")
                {
                    BuyFood(moneySystem, inventory);
                }
                else if (c == "2")
                {
                    BuyToys(moneySystem, inventory);
                }
                else if (c == "3")
                {
                    shopping = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
        void BuyFood(MoneySystem moneySystem, Inventory inventory)
        {
            Console.WriteLine("Available Food:");
            for (int i = 0; i < availableFood.Count; i++)
            {
                var f = availableFood[i];
                Console.WriteLine(i + ". " + f.Name + " (Cost: " + f.Cost + ", Hunger +" + f.HungerChange + ", Mood " + (f.MoodChange >= 0 ? "+" : "") + f.MoodChange + ")");
            }
            Console.WriteLine("Choose an index or type C to cancel.");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "c") return;
            if (int.TryParse(choice, out int idx))
            {
                if (idx >= 0 && idx < availableFood.Count)
                {
                    var selected = availableFood[idx];
                    if (moneySystem.SpendMoney(selected.Cost))
                    {
                        inventory.AddFood(new Food(selected.Name, selected.Cost, selected.HungerChange, selected.MoodChange));
                        Console.WriteLine("Purchased " + selected.Name);
                    }
                    else
                    {
                        Console.WriteLine("Not enough money.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        void BuyToys(MoneySystem moneySystem, Inventory inventory)
        {
            Console.WriteLine("Available Toys:");
            for (int i = 0; i < availableToys.Count; i++)
            {
                var t = availableToys[i];
                Console.WriteLine(i + ". " + t.Name + " (Cost: " + t.Cost + ", MoodBoost +" + t.MoodBoost + ", Uses " + t.RemainingUses + ")");
            }
            Console.WriteLine("Choose an index or type C to cancel.");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "c") return;
            if (int.TryParse(choice, out int idx))
            {
                if (idx >= 0 && idx < availableToys.Count)
                {
                    var selected = availableToys[idx];
                    if (moneySystem.SpendMoney(selected.Cost))
                    {
                        inventory.AddToy(new Toy(selected.Name, selected.Cost, selected.MoodBoost, selected.RemainingUses));
                        Console.WriteLine("Purchased " + selected.Name);
                    }
                    else
                    {
                        Console.WriteLine("Not enough money.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
