using System;
using System.IO;

namespace VirtualPetProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState state;
            if (File.Exists("save.json"))
            {
                Console.WriteLine("A previous save was found. Type Y to load or N to start a new game.");
                string choice = Console.ReadLine().Trim().ToLower();
                if (choice == "y")
                {
                    state = SaveManager.LoadGame();
                    if (state == null) state = CreateNewGame();
                }
                else
                {
                    state = CreateNewGame();
                }
            }
            else
            {
                state = CreateNewGame();
            }
            Pet myPet = new Dog(state.PetName);
            myPet.SetHunger(state.PetHunger);
            myPet.SetMood(state.PetMood);
            myPet.SetHealth(state.PetHealth);
            MoneySystem moneySystem = new MoneySystem(state.Money);
            Inventory inventory = new Inventory(state.FoodList, state.ToyList);
            TimeManager timeManager = new TimeManager();
            Shop shop = new Shop();
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("----- MENU -----");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Typing Game");
                Console.WriteLine("4. Shop");
                Console.WriteLine("5. Inventory");
                Console.WriteLine("6. Status");
                Console.WriteLine("7. Save & Exit");
                Console.Write("Choose: ");
                string input = Console.ReadLine().Trim().ToLower();
                Console.WriteLine();
                if (input == "1" || input == "feed")
                {
                    ActionFeed(myPet, inventory);
                }
                else if (input == "2" || input == "play")
                {
                    ActionPlay(myPet, inventory);
                }
                else if (input == "3" || input == "typing")
                {
                    ActionTyping(moneySystem);
                }
                else if (input == "4" || input == "shop")
                {
                    shop.OpenShop(moneySystem, inventory);
                }
                else if (input == "5" || input == "inventory")
                {
                    inventory.DisplayInventory();
                }
                else if (input == "6" || input == "status")
                {
                    Console.WriteLine(myPet.Status());
                    Console.WriteLine("Money: " + moneySystem.CurrentMoney);
                }
                else if (input == "7" || input == "save" || input == "exit")
                {
                    state.PetName = myPet.Name;
                    state.PetHunger = myPet.Hunger;
                    state.PetMood = myPet.Mood;
                    state.PetHealth = myPet.Health;
                    state.Money = moneySystem.CurrentMoney;
                    state.FoodList = inventory.GetAllFood();
                    state.ToyList = inventory.GetAllToys();
                    SaveManager.SaveGame(state);
                    running = false;
                    Console.WriteLine("Game saved. Goodbye.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
                timeManager.UpdateTime(myPet);
            }
        }
        static GameState CreateNewGame()
        {
            Console.WriteLine("Starting a new game.");
            Console.Write("Name your pet: ");
            string petName = Console.ReadLine();
            return new GameState { PetName = petName, PetHunger = 100, PetMood = 100, PetHealth = 100, Money = 50 };
        }
        static void ActionFeed(Pet pet, Inventory inventory)
        {
            var foodList = inventory.GetAllFood();
            if (foodList.Count == 0)
            {
                Console.WriteLine("You have no purchased food. Type F for Free Food or C to cancel.");
                string c = Console.ReadLine().Trim().ToLower();
                if (c == "f")
                {
                    Food freeFood = new Food("Free Food", 0, 5, -5);
                    pet.FeedFood(freeFood);
                }
                else
                {
                    Console.WriteLine("Feed cancelled.");
                }
                return;
            }
            Console.WriteLine("Food in your inventory:");
            for (int i = 0; i < foodList.Count; i++)
            {
                Console.WriteLine(i + ". " + foodList[i].Name + " (Hunger +" + foodList[i].HungerChange + ", Mood " + (foodList[i].MoodChange >= 0 ? "+" : "") + foodList[i].MoodChange + ")");
            }
            Console.WriteLine("Type an index to feed, F for Free Food, or C to cancel.");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "c")
            {
                Console.WriteLine("Feed cancelled.");
            }
            else if (choice == "f")
            {
                Food freeFood = new Food("Free Food", 0, 5, -5);
                pet.FeedFood(freeFood);
            }
            else
            {
                if (int.TryParse(choice, out int idx))
                {
                    if (idx >= 0 && idx < foodList.Count)
                    {
                        Food selected = foodList[idx];
                        pet.FeedFood(selected);
                        inventory.RemoveFood(selected);
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
        static void ActionPlay(Pet pet, Inventory inventory)
        {
            var toyList = inventory.GetAllToys();
            if (toyList.Count == 0)
            {
                Console.WriteLine("You have no toys.");
                return;
            }
            Console.WriteLine("Toys in your inventory:");
            for (int i = 0; i < toyList.Count; i++)
            {
                Console.WriteLine(i + ". " + toyList[i].Name + " (MoodBoost +" + toyList[i].MoodBoost + ", Uses " + toyList[i].RemainingUses + ")");
            }
            Console.WriteLine("Choose an index or type C to cancel.");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "c")
            {
                Console.WriteLine("Play cancelled.");
            }
            else
            {
                if (int.TryParse(choice, out int idx))
                {
                    if (idx >= 0 && idx < toyList.Count)
                    {
                        Toy selected = toyList[idx];
                        pet.PlayWithToy(selected);
                        selected.UseOnce();
                        if (selected.RemainingUses <= 0)
                        {
                            Console.WriteLine(selected.Name + " broke and was removed.");
                            inventory.RemoveToy(selected);
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
        static void ActionTyping(MoneySystem moneySystem)
        {
            string[] words = { "apple", "virtual", "pet", "tamagotchi", "hunger", "mood", "csharp", "game" };
            var r = new Random();
            string target = words[r.Next(words.Length)];
            Console.WriteLine("Type this word exactly: " + target);
            string input = Console.ReadLine();
            if (input == target)
            {
                moneySystem.AddMoney(10);
                Console.WriteLine("Correct. You earned 10 money.");
            }
            else
            {
                Console.WriteLine("Incorrect. No reward.");
            }
        }
    }
}
