﻿using USOS.Entities;
using System.Net;
using System.Security.Cryptography;
using USOS.Enums;

namespace USOS
{
    public class UsosSeeder
    {
        private readonly UsosDbContext _context;
        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Students.Any())
                {
                    var students = GetStudents();
                    _context.Students.AddRange(students);
                    _context.SaveChanges();
                }
            }
        }
        public UsosSeeder(UsosDbContext context)
        {
            _context = context;
        }
        private IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    Name = "Tomek",
                    Surname = "Jogurciarz",
                    Age = 22,
                    Index = 123456,
                    MajorSubject = Major.IT,
                },
                new Student()
                {
                    Name = "Dawid",
                    Surname = "Garnuch",
                    Age = 21,
                    Index = 543456,
                    MajorSubject = Major.IT,
                },
            };
            return students;
        }
    }
}