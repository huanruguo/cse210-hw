using System.Collections.Generic;

namespace VirtualPetProject
{
    public class GameState
    {
        public string PetName { get; set; }
        public int PetHunger { get; set; }
        public int PetMood { get; set; }
        public int PetHealth { get; set; }
        public int Money { get; set; }
        public List<Food> FoodList { get; set; }
        public List<Toy> ToyList { get; set; }
    }
}
