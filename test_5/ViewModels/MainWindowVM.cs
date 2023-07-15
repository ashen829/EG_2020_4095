using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using test_5.Models;
using test_5.Views;

namespace test_5.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;



        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();

            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/U1.png", UriKind.Relative));
            students.Add(new Student(23, "Ashen", "Nethsara", "29/08/1999", image1));

            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/U3.png", UriKind.Relative));
            students.Add(new Student(18, "Malindu", "Methsara", "12/1/2006", image2));

            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/U4.png", UriKind.Relative));
            students.Add(new Student(23, "Tharindu", "Perera", "02/11/1999", image3));

            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/U5.png", UriKind.Relative));
            students.Add(new Student(22, "Ranasinghe", "Kavindu", "15/07/2000", image4));

        }

        [RelayCommand]
        public void CloseWindow()
        {
            Application.Current.MainWindow.Close();

        }

        [RelayCommand]
        public void MinimizeWindow()
        {
           

        }

        [RelayCommand]
        public void AddNewStudent()
        {
            var vm = new AddStudentVM();
            AddStudent window = new AddStudent(vm);
            window.ShowDialog();

            if (vm.student.FirstName != null)
            {
                students.Add(vm.student);
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                students.Remove(selectedStudent);
                MessageBox.Show("Deleted successfull!", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Please Select a Student before Delete.", "Error");


            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (selectedStudent != null)
            {
                var vm = new AddStudentVM(selectedStudent);
                
                var window = new AddStudent(vm);

                window.ShowDialog();


                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, vm.student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

    }
}
