using IMyWindowsFormsApp.Data.DB;
using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly IDbContext _dbContext;
        public StudentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Student model)
        {
            _dbContext.Students.Add(model);
        }

        public Student Get(Guid id)
        {
            return _dbContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public Address GetAddress(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            return _dbContext.Students;
        }

        public List<Student> GetAllByTeacher(Guid id)
        {           
            return _dbContext.Students.Where(x => x.TeacherId == id).ToList();
        }
        public int IndexOf(Student model)
        {
            return _dbContext.Students.IndexOf(model);
        }

        public void Remove(Student model)
        {
            _dbContext.Students.Remove(model);
        }

        public void Update(Student model, int index)
        {
            _dbContext.Students[index] = model;
        }
    }
}
