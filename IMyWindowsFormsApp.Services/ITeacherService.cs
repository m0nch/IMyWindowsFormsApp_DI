using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Services
{
    public interface ITeacherService
    {
        void Add(Teacher model);
        void Remove(Teacher model);
        void Update(Teacher model);
        Teacher Get(Guid id);
        List<Teacher> GetAll();
        int IndexOf(Teacher model);
    }
}
