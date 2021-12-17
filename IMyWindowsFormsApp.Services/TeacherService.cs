using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Repositories;
using System;
using System.Collections.Generic;

namespace IMyWindowsFormsApp.Services
{
    internal class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public void Add(Teacher model)
        {
            _teacherRepository.Add(model);
        }
        public Teacher Get(Guid id)
        {
            return _teacherRepository.Get(id);
        }
        public List<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }
        public void Remove(Teacher model)
        {
            _teacherRepository.Remove(model);
        }
        public int IndexOf(Teacher model)
        {
            return _teacherRepository.IndexOf(model);
        }
        public void Update(Teacher model) 
        {
            var oldTeacher = _teacherRepository.Get(model.Id);
            var index = _teacherRepository.IndexOf(oldTeacher);
            _teacherRepository.Update(model, index);
        }
    }
}
