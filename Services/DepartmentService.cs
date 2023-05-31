
using StudentDeptWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentDeptWebAPI.Services
{
    public class DepartmentService
    {
        private readonly StudentDeptContext _context;
        public DepartmentService(StudentDeptContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            departments = _context.Departments.ToList();
            return departments;
        }

        public Department GetDepartmentByID(int departmentId)
        {
            Department department = new Department();
            department = _context.Departments.FirstOrDefault(s => s.DepartmentID == departmentId);
            return department;
        }

        public Department AddDepartment(Department department)
        {
            Department newDepartment = new Department();
            newDepartment.DepartmentName = department.DepartmentName;
            _context.Departments.Add(newDepartment);
            _context.SaveChanges();
            return newDepartment;
        }

        public Department EditDepartment(Department department)
        {
            Department editedDepartment = _context.Departments.FirstOrDefault(s => s.DepartmentID == department.DepartmentID);
            editedDepartment.DepartmentName = department.DepartmentName;
            _context.Departments.Update(editedDepartment);
            _context.SaveChanges();
            return editedDepartment;
        }

        public Department RemoveDepartment(int departmentId)
        {
            Department Department = _context.Departments.FirstOrDefault(s => s.DepartmentID == departmentId);
            _context.Departments.Remove(Department);
            _context.SaveChanges();
            return Department;
        }
    }
}
