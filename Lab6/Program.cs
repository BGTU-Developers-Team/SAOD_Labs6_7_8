using System;
using System.Xml.Serialization;

namespace Lab6
{
    

    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop("Edeka", null);

            var schweinfurt = "Schweinfurt";
            AddBranch(shop, schweinfurt);
            
            // var berlin = "Berlin";
            // AddBranch(shop, berlin);

            // MoveStall("Beef", shop, schweinfurt, berlin);

            shop.PrintReport();
        }   

        private static void MoveStall(string key, Shop shop, string from, string to)
        {
            // shop.MoveStall(key, from, to);
        }

        private static void AddBranch(Shop shop, string title)
        {
            shop.AddBranch(new Branch(title, shop));
            var branchSchweinfurt = shop.GetBranch("Schweinfurt");

            branchSchweinfurt.AddDepartment(new Department("Meat", branchSchweinfurt));
            var departmentMeat = branchSchweinfurt.GetDepartment("Meat");

            departmentMeat.AddStall(new Stall("Beef", departmentMeat));
            var stallBeef = departmentMeat.GetStall("Beef");

            stallBeef.AddShelf(new Shelf("Sales", stallBeef));
            var salesShelf = stallBeef.GetShelf("Sales");

            salesShelf.AddGood(new Good("Miratorg beef", 40, salesShelf, 400));

            var good = salesShelf.GetGood("Miratorg beef");
            good.SetPrice(1000);
            // good.SetAmount(10);
        }
    }
}