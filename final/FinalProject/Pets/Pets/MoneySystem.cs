namespace VirtualPetProject
{
    public class MoneySystem
    {
        public int CurrentMoney { get; private set; }
        public MoneySystem(int initialMoney)
        {
            CurrentMoney = initialMoney;
        }
        public bool SpendMoney(int amount)
        {
            if (amount <= CurrentMoney)
            {
                CurrentMoney -= amount;
                return true;
            }
            return false;
        }
        public void AddMoney(int amount)
        {
            CurrentMoney += amount;
        }
    }
}
