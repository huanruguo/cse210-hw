namespace VirtualPetProject
{
    public class Dog : Pet
    {
        public Dog(string name) : base(name) {}
        public override void FeedFood(Food food)
        {
            base.FeedFood(food);
            moodSystem.IncreaseMood(2, ref mood);
        }
        public override string Status()
        {
            return "Name: " + Name + " | Health: " + Health + " | Hunger: " + Hunger + " | Mood: " + Mood;
        }
    }
}
