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
            if (String.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match(@"^[а-яА-Я-Ёё]*$", Name.Text))
            {
                MessageBox.Show("He правильно указано имя."); return;
            }
            if (String.IsNullOrEmpty(FirstName.Text) || !Classes.Common.CheckRegex.Match(@"^[а-яА-Я-Ёё]*$", FirstName.Text))
            {

                MessageBox.Show("Нe правильно указано фамилия."); return;
            }
            if
            (String.IsNullOrEmpty(LastName.Text) || !Classes.Common.CheckRegex.Match(@"^[а-яА-Я-Ёё]*$", LastName.Text))
            {
                MessageBox.Show("Нe правильно указано отчество."); return;
            }
            if (String.IsNullOrEmpty(Issued.Text) || !Classes.Common.CheckRegex.Match(@"^[а-яА-Я-Ёё]*$", Issued.Text))
            {
                MessageBox.Show("Не правильно указано кем выдан паспорт.");
                return;
            }

            if (String.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match(@"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19|20)\d{2}$", DateOfIssued.Text))
            {
                MessageBox.Show("Не правильно указана дата выдачи.");
                return;

            }
            if (String.IsNullOrEmpty(DepartmentCode.Text) || !Classes.Common.CheckRegex.Match(@"^\d{3}-\d{3}$", DepartmentCode.Text))
            {
                MessageBox.Show("Не правильно указан код подразделения.");
                return;
            }

            if (String.IsNullOrEmpty(SeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match(@"^\d{2}\s\d{2}\s\d{6}$", SeriesAndNumber.Text))
            {
                MessageBox.Show("Не правильно указаны серия и номер.");
                return;
            }

            if (String.IsNullOrEmpty(DateOfBirth.Text) || !Classes.Common.CheckRegex.Match(@"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19|20)\d{2}$", DateOfBirth.Text))
            {
                MessageBox.Show("Не правильно указана дата рождения.");
                return;
            }

            if (String.IsNullOrEmpty(PlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match(@"^[а-яА-Я-Ёёa-zA-Z\s\-,\.]+$", PlaceOfBirth.Text))
            {
                MessageBox.Show("Не правильно указано место рождения.");
                return;
            }

            if (EditPassports == null)
            {
                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
                EditPassports.Name = Name.Text;
                EditPassports.FirstName = FirstName.Text;
                EditPassports.LastName = LastName.Text;
                EditPassports.Issued = Issued.Text;
                EditPassports.DateOfIssued = DateOfIssued.Text;
                EditPassports.DepartmentCode = DepartmentCode.Text;
                EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
                EditPassports.DateOfBirth = DateOfBirth.Text;
                EditPassports.PlaceOfBirth = PlaceOfBirth.Text;
            }
            MainWindow.init.LoadPassport();
            this.Close();
        }
    }
}


