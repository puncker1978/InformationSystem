using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem
{
    internal class Organization
    {
        /// <summary>
        /// Инициализация списка отделов
        /// </summary>
        List<Department> departments = new List<Department>();

        /// <summary>
        /// Инициализация списка сотрудников
        /// </summary>
        List<Employee> employees = new List<Employee>();

        /// <summary>
        /// Инициализация списка отделов
        /// </summary>
        internal List<Department> Departments { get => departments; set => departments = value; }

        /// <summary>
        /// Инициализация списка сотрудников
        /// </summary>
        internal List<Employee> Employees { get => employees; set => employees = value; }

        /// <summary>
        /// Метод добавления нового отдела к списку всех отделов
        /// </summary>
        /// <param name="department"></param>
        internal void AddDepartmentToDepartments(Department department)
        {
            departments.Add(department);
        }

        internal void AddEmployeeToDepartment(Department department, Employee employee)
        {
            employee.IdDepartment = department.Id;
        }
    }
}
