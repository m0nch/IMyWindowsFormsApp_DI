using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Repositories;
using System;
using System.Collections.Generic;

namespace IMyWindowsFormsApp.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Add(Student model)
        {
            _studentRepository.Add(model);
        }

        public Student Get(Guid id)
        {
            return _studentRepository.Get(id);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public List<Student> GetAllByTeacher(Guid id)
        {
            return _studentRepository.GetAllByTeacher(id);
        }
        public void Remove(Student model)
        {
            _studentRepository.Remove(model);
        }

        public int IndexOf(Student model)
        {
            return _studentRepository.IndexOf(model);
        }

        public void Update(Student model)
        {
            var oldStudent = _studentRepository.Get(model.Id);
            var index = _studentRepository.IndexOf(oldStudent);
            _studentRepository.Update(model, index);
        }
    }
}
