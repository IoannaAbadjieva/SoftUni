using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            students = new List<Student>();
            Capacity = capacity;
        }
        public int Capacity { get; set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count >= Capacity)
            {
                return "No seats in the classroom";
            }

            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (student == null)
            {
                return "Student not found";
            }
            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsBySubject = students.FindAll(s => s.Subject == subject);

            if (studentsBySubject.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in studentsBySubject)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().Trim();
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

        }
    }
}
