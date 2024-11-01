using System;
using System.ComponentModel.DataAnnotations;

namespace SampleSecure.Models;

public class Student
{
    [Key]
    public string Kode {get; set;} = null!;
    public string NamaBarang {get; set;} = null!;
}