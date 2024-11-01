using System;
using SampleSecure.Models;

namespace SampleSecure.Data;

public interface IStudent
{
    IEnumerable<Student> GetStudents();
    Student GetStudent(string kode);
    Student AddStudent(Student student);
    Student UpdateStudent(string kode);
    void DeleteStudent(string kode);
    void UpdateStudent(Student student);
}
