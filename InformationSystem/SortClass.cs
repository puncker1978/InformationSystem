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
        internal List<Employee> sortedEmployees()
        {
            List<Employee> sortedEmployees = new List<Employee>();
            sortedEmployees = (List<Employee>)(from employee in Employees
                              orderby employee.FirstName,
                              employee.Age,
                              employee.Projects
                              select Employees);

            return sortedEmployees;
        }
        #endregion

        #region Сортировки отделов
        #endregion
    }
}
