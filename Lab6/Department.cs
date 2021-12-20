using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    public class Department : Entity
    {
        // private Branch _branch;
        public List<Stall> Stalls = new List<Stall>();

        public void AddStall(Stall stall)
        {
            Stalls.Add(stall);
        }

        public Stall GetStall(string key)
        {
            return Stalls.Single(s => s.Title == key);
        }

        public Department(string title, Entity parent) : base(title, parent)
        {
        }
    }
}