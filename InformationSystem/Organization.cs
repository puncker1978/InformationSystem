using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace InformationSystem
{
    internal class Organization
    {
        #region Приватные коллекции
        /// <summary>
        /// Инициализация списка отделов
        /// </summary>
        private List<Department> departments = new List<Department>();

        /// <summary>
        /// Инициализация списка сотрудников
        /// </summary>
        private List<Employee> employees = new List<Employee>();
        #endregion

        #region Свойства для коллекций
        /// <summary>
        /// Инициализация списка отделов
        /// </summary>
        internal List<Department> Departments { get => departments; set => departments = value; }

        /// <summary>
        /// Инициализация списка сотрудников
        /// </summary>
        internal List<Employee> Employees { get => employees; set => employees = value; }
        #endregion

        #region Методы
        /// <summary>
        /// Метод добавления нового отдела к списку всех отделов
        /// </summary>
        /// <param name="department"></param>
        internal void AddDepartmentToDepartments(Department department)
        {
            Departments.Add(department);
        }

        /// <summary>
        /// Метод присваивает каждому сотруднику отдела
        /// уникальный идентификационный номер отдела
        /// </summary>
        /// <param name="department"></param>
        /// <param name="employee"></param>
        internal void AddEmployeeToDepartment(Department department, Employee employee)
        {
            employee.IdDepartment = department.Id;
            department.Contingent++;
        }

        internal void AddEmployeeToEmployees(Employee employee)
        {
            employees.Add(employee);
        }

        /// <summary>
        /// Метод выводит всю информацию на экран
        /// </summary>
        internal void PrintListEmployee()
        {
            string str = "";
            foreach (Department department in Departments)
            {
                str += $"{department.Id}\t" +
                    $"{department.DepartmentName}\t" +
                    $"{department.CreationDate}\t" +
                    $"{department.Contingent}\n";
                foreach (Employee employee in employees)
                {
                    if (department.Id == employee.IdDepartment)
                    {
                        str += $"{employee.SecondName}\t" +
                            $"{employee.FirstName}\t" +
                            $"{employee.Age}\t" +
                            $"{employee.Total}\t" +
                            $"{employee.Projects}\n";
                    }
                }
            }
            Console.WriteLine(str);
        }

        /// <summary>
        /// Метод добавления списка сотрудников в xml-файл
        /// </summary>
        internal void AddToEmployees()
        {
            XDocument xDoc = XDocument.Load("employees.xml");
            XElement root = xDoc.Element("Employees");
            foreach (Employee employee in Employees)
            {
                root.Add(new XElement("Employee",
                            new XElement("Id", employee.Id),
                            new XElement("Фамилия", employee.SecondName),
                            new XElement("Имя", employee.FirstName),
                            new XElement("Возраст", employee.Age),
                            new XElement("Количество проектов", employee.Projects),
                            new XElement("Заработная плата", employee.Total),
                            new XElement("Отдел", employee.IdDepartment)));
            }
            xDoc.Save("employees.xml");
            Console.WriteLine("Содержимое файла employees.xml");
            Console.WriteLine(xDoc);
        }

        /// <summary>
        /// Метод добавления списка отделов в xml-файл
        /// </summary>
        internal void AddToDepartments()
        {
            XDocument xDoc = XDocument.Load("departments.xml");
            XElement root = xDoc.Element("Departments");
            foreach (Department department in Departments)
            {
                root.Add(new XElement("Department",
                            new XElement("Id", department.Id),
                            new XElement("Отдел", department.DepartmentName),
                            new XElement("Дата создания", department.CreationDate),
                            new XElement("Количество сотрудников", department.Contingent)));
            }
            xDoc.Save("departments.xml");
            Console.WriteLine("Содержимое файла departments.xml");
            Console.WriteLine(xDoc);
        }
        #endregion
    }
}
