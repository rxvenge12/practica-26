using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnrollmentSystem
{
    public class Course
    {
        public string Name { get; }
        public int Hours { get; }
        public string Lecturer { get; }
        public int MaxCapacity { get; }
        public int CurrentEnrollment { get; private set; }

        public Course(string name, int hours, string lecturer, int maxCapacity)
        {
            Name = name;
            Hours = hours;
            Lecturer = lecturer;
            MaxCapacity = maxCapacity;
            CurrentEnrollment = 0;
        }

        public bool EnrollStudent()
        {
            if (CurrentEnrollment < MaxCapacity)
            {
                CurrentEnrollment++;
                return true;
            }
            return false;
        }

        public void CancelEnrollment()
        {
            if (CurrentEnrollment > 0)
            {
                CurrentEnrollment--;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

