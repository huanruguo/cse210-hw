namespace VirtualPetProject
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public int Cost { get; protected set; }
        public Item(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
