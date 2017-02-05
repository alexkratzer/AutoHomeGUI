using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoHome;

namespace AH_RunningStartupConfig
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object ListPlc)
        {
            InitializeComponent();
        }
    }


    public class EmployeeInfo
    {
        private string _firstName;
        private string _lastName;
        private string _employeeNumber;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string EmployeeNumber
        {
            get { return _employeeNumber; }
            set { _employeeNumber = value; }
        }

        public EmployeeInfo(string firstname, string lastname, string empnumber)
        {
            _firstName = firstname;
            _lastName = lastname;
            _employeeNumber = empnumber;
        }
    }
    public class myEmployees :
            ObservableCollection<EmployeeInfo>
    {
        public myEmployees()
        {
            Add(new EmployeeInfo("Jesper", "Aaberg", "1234567890"));
            Add(new EmployeeInfo("Dominik", "Paiha", "9876543210"));
            Add(new EmployeeInfo("Yale", "Li", "2387534291"));
            Add(new EmployeeInfo("Muru", "Subramani", "4939291992"));
        }
    }
}
