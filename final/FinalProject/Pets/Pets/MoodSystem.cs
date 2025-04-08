namespace VirtualPetProject
{
    public class MoodSystem
    {
        public void ApplyFoodMood(int moodChange, ref int mood)
        {
            mood += moodChange;
            if (mood > 100) mood = 100;
            if (mood < 0) mood = 0;
        }
        public void IncreaseMood(int amount, ref int mood)
        {
            mood += amount;
            if (mood > 100) mood = 100;
        }
        public void DecreaseMood(ref int mood)
        {
            mood -= 3;
            if (mood < 0) mood = 0;
        }
    }
}
