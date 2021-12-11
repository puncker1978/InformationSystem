using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem
{
    internal class Department
    {
        #region Поля
        private static int _id, _contingent; 

        /// <summary>
        /// Уникальный идентификационный номер отдела
        /// </summary>
        private int id;

        /// <summary>
        /// Название отдела
        /// </summary>
        private string departmentName;

        /// <summary>
        /// Дата создания отдела
        /// </summary>
        private DateTime creationDate;

        /// <summary>
        /// Количество сотрудников отдела
        /// </summary>
        private int contingent;

        /// <summary>
        /// Список сотрудников отдела
        /// </summary>
        private List<Employee> employees;
        #endregion

        #region Свойства
        /// <summary>
        /// Уникальный идентификационный номер отдела
        /// </summary>
        internal int Id { get => id; set => id = value; }

        /// <summary>
        /// Название отдела
        /// </summary>
        internal string DepartmentName { get => departmentName; set => departmentName = value; }

        /// <summary>
        /// Дата создания отдела
        /// </summary>
        internal DateTime CreationDate { get => creationDate; set => creationDate = value; }

        /// <summary>
        /// Количество сотрудников отдела
        /// </summary>
        internal int Contingent { get => contingent; set => contingent = value; }

        /// <summary>
        /// Список сотрудников отдела
        /// </summary>
        internal List<Employee> Employees { get => employees; set => employees = value; }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор для создания отдела. В момент создания отдела инициализируются только поля
        /// departmentName (название отдела) и creationDate (Дата создания отдела), поскольку сотрудников в 
        /// отделе на момент создания может и не быть. Статическое поле _id, увеличенное на единицу, присваивается
        /// уникальному идентификационному номеру отдела.
        /// </summary>
        /// <param name="departmentName">Название отдела</param>
        /// <param name="creationDate">Дата создания отдела</param>
        internal Department(string departmentName, DateTime creationDate)
        {
            this.Id = ++_id;
            this.DepartmentName = departmentName;
            this.CreationDate = creationDate;
        }
        #endregion

        #region Методы

        /// <summary>
        /// Метод довавления сотрудника в отдел. При добавлении сотрудника, статическое поле _contingent,
        /// увеличенное на единицу, присваивается полю contingent, которое хранит количество сотрудников отдела.
        /// </summary>
        /// <param name="emp">Сотрудник</param>
        internal void AddEmployeeToDepartment(Employee emp)
        {
            Employees.Add(emp);
            this.Contingent = ++_contingent;
        }

        /// <summary>
        /// Метод удаления сотрудника из отдела. При удалении сотрудника, статическое поле _contingent,
        /// уменьшенное на единицу, присваивается полю contingent, которое хранит количество сотрудников отдела.
        /// </summary>
        /// <param name="emp">Сотрудник</param>
        internal void RemoveEmployeeFromDepartment(Employee emp)
        {
            if (Employees.Contains(emp))
            {
                Employees.Remove(emp);
                this.Contingent = --_contingent;
            }
        }

        /// <summary>
        /// Метод поиска сотрудника в списке сотрудников отдела. Возвращает экземпляр класса
        /// Employee. Если сотрудник не найден в списке сотрудников данного класса, возвращает null.
        /// </summary>
        /// <param name="employee">Сотрудник для поиска</param>
        /// <returns></returns>
        internal Employee FindEmployee(Employee employee)
        {
            Employee emp = null;
            int n = Employees.Count;
            for(int i = 0; i < n; i++)
            {
                if(Employees[i] == employee)
                {
                    emp = Employees[i];
                    break;
                }
            }
            return emp;
        }
        #endregion
    }
}
