using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Mappers
{
    public static class TeacherMapper
    {
        public static List<TeacherViewModel> MapTeachersToViewModel(this List<Teacher> teachers)
        {
            List<TeacherViewModel> _teachers = new List<TeacherViewModel>(teachers.Count);
            foreach (var teacher in teachers)
            {
                _teachers.Add(new TeacherViewModel
                {
                    Id= teacher.Id,
                    FullName=$"{teacher.FirstName} {teacher.LastName}",
                    Age= teacher.Age
                });
            }
            return _teachers;
        }
    }
}
