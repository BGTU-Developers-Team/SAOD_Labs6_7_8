using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    public class Shop : Entity
    {
        private List<Branch> _branches = new List<Branch>();


        public void AddBranch(Branch branch)
        {
            _branches.Add(branch);
        }

        public Branch GetBranch(string key)
        {
            return _branches.Single(b => b.Title == key);
        }

        public void PrintReport()
        {
            Console.WriteLine($"Report of changes in the shop {Title}:");
            foreach (var branch in _branches)
            {
                FindChangesInBranch(branch);
            }
        }

        private static void FindChangesInBranch(Branch branch)
        {
            Console.WriteLine($"Changes in branch {branch.Title}:");
            
            branch.TryNameChange();
            
            foreach (var department in branch.Departments)
            {
                FindChangesInDepartment(department);
            }
        }


        private static void FindChangesInDepartment(Department department)
        {
            Console.WriteLine($"Changes in department {department.Title}:");
            department.TryNameChange();
            foreach (var stall in department.Stalls)
            {
                FindChangesInStall(stall);
            }
        }

        private static void FindChangesInStall(Stall stall)
        {
            Console.WriteLine($"Changes in stall {stall.Title}:");
            stall.TryNameChange();
            foreach (var shelf in stall.Shelfes)
            {
                FindChangesInShelf(shelf);
            }
        }

        private static void FindChangesInShelf(Shelf shelf)
        {
            Console.WriteLine($"Changes in shelf {shelf.Title}:");
            shelf.TryNameChange();
            foreach (var good in shelf.Goods)
            {
                good.TryNameChange();
            }
        }

        public Shop(string title, Entity parent) : base(title, parent)
        {
        }
    }
}