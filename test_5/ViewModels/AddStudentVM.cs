using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using test_5.Models;
using test_5.Views;

namespace test_5.ViewModels
{
    public partial class AddStudentVM : ObservableObject
    {
        public void Back()
        {
            var vm = new MainWindowVM();
            MainWindow window = new MainWindow();
            window.ShowDialog();

            
        }



        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public BitmapImage selectedImage;

        public Student student { get; private set; }
        public Action CloseAction { get; internal set; }
        public AddStudentVM(Student x)
        {
            student = x;

            firstname = student.FirstName;
            lastname = student.LastName;
            age = student.Age;
            gpa = student.GPA;
            dateofbirth = student.DateOfBirth;
            selectedImage = student.Image;

        }
        public AddStudentVM()
        {

        }

        [RelayCommand]
        public void InsertImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image uploded!", "successfull");
            }
        }

        [RelayCommand]
        public void Save()
        {



            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("Please enter a GPA value between 0 and 4 ");
                return;
            }
            if (student == null)
            {

                student = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,
                    GPA = gpa

                };


            }
            else
            {

                student.FirstName = firstname;
                student.LastName = lastname;
                student.Age = age;
                student.GPA = gpa;
                student.Image = selectedImage;
                student.DateOfBirth = dateofbirth;



            }

            if (student.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }



    }
}
