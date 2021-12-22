using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem
{
    /// <summary>
    /// Класс описывает отдел
    /// </summary>
    internal class Department
    {
        #region Поля

        /// <summary>
        /// Уникальный идентификационный номер отдела
        /// </summary>
        private Guid id;

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

        #endregion

        #region Свойства
        /// <summary>
        /// Уникальный идентификационный номер отдела
        /// </summary>
        internal Guid Id { get => id; set => id = value; }

        /// <summary>
        /// Название отдела
        /// </summary>
        internal string DepartmentName { get => departmentName; set => departmentName = value; }

        /// <summary>
        /// Дата создания отдела
        /// </summary>
        internal DateTime CreationDate { get => creationDate.Date; set => creationDate = value; }

        /// <summary>
        /// Количество сотрудников отдела
        /// </summary>
        internal int Contingent { get => contingent; set => contingent = value; }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор для создания отдела.
        /// </summary>
        /// <param name="departmentName">Название отдела</param>
        /// <param name="creationDate">Дата создания отдела</param>
        internal Department(string departmentName, DateTime creationDate)
        {
            this.Id = Guid.NewGuid();
            this.DepartmentName = departmentName;
            this.CreationDate = creationDate.Date;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод выводит сведения об отделе в консоль
        /// </summary>
        /// <returns>Отдел</returns>
        public override string ToString()
        {
            return $"№ Отдела\t{this.Id}\n" +
                $"Наименование отдела\t{this.DepartmentName}\n" +
                $"Дата основания отдела\t{this.CreationDate.Date}\n" +
                $"Количество сотрудников\t{this.Contingent}";
        }

        /// <summary>
        /// Метод редактирования названия отдела
        /// </summary>
        /// <param name="department">Отдел</param>
        /// <param name="newDepartmentName">Новое название отдела</param>
        internal void EditDepartment(Department department, string newDepartmentName)
        {
            department.DepartmentName = newDepartmentName;
        }
        #endregion
    }
}
