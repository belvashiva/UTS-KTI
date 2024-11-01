using Microsoft.AspNetCore.Mvc;
using SampleSecure.Data;
using SampleSecure.Models;
using System.Linq;

namespace SampleSecure.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _studentData;

        public StudentController(IStudent studentData)
        {
            _studentData = studentData;
        }

        // Menampilkan daftar mahasiswa
        public IActionResult Index()
        {
            var students = _studentData.GetStudents();
            return View(students);
        }

        // Menampilkan halaman form untuk menambahkan mahasiswa baru
        public IActionResult Create()
        {
            return View();
        }

        // Memproses penambahan mahasiswa baru
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentData.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Menampilkan form untuk mengedit data mahasiswa berdasarkan NIM
        public IActionResult Edit(string kode)
        {
            var student = _studentData.GetStudents().FirstOrDefault(s => s.Kode == kode);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Memproses pengeditan data mahasiswa
[HttpPost]
public IActionResult Edit(Student student)
{
    if (ModelState.IsValid) // Memastikan model valid
    {
        try
        {
            // Memanggil metode untuk memperbarui data mahasiswa
            _studentData.UpdateStudent(student);
            // Jika berhasil, arahkan ke halaman index (daftar mahasiswa)
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message); // Menangkap error jika ada
        }
    }
    else
    {
        // Jika model tidak valid, ambil semua error dan log
        var errors = ModelState.Values.SelectMany(v => v.Errors);
        foreach (var error in errors)
        {
            // Anda bisa log error ke konsol atau ke logger Anda
            Console.WriteLine(error.ErrorMessage);
        }
    }

    // Jika model tidak valid, tetap di halaman edit
    return View(student);
}



        // Menampilkan halaman konfirmasi penghapusan mahasiswa berdasarkan NIM
        public IActionResult Delete(string kode)
        {
            var student = _studentData.GetStudents().FirstOrDefault(s => s.Kode == kode);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // Memproses penghapusan mahasiswa
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string kode)
        {
            _studentData.DeleteStudent(kode);
            return RedirectToAction("Index");
        }
    }
}
