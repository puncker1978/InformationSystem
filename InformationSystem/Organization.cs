using System.Collections.Generic;
using System;

namespace InformationSystem
{
    /// <summary>
    /// Класс описывающий организацию
    /// </summary>
    internal partial class Organization
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
        #region Общие методы
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

        #region Методы вывода информации о всех отделах и/или всех сотрудниках
        /// <summary>
        /// Метод выводит всю информацию об отделах и сотрудниках на экран консоли
        /// </summary>
        public override string ToString()
        {
            string str = "";
            foreach (Department department in Departments)
            {
                str += $"====================================================\n" +
                    $"№ Отдела:\t{department.Id}\n" +
                    $"Наименование:\t{department.DepartmentName}\n" +
                    $"Основан:\t{department.CreationDate}\n" +
                    $"Контингент:\t{department.Contingent}\n" +
                    $"----------------------------------------------------\n";
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

        /// <summary>
        /// Метод выводит всю информацию обо всех отделах на экран консоли
        /// </summary>
        internal void ShowAllDepartments()
        {
            Console.WriteLine($"№ Отдела                                    Отдел          Создан                Контингент");
            foreach (Department department in Departments)
            {
                Console.WriteLine($"{department.Id}" +
                    $"{department.DepartmentName,15}" +
                    $"{department.CreationDate.Date,25}" +
                    $"{department.Contingent,10}");
            }
        }

        internal void ShowAllEmployees()
        {
            Console.WriteLine($"Фамилия       Имя         Возраст    Проектов    Зарплата");
            foreach (Employee employee in Employees)
            {
                Console.WriteLine($"{employee.SecondName}" +
                    $"{employee.FirstName,10}" +
                    $"{employee.Age,10}" +
                    $"{employee.Projects,10}" +
                    $"{employee.Total,15}");
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
