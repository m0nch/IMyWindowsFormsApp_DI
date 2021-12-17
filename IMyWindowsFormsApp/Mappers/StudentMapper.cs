using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Mappers
{
    public static class StudentMapper
    {
        public static List<StudentViewModel> MapStudentsToViewModel(this List<Student> students)
        {
            List<StudentViewModel> _students = new List<StudentViewModel>(students.Count);
            foreach (var student in students)
            {
                _students.Add(new StudentViewModel
                {
                    Id=student.Id,
                    FullName=$"{student.FirstName} {student.LastName}",
                    Age=student.Age,
                    TeacherId = student.TeacherId
                });
            }
            return _students;
        }
    }
}
