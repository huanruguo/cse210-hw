namespace VirtualPetProject
{
    public class Toy : Item
    {
        public int MoodBoost { get; private set; }
        public int RemainingUses { get; private set; }
        public Toy(string name, int cost, int moodBoost, int initialUses) : base(name, cost)
        {
            MoodBoost = moodBoost;
            RemainingUses = initialUses;
        }
        public void UseOnce()
        {
            RemainingUses--;
        }
    }
}
