using System;
using System.Collections.Generic;
using System.Text;

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

        //public override string ToString()
        //{
        //    string str = $"Id " + "Имя " + "Фамилия " + "Возраст " + "Отдел " + "Зарплата " + "Кол-во проектов \n";
        //    foreach(Department department in Departments)
        //    {
        //        foreach (Employee employee in Employees)
        //        {
        //            if (department.Id == employee.IdDepartment)
        //            {
        //                str += $"{department.Contingent}\t{employee.FirstName}\t" +
        //                $"{employee.SecondName}\t{employee.Age}\t" +
        //                $"{department.DepartmentName}\t" +
        //                $"{employee.Total}\t{employee.Projects}\n";
        //            }
        //        }
        //    }
        //    return str;
        //}

        internal void PrintListEmployee()
        {
            string str = "";
            foreach (Department department in Departments)
            {
                str += $"{department.Id}\t{department.DepartmentName}\t{department.CreationDate}\t" +
                    $"{department.Contingent}\n";
                foreach (Employee employee in employees)
                {
                    if (department.Id == employee.IdDepartment)
                    {
                        str += $"{employee.SecondName}\t{employee.FirstName}\t{employee.Age}\t" +
                            $"{employee.Total}\t{employee.Projects}\n";
                    }
                }
            }
            Console.WriteLine(str);
        }
        #endregion
    }
}
