// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Linq;

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
        /// Метод добавляет новый отдел в xml-файл
        /// </summary>
        /// <param name="department">Добавляемый отдел</param>
        internal void AddNewDepartmentToXml(Department department)
        {
            XDocument xDoc = XDocument.Load("departments.xml");
            XElement root = xDoc.Element("Departments");

            if (root != null)
            {
                // добавляем новый элемент
                root.Add(new XElement("Department",
                            new XElement("Id", department.Id),
                            new XElement("Отдел", department.DepartmentName),
                            new XElement("Создан", department.CreationDate),
                            new XElement("Контингент",department.Contingent)));

                xDoc.Save("departments.xml");
            }
        }

        /// <summary>
        /// Метод добавления одного нового сотрудника в существующий отдел
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="departmentName">Название отдела</param>
        internal void AddNewEmployeeToXml(Employee employee, string departmentName)
        {
            XDocument xDocEmployees = XDocument.Load("employees.xml");
            XDocument xDocDepartments = XDocument.Load("departments.xml");
            foreach(XElement _department in xDocDepartments.Element("Departments").Elements("Department"))
            {
                if(_department.Element("Отдел").Value == departmentName)
                {
                    employee.IdDepartment = _department.Element("Id").Value;
                    string oldContingent = _department.Element("Контингент").Value;
                    int newContingent = int.Parse(oldContingent) + 1;
                    _department.Element("Контингент").Value = newContingent.ToString();
                    break;
                }
                else
                {
                    Console.WriteLine($"Отдел с названием {departmentName} не существует");
                }
            }
            xDocDepartments.Save("departments.xml");
            XElement root = xDocEmployees.Element("Employees");
                root.Add(new XElement("Employee",
                    new XElement("Id", employee.Id),
                    new XElement("Фамилия", employee.SecondName),
                    new XElement("Имя", employee.FirstName),
                    new XElement("Возраст", employee.Age),
                    new XElement("Зарплата", employee.Total),
                    new XElement("Проекты", employee.Projects),
                    new XElement("Отдел", employee.IdDepartment)));
            xDocEmployees.Save("employees.xml");
        }

        /// <summary>
        /// Метод чтения xml-файла в коллекцию сведений обо всех сотрудниах
        /// </summary>
        /// <returns>Коллекция сотрудников</returns>
        internal List<Employee> EmployeesFromXmlToCollection()
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
        /// Метод удаляет из xml-файла всех сотрудников с заданным Id отдела
        /// </summary>
        /// <param name="idDepartment">Id отдела сотрудника</param>
        internal void DeleteDepartmentEmployeesFromXml(Guid idDepartment)
        {
            XDocument xDoc = XDocument.Load("employees.xml");
            foreach (XElement _employee in xDoc.Element("Employees").Elements("Employee"))
            {
                if(_employee.Element("Отдел").Value == idDepartment.ToString())
                {
                    _employee.Remove();
                }
            }
        }

        /// <summary>
        /// Метод чтения xml-файла в коллекцию сведений обо всех отделах
        /// </summary>
        /// <returns>Коллекция сотрудников</returns>
        internal List<Department> DepartmentsFromXmlToCollection()
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
        /// Метод удаляет отдел из списка всех отделов и возвращает Id удаленного отдела
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal Guid DeleteDepartmentFromXml(string name)
        {
            string idDepartment = "";
            XDocument xDocDepartment = XDocument.Load("departments.xml");
            foreach (XElement _department in xDocDepartment.Element("Departments").Elements("Department"))
            {
                if (_department.Element("Отдел").Value == name)
                {
                    idDepartment = _department.Element("Id").Value;
                    _department.Remove();
                    break;
                }
            }
            xDocDepartment.Save("departments.xml");
            return Guid.Parse(idDepartment);
        }

        /// <summary>
        /// Метод удалает из xml-файла всех сотрудников из удаляемого одела
        /// </summary>
        /// <param name="idDepartment">Id отдела</param>
        internal void DeleteDepartmentEmployees(Guid idDepartment)
        {
            XDocument xDoc = XDocument.Load("employees.xml");
            IEnumerable<XElement> tempEmployees = xDoc.Root.Descendants("Employee").Where(
                t => t.Element("Отдел").Value == idDepartment.ToString());
            tempEmployees.Remove();



            //foreach (XElement _employee in xDoc.Element("Employees").Elements("Employee"))
            //{
            //    if (_employee.Element("Отдел").Value == idDepartment.ToString())
            //    {
            //        _employee.Remove();
            //    }
            //}
            xDoc.Save("employees.xml");
        }

        /// <summary>
        /// Метод удаляет сотрудника из списка всех сотрудников
        /// </summary>
        /// <param name="name"></param>
        internal void DeleteEmployeeFromXml(string name)
        {
            XDocument xDocEmployee = XDocument.Load("employees.xml");
            foreach (XElement _employee in xDocEmployee.Element("Employees").Elements("Employee"))
            {
                if ((_employee.Element("Фамилия").Value == name) || (_employee.Element("Имя").Value == name))
                {
                    _employee.Remove();
                }
               
            }
            xDocEmployee.Save("employees.xml");
        }

        /// <summary>
        /// Редактирование названия отдела
        /// </summary>
        /// <param name="oldDepartmentName">Старое название отдела</param>
        /// <param name="newDepartmentName">Новое название отдела</param>
        internal void EditDepartment(string oldDepartmentName, string newDepartmentName)
        {
            XDocument xDoc = XDocument.Load("departments.xml");
            XElement Departments = xDoc.Element("Departments");
            foreach (XElement _department in Departments.Elements("Department"))
            {
                if (_department.Element("Отдел").Value == oldDepartmentName)
                {
                    _department.Element("Отдел").Value = newDepartmentName;
                }
            }
            xDoc.Save("departments.xml");
        }

        /// <summary>
        /// Метод редактирования количества проектов, закреплённых за сотрудников
        /// </summary>
        /// <param name="secondName">Фамилия сотрудника</param>
        /// <param name="firstName">Имя сотрудника</param>
        /// <param name="projects">Новое количество проектов</param>
        internal void EditEmployee(string name, int projects)
        {
            XDocument xDoc = XDocument.Load("employees.xml");
            XElement Employees = xDoc.Element("Employees");
            foreach (XElement _employee in Employees.Elements("Employee"))
            {
                if ((_employee.Element("Фамилия").Value == name) ||
                    (_employee.Element("Имя").Value == name))
                {
                    _employee.Element("Проекты").Value = projects.ToString();
                    
                    Employee employee = new Employee(projects);

                    _employee.Element("Зарплата").Value = employee.Total.ToString();
                }
            }
            xDoc.Save("employees.xml");
        }

        #endregion
    }
}
