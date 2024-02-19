using System;
using System.Text;
using System.Collections.Generic;


namespace ClassroomProject
{
    public class Student
    {

        public Student(string firstName, string lastName, string subject)
        {
            this.firstName = firstName;

            this.lastName = lastName;

            this.subject = subject;
        }
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }


        public override string ToString()
        {
            return $"Student: First Name = {firstName}, Last Name = {lastName}, Subject = {subject}";
        }
    }
}
