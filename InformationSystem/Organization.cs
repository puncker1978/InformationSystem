using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;

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
        #region Общие методы для работы с коллекциями
        /// <summary>
        /// Метод добавления нового отдела к списку всех отделов
        /// </summary>
        /// <param name="department">Добавляемый отдел</param>
        internal void AddDepartmentToDepartments(Department department)
        {
            Departments.Add(department);
        }

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

        /// <summary>
        /// Метод добавления нового сотрудника к списку всех сотрудников
        /// </summary>
        /// <param name="employee">Добавляемый сотрудник</param>
        internal void AddEmployeeToEmployees(Employee employee)
        {
            employees.Add(employee);
        }

        /// <summary>
        /// Метод выводит всю информацию на экран
        /// </summary>
        internal void ShowAll()
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
        /// Метод поиска отдела по названию отдела. В качестве входного параметра имеет название отдела.
        /// В качестве out-параметра имеет ссылку на объект, содержащий сведения о данном отделе.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="_department"></param>
        internal void FindDepartment(string name, out Department _department)
        {
            _department = null;
            foreach (Department department in Departments)
            {
                if (department.DepartmentName == name)
                {
                    _department = department;
                }
            }
            if (_department != null)
            {
                Console.WriteLine(_department);
            }
            else
            {
                Console.WriteLine($"Отдел с названием {name} не найден");
            }
        }

        /// <summary>
        /// Метод поиска сотрудника по имени или фамилии. В качестве входного параметрв имеет имя и фамилию сотрудника.
        /// В качестве out-параметра имеет ссылку на объект, содержащий сведения о данном сотруднике.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="_department"></param>
        internal void FindEmployee(string name, out Employee _employee)
        {
            _employee = null;
            foreach (Employee employee in Employees)
            {
                if (employee.FirstName == name || employee.SecondName == name)
                {
                    _employee = employee;
                }
            }
            if (_employee != null)
            {
                Console.WriteLine(_employee);
            }
            else
            {
                Console.WriteLine($"Сотрудник с именем/фамилией {name} не найден");
            }
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
                    new XElement("Id",employee.Id),
                    new XElement("Фамилия", employee.SecondName),
                    new XElement("Имя", employee.FirstName),
                    new XElement("Возраст",employee.Age),
                    new XElement("Зарплата" ,employee.Total),
                    new XElement("Проекты",employee.Projects)));
            }
            xDoc.Save("employees.xml");
            //Console.WriteLine("Содержимое файла employees.xml");
            //Console.WriteLine(xDoc);
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
            //Console.WriteLine("Содержимое файла departments.xml");
            //Console.WriteLine(xDoc);
        }
        #endregion








        #endregion
    }
}
