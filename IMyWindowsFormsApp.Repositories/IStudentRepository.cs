using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student model);
        void Remove(Student model);
        Student Get(Guid id);
        void Update(Student model, int index);
        List<Student> GetAll();
        List<Student> GetAllByTeacher(Guid id);
        int IndexOf(Student model);
    }
}
