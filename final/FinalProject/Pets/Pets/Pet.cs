namespace VirtualPetProject
{
    public abstract class Pet
    {
        public string Name { get; private set; }
        protected int hunger;
        protected int mood;
        protected int health;
        protected HungerSystem hungerSystem;
        protected MoodSystem moodSystem;
        public Pet(string name)
        {
            Name = name;
            hunger = 100;
            mood = 100;
            health = 100;
            hungerSystem = new HungerSystem();
            moodSystem = new MoodSystem();
        }
        public int Hunger => hunger;
        public int Mood => mood;
        public int Health => health;
        public void SetHunger(int value)
        {
            hunger = value;
        }
        public void SetMood(int value)
        {
            mood = value;
        }
        public void SetHealth(int value)
        {
            health = value;
        }
        public virtual void FeedFood(Food food)
        {
            hungerSystem.ApplyFood(food.HungerChange, ref hunger);
            moodSystem.ApplyFoodMood(food.MoodChange, ref mood);
        }
        public virtual void PlayWithToy(Toy toy)
        {
            moodSystem.IncreaseMood(toy.MoodBoost, ref mood);
        }
        public virtual void UpdateState()
        {
            hungerSystem.IncreaseHunger(ref hunger);
            moodSystem.DecreaseMood(ref mood);
        }
        public abstract string Status();
    }
}
