using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    public class Stall : Entity
    {
        public List<Shelf> Shelfes = new List<Shelf>();


        public void AddShelf(Shelf shelf)
        {
            Shelfes.Add(shelf);
        }

        public Shelf GetShelf(string key)
        {
            return Shelfes.Single(s => s.Title == key);
        }

        public Stall(string title, Entity parent) : base(title, parent)
        {
        }
    }
}