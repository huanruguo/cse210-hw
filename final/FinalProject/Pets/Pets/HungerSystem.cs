namespace VirtualPetProject
{
    public class HungerSystem
    {
        public void ApplyFood(int hungerChange, ref int hunger)
        {
            hunger += hungerChange;
            if (hunger > 100) hunger = 100;
            if (hunger < 0) hunger = 0;
        }
        public void IncreaseHunger(ref int hunger)
        {
            hunger -= 5;
            if (hunger < 0) hunger = 0;
        }
    }
}
