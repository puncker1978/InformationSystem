// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.Collections.Generic;
using System.Linq;

namespace InformationSystem
{
    /// <summary>
    /// Частичный класс содержит методы многокритериальных сортировок
    /// </summary>
    internal partial class Organization
    {
        #region Сортировки сотрудников

        /// <summary>
        /// Сортировка списка сотрудников по полю "Возраст"
        /// </summary>
        /// <returns>Отсортированный список по полю "Возраст"</returns>
        internal List<Employee> SortedEmployeesByAge()
        {
            Employees = (List<Employee>)(from employee in Employees
                                         orderby employee.Age
                                         select Employees);

            return Employees;
        }

        /// <summary>
        /// Сортировка списка сотрудников по двум полям: "Возраст" и "Заработная плата"
        /// </summary>
        /// <returns>Отсортированный список сотрудников по двум полям</returns>
        internal List<Employee> SortedEmployeesByAgeAndTotal()
        {
            Employees = (List<Employee>)(from employee in Employees
                                         orderby employee.Age,
                                         employee.Total
                                         select Employees);

            return Employees;
        }

        internal List<Employee> SortedEmployeesByDepartmentAndAgeAndTotal()
        {
            Employees = (List<Employee>)(from employee in Employees
                                         from department in Departments
                                         orderby department.DepartmentName,
                                         employee.Age,
                                         employee.Total
                                         select Employees);

            return Employees;
        }
        #endregion

        #region Сортировки отделов
        #endregion
    }
}
