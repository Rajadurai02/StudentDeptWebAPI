using StudentDeptWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDeptWebAPI.Services
{
    public class StudentService
    {
        private readonly StudentDeptContext _context;
        public StudentService(StudentDeptContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            students = _context.Students.ToList();
            return students;
        }

        public Student GetStudentByID(int studentId)
        {
            Student student = new Student();
            student = _context.Students.FirstOrDefault(s => s.StudentID == studentId);
            return student;
        }

        public Student AddStudent(Student student)
        {
            Student newStudent = new Student();
            newStudent.StudentName = student.StudentName;
            newStudent.Course = student.Course;
            newStudent.Specialization = student.Specialization;
            newStudent.Percentage = student.Percentage;
            newStudent.DepartmentID = student.DepartmentID;
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return newStudent;
        }

        public Student EditStudent(Student student)
        {
            Student editedStudent = _context.Students.FirstOrDefault(s=>s.StudentID == student.StudentID);
            editedStudent.StudentName = student.StudentName;
            editedStudent.Course = student.Course;
            editedStudent.Specialization = student.Specialization;
            editedStudent.Percentage = student.Percentage;
            editedStudent.DepartmentID = student.DepartmentID;
            _context.Students.Update(editedStudent);
            _context.SaveChanges();
            return editedStudent;
        }

        public Student RemoveStudent(int studentId)
        {
            Student student = _context.Students.FirstOrDefault(s => s.StudentID == studentId);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return student;
        }
    }
}
