using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Regex_Larionova.Classes;

namespace Regex_Larionova.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Classes.Passport EditPassports;

        public Add(Classes.Passport EditPassports)
        {
            InitializeComponent();
            if (EditPassports != null)
            {
                Name.Text = EditPassports.Name;
                FirstName.Text = EditPassports.FirstName;
                LastName.Text = EditPassports.LastName;
                Issued.Text = EditPassports.Issued;
                DateOfIssued.Text = EditPassports.DateOfIssued;
                DepartmentCode.Text = EditPassports.DepartmentCode;
                SeriesAndNumber.Text = EditPassports.SeriesAndNumber;
                DateOfBirth.Text = EditPassports.DateOfBirth;
                PlaceOfBirth.Text = EditPassports.PlaceOfBirth;
                BthAdd.Content = "Сохранить";
                this.EditPassports = EditPassports;
            }
        }
        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (EditPassports == null)
            {
                Passport passport = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
                EditPassports.Name = Name.Text;
                EditPassports.FirstName = FirstName.Text;
                EditPassports.LastName = LastName.Text;
                EditPassports.Issued = Issued.Text;
                EditPassports.DateOfIssued = DateOfIssued.Text;
                EditPassports.DepartmentCode = DepartmentCode.Text;
                EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
                EditPassports.DateOfBirth = DateOfBirth.Text;
                EditPassports.PlaceOfBirth =PlaceOfBirth.Text;
                MainWindow.init.LoadPassport();
                this.Close();
            }
        }
    }
}
