using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LinqForXML.data;
using LinqForXML.model;
using Microsoft.VisualBasic;

namespace LinqForXAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xMainWindow_OnLoadedry>
    public partial class MainWindow : Window
    {
        private readonly Employee[] _employees = new EmployeeData().Employees();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var employee in _employees)
            {
                ListBoxProducts.Items.Add($"{employee.EmployeeId} - {employee.FirstName} {employee.LastName}");
                CbSex.Items.Add(employee.Sex);
                CbSex.SelectedIndex = 0;
                CbPosition.Items.Add(employee.Position);
                CbPosition.SelectedIndex = 0;
            }
        }

        private void ListBoxProducts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlockInfo.Text = _employees[ListBoxProducts.SelectedIndex].ToString();
        }

        /// <summary>
        /// Поиск сотрудников по дате рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(DatePicker.Text);
            string str = "";
            var employees = _employees
                .Where(em => dateTime.ToString("yyyy.MM.dd") == em.Birthday)
                .Select(em => em);
            foreach (var employee in employees)
                str += string.Format(
                    $"{employee.FirstName} " +
                    $"{employee.LastName} " +
                    $"{employee.Patronymic}: " +
                    $"{employee.Position}\n"
                );
            MessageBox.Show(str, $"Сотрудники c датой рождения {dateTime:yyyy MMMM dd}");
        }

        /// <summary>
        /// Количество сотрудников определённого пола, занимающих определённую должность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            var employees = _employees
                .Where(emp => emp.Sex == CbSex.Text && emp.Position == CbPosition.Text)
                .Select(emp => emp);
            MessageBox.Show($"{employees.Count()}",
                $"Число сотрудников {CbSex.Text} пола, занимающие должность: {CbPosition.Text}");
        }

        /// <summary>
        /// Сотрудники с окладом больше указанной суммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            string str = "";
            var employees = _employees
                .Where(emp => emp.Salary > Convert.ToDouble(TbSalary.Text))
                .Select(emp => emp);
            foreach (var employee in employees)
            {
                str += Strings.Format(
                    $"{employee.FirstName} " +
                    $"{employee.LastName} " +
                    $"{employee.Patronymic} - " +
                    $"{employee.Position} | " +
                    $"{employee.Salary} руб.\n\n"
                );
            }
            MessageBox.Show(str, $"Количество сотрудников с окладом выше {TbSalary.Text} руб.");
        }

        /// <summary>
        /// Список должностей с указанием отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            string str = "";
            Department[] departments = new DepartmentData().Departments();
            var positions = _employees
                .Join(
                    departments,
                    position => position.DepartmentId,
                    department => department.DepartmentId,
                    (position, department) => new
                    {
                        departmentId = department.DepartmentId,
                        departmentName = department.DepartmentName,
                        departmentPlaces = department.EmployeePlaces,
                        position = position.Position
                    }
                );
            foreach (var position in positions)
            {
                str += Strings.Format(
                    $"Id: {position.departmentId}\n" +
                    $"Отдел: {position.departmentName}\n" +
                    $"Места: {position.departmentPlaces}\n" +
                    $"Должность: {position.position}\n\n"
                );
            }
            MessageBox.Show(str, "Список отделов и должностей");
        }

        /// <summary>
        /// Сотрудники с окладом меньше указанной суммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_OnClick(object sender, RoutedEventArgs e)
        {
            string str = "";
            var employees = _employees
                .Where(emp => emp.Salary < Convert.ToDouble(TbSalarySmaller.Text))
                .Select(emp => emp);
            foreach (var employee in employees)
            {
                str += Strings.Format(
                    $"{employee.FirstName} " +
                    $"{employee.LastName} " +
                    $"{employee.Patronymic} - " +
                    $"{employee.Position} | " +
                    $"{employee.Salary} руб.\n\n"
                );
            }
            MessageBox.Show(str, $"Количество сотрудников с окладом выше {TbSalarySmaller.Text} руб.");
        }
    }
}