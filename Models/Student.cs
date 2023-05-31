using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDeptWebAPI.Models
{
    public class Student
    {
		[Key]
		public int StudentID { get; set; }
		public string StudentName { get; set; }
		public string Course { get; set; }
		public string Specialization { get; set; }
		public double Percentage { get; set; }		
		public int DepartmentID { get; set; }

		[ForeignKey("DepartmentID")]
		public Department Department { get; set; }

	}
}
