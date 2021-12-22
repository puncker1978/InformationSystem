using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace InformationSystem
{
    /// <summary>
    /// Класс описывающий организацию
    /// </summary>
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

        #region Методы добавления отделов/сотрудников в списки отделов/сотрудников

        /// <summary>
        /// Метод добавления нового отдела к списку всех отделов
        /// </summary>
        /// <param name="department">Добавляемый отдел</param>
        internal void AddDepartmentToDepartments(Department department)
        {
            Departments.Add(department);
        }

        /// <summary>
        /// Метод добавления нового сотрудника к списку всех сотрудников
        /// </summary>
        /// <param name="employee">Добавляемый сотрудник</param>
        internal void AddEmployeeToEmployees(Employee employee)
        {
            employees.Add(employee);
        }
        #endregion

        #region Методы поиска отделов/сотрудников в списках отделов/сотрудников
        /// <summary>
        /// Метод поиска отдела по названию
        /// </summary>
        /// <param name="name">Название отдела</param>
        /// <returns>Отдел</returns>
        internal Department FindDepartment(string name)
        {
            Department _department = null;
            foreach (Department department in Departments)
            {
                if (department.DepartmentName == name)
                {
                    _department = department;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return _department;
        }

        /// <summary>
        /// Метод поиска сотрудника по имени или фамилии
        /// </summary>
        /// <param name="name">Фамилия или имя сотрудника</param>
        /// <returns>Сотрудник</returns>
        internal Employee FindEmployee(string name)
        {
            Employee _employee = null;
            foreach (Employee employee in Employees)
            {
                if (employee.SecondName == name || employee.FirstName == name)
                {
                    _employee = employee;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return _employee;
        }
        #endregion

        #region Метод добавления сотрудника к отделу
        /// <summary>
        /// Метод присваивает каждому сотруднику отдела
        /// уникальный идентификационный номер отдела
        /// </summary>
        /// <param name="department">Отдел к которому прикрепляется сотрудник</param>
        /// <param name="employee">Прикрепляемый сотрудник</param>
        internal void AddEmployeeToDepartment(Department department, Employee employee)
        {
            employee.IdDepartment = department.Id;
            department.Contingent++;
        }
        #endregion

        #region Методы удаления отделов/сотрудников из списков отделов/сотрудников
        /// <summary>
        /// Метод удаления отдела из списка всех отделов
        /// и всех сотрудников этого отдела
        /// </summary>
        /// <param name="name">Название отдела</param>
        internal void DeleteDepartment(string name)
        {
            Department _department = FindDepartment(name);
            if (_department != null)
            {
                foreach (Employee employee in Employees)
                {
                    if (employee.Id == _department.Id)
                    {
                        Employees.Remove(employee);
                    }
                }
                Departments.Remove(_department);
            }
        }

        /// <summary>
        /// Метод удаляет сотрудника из списка всех сотрудников
        /// </summary>
        /// <param name="name">Фамилия или имя сотрудника</param>
        internal void DeleteEmployee(string name)
        {
            Employee _employee = FindEmployee(name);
            if (_employee != null)
            {
                Employees.Remove(_employee);
            }
        }
        #endregion

        #region Метод вывода информации о всех отделах и всех сотрудниках
        /// <summary>
        /// Метод выводит всю информацию на экран консоли
        /// </summary>
        public override string ToString()
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
            return str;
        }
        #endregion

        #region Специальные методы для работы с xml-файлами
        /// <summary>
        /// Метод добавления списка сотрудников в xml-файл
        /// </summary>
        internal void AddEmployeesToXml()
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
                    new XElement("Зарплата", employee.Total),
                    new XElement("Проекты", employee.Projects)));
            }
            xDoc.Save("employees.xml");
        }

        /// <summary>
        /// Метод добавления списка отделов в xml-файл
        /// </summary>
        internal void AddDepartmentsToXml()
        {
            XDocument xDoc = XDocument.Load("departments.xml");
            XElement root = xDoc.Element("Departments");
            foreach (Department department in Departments)
            {
                root.Add(new XElement("Department",
                            new XElement("Id", department.Id),
                            new XElement("Отдел", department.DepartmentName),
                            new XElement("Создан", department.CreationDate),
                            new XElement("Контингент", department.Contingent)));
            }
            xDoc.Save("departments.xml");
        }
        #endregion

        #endregion
    }
}
