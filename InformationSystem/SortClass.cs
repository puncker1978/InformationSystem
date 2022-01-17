﻿using System.Collections.Generic;
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
        internal List<Employee> sortedEmployeesByAge()
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
        internal List<Employee> sortedEmployeesByAgeAndTotal()
        {
            Employees = (List<Employee>)(from employee in Employees
                                         orderby employee.Age,
                                         employee.Total 
                                         select Employees);

            return Employees;
        }

        internal List<Employee> sortedEmployeesByDepartmentAndAgeAndTotal()
        {
            Employees = (List<Employee>)(from employee in Employees
                                         orderby employee.Age,
                                         employee.Total
                                         select Employees);

            return Employees;
        }
        #endregion

        #region Сортировки отделов
        #endregion
    }
}