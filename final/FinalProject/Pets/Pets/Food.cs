namespace VirtualPetProject
{
    public class Food : Item
    {
        public int HungerChange { get; private set; }
        public int MoodChange { get; private set; }
        public Food(string name, int cost, int hungerChange, int moodChange) : base(name, cost)
        {
            HungerChange = hungerChange;
            MoodChange = moodChange;
        }
    }
}
