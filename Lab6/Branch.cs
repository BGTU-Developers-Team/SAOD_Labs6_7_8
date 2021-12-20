using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    public class Branch : Entity
    {
        // private Shop _shop;
        public List<Department> Departments = new List<Department>();

        public Branch(string title, Entity parent) : base(title, parent)
        {
        }
        
        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public Department GetDepartment(string key)
        {
            return Departments.Single(d => d.Title == key);
        }

        
    }
}