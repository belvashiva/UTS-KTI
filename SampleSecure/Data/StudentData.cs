using System;
using System.Collections.Generic;
using System.Linq;
using SampleSecure.Models;

namespace SampleSecure.Data
{
    public class StudentData : IStudent
    {
        private readonly ApplicationDbContext _db;

        public StudentData(ApplicationDbContext db)
        {
            _db = db;
        }

        public Student AddStudent(Student student)
        {
            try
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return student;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStudent(string kode)
        {
            var student = _db.Students.FirstOrDefault(s => s.Kode == kode);
            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
            }
        }

        public Student GetStudent(string kode)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _db.Students.FirstOrDefault(s => s.Kode == kode);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IEnumerable<Student> GetStudents()
        {
            return _db.Students.OrderBy(s => s.NamaBarang).ToList(); // Gunakan ToList() untuk memastikan tidak null
        }

        public Student UpdateStudent(Student student)
{
    var existingStudent = _db.Students.FirstOrDefault(s => s.Kode == student.Kode);
    if (existingStudent != null)
    {
        existingStudent.NamaBarang = student.NamaBarang; // Update properti yang ingin diubah
        _db.SaveChanges();
    }
#pragma warning disable CS8603 // Possible null reference return.
            return existingStudent;
#pragma warning restore CS8603 // Possible null reference return.
        }


        public Student UpdateStudent(string kode)
        {
            throw new NotImplementedException();
        }

        void IStudent.UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
