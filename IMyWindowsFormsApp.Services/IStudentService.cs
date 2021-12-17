using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Services
{
    public interface IStudentService
    {
        void Add(Student model);
        void Remove(Student model);
        void Update(Student model);
        Student Get(Guid id);
        List<Student> GetAll();
        List<Student> GetAllByTeacher(Guid id);
        int IndexOf(Student model);

    }
}
