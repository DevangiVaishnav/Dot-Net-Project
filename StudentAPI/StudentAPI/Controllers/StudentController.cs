// Copilot assisted in creating CRUD API
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static List<Student> students = new List<Student>();

    [HttpGet]
    public IActionResult GetAll() => Ok(students);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        return student == null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public IActionResult Add(Student student)
    {
        students.Add(student);
        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student updated)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        student.Name = updated.Name;
        student.Email = updated.Email;
        student.Course = updated.Course;

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        students.Remove(student);
        return Ok();
    }
}