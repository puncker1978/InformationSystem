using System.Collections.Generic;
using System.Xml.Linq;

namespace InformationSystem
{
    /// <summary>
    /// Частичный класс содержит методы для работы с xml-файлами
    /// </summary>
    internal partial class Organization
    {
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
                    new XElement("Проекты", employee.Projects),
                    new XElement("Отдел", employee.IdDepartment)));
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

        /// <summary>
        /// Метод чтения xml-файла в коллекцию сведений обо всех сотрудниах
        /// </summary>
        /// <returns>Коллекция сотрудников</returns>
        internal List<Employee> EmployeesFromXml()
        {
            XDocument xDoc = XDocument.Load("employees.xml");
            foreach (XElement _employee in xDoc.Element("Employees").Elements("Employee"))
            {
                XElement Id = _employee.Element("Id");
                XElement SecondName = _employee.Element("Фамилия");
                XElement FirstName = _employee.Element("Имя");
                XElement Age = _employee.Element("Возраст");
                XElement Total = _employee.Element("Зарплата");
                XElement Projects = _employee.Element("Проекты");
                XElement IdDepartment = _employee.Element("Отдел");

                Employee employee = new Employee(
                    Id.Value,
                    SecondName.Value,
                    FirstName.Value,
                    int.Parse(Age.Value),
                    IdDepartment.Value,
                    int.Parse(Projects.Value),
                    int.Parse(Total.Value));
                Employees.Add(employee);
            }
            return Employees;
        }

        /// <summary>
        /// Метод чтения xml-файла в коллекцию сведений обо всех отделах
        /// </summary>
        /// <returns>Коллекция сотрудников</returns>
        internal List<Department> DepartmentsFromXml()
        {
            XDocument xDoc = XDocument.Load("departments.xml");
            foreach (XElement _department in xDoc.Element("Departments").Elements("Department"))
            {
                XElement Id = _department.Element("Id");
                XElement DepartmentName = _department.Element("Отдел");
                XElement CreationDate = _department.Element("Создан");
                XElement Contingent = _department.Element("Контингент");

                Department department = new Department(
                    Id.Value,
                    DepartmentName.Value,
                    CreationDate.Value,
                    Contingent.Value);
                Departments.Add(department);
            }
            return Departments;
        }

        /// <summary>
        /// Метод удаляет отдел из списка всех отделов в xml-файле
        /// </summary>
        /// <param name="name">Название отдела</param>
        internal void DeleteDepartmentFromXml(string name)
        {
            XDocument xDoc = XDocument.Load("departments.xml");
            XElement Departments = xDoc.Element("Departments");

            foreach (XElement _department in Departments.Elements("Departments"))
            {
                // изменяем название и цену
                if (_department.Value == name)
                {
                    _department.Remove();
                }
            }
            xDoc.Save("departments.xml");
        }
        #endregion
    }
}
