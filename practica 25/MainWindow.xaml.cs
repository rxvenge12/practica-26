using System;
using System.Collections.Generic;
using System.Windows;

namespace practica_25
{
    public partial class MainWindow : Window
    {
        // Класс, представляющий дисциплину
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

        private List<Course> courses;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCourses();
            UpdateCourseListBox();
        }

        // Инициализация списка курсов
        private void InitializeCourses()
        {
            courses = new List<Course>
            {
                new Course("Основы программирования", 40, "John Smith", 20),
                new Course("Структуры данных", 60, "Emily Johnson", 15),
                new Course("Проектирование алгоритмов", 50, "Michael Brown", 25)
                // Добавьте сюда остальные курсы
            };
        }

        // Обновление ListBox с курсами
        private void UpdateCourseListBox()
        {
            courseListBox.ItemsSource = null;
            courseListBox.ItemsSource = courses;
        }

        // Обработчик изменения выбранного курса в ListBox
        private void CourseListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (courseListBox.SelectedItem != null)
            {
                Course selectedCourse = (Course)courseListBox.SelectedItem;
                courseDetailsTextBox.Text = $"Name: {selectedCourse.Name}\n" +
                                            $"Hours: {selectedCourse.Hours}\n" +
                                            $"Lecturer: {selectedCourse.Lecturer}\n" +
                                            $"Current Enrollment: {selectedCourse.CurrentEnrollment}\n" +
                                            $"Max Capacity: {selectedCourse.MaxCapacity}";
            }
        }

        // Обработчик нажатия на кнопку "Enroll"
        private void EnrollButton_Click(object sender, RoutedEventArgs e)
        {
            if (courseListBox.SelectedItem != null)
            {
                Course selectedCourse = (Course)courseListBox.SelectedItem;
                if (selectedCourse.EnrollStudent())
                {
                    MessageBox.Show("Enrollment successful!");
                    UpdateCourseListBox();
                }
                else
                {
                    MessageBox.Show("Enrollment failed. The course is full.");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to enroll.");
            }
        }

        // Обработчик нажатия на кнопку "Cancel Enrollment"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (courseListBox.SelectedItem != null)
            {
                Course selectedCourse = (Course)courseListBox.SelectedItem;
                selectedCourse.CancelEnrollment();
                MessageBox.Show("Enrollment canceled.");
                UpdateCourseListBox();
            }
            else
            {
                MessageBox.Show("Please select a course to cancel enrollment.");
            }
        }
    }
}
