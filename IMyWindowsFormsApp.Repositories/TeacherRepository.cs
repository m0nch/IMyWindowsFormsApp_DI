using IMyWindowsFormsApp.Data.DB;
using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    internal class TeacherRepository : ITeacherRepository
    {
        private readonly IDbContext _dbContext;
        public TeacherRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Teacher model)
        {
            _dbContext.Teachers.Add(model);
        }
        public Teacher Get(Guid id)
        {
            return _dbContext.Teachers.FirstOrDefault(x => x.Id == id);
        }
        public List<Teacher> GetAll()
        {
            return _dbContext.Teachers;
        }
        public int IndexOf(Teacher model)
        {
            return _dbContext.Teachers.IndexOf(model);
        }
        public void Remove(Teacher model)
        {
            _dbContext.Teachers.Remove(model);
        }
        public void Update(Teacher model, int index)
        {
            _dbContext.Teachers[index] = model;
        }
    }
}
