using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    public class Shelf : Entity
    {
        public List<Good> Goods = new List<Good>();

        public void AddGood(Good good)
        {
            Goods.Add(good);
        }

        public Shelf(string title, Entity parent) : base(title, parent)
        {
        }

        public Good GetGood(string title)
        {
            return Goods.Single(g => g.Title == title);
        }
    }
}