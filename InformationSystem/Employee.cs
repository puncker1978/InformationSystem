using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem
{
    internal class Employee
    {
        #region Константы
        /// <summary>
        /// Ставка заработной платы труда на 1 проект
        /// </summary>
        private int salary;
        #endregion

        #region Статические поля
        private static int _id;
        #endregion

        #region Поля
        /// <summary>
        /// Уникальный идентификационный номер сотрудника
        /// </summary>
        private int id;

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        private string secondName;

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        private string firstName;

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        private int age;

        /// <summary>
        /// Номер отдела, к которому прикреплён сотрудник
        /// </summary>
        private int idDepartment;

        /// <summary>
        /// Количество проектов, закрепленных за сотрудником
        /// </summary>
        private int projects;

        /// <summary>
        /// Итоговая заработная плата. Расчитывается как произведение количества проектов на ставку заработной платы.
        /// </summary>
        private int total;
        #endregion

        #region Свойства
        /// <summary>
        /// Уникальный идентификационный номер сотрудника
        /// </summary>
        internal int Id { get => id; set => id = value; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        internal string SecondName { get => secondName; set => secondName = value; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        internal string FirstName { get => firstName; set => firstName = value; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        internal int Age { get => age; set => age = value; }

        /// <summary>
        /// Номер отдела, к которому прикреплён сотрудник
        /// </summary>
        internal int IdDepartment { get => idDepartment; set => idDepartment = value; }

        /// <summary>
        /// Количество проектов, закрепленных за сотрудником
        /// </summary>
        internal int Projects { get => projects; set => projects = value; }

        /// <summary>
        /// Итоговая заработная плата. Расчитывается как произведение количества проектов на ставку заработной платы.
        /// </summary>
        internal int Total { get => total; set => total = value; }


        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор для создания сотрудника. Конструктор инициализирует поля: secondName,
        /// firstName, age, idDepartment и projects. Cтатическое поле _id, уваличенное на единицу, присваивается
        ///  полю id. Поле total (итоговая заработная плата) расчитывается как произведение количества
        ///  проектов сотрудника projects на ставку salary.
        /// </summary>
        /// <param name="secondName">Фамилия сотрудника</param>
        /// <param name="firstName">Имя сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="idDepartment">Номер отдела, к которому прикреплён сотрудник</param>
        /// <param name="projects">Количество проектов, закрепленных за сотрудником</param>
        internal Employee(string secondName, string firstName, int age, int idDepartment, int projects)
        {
            this.Id = ++_id;
            this.SecondName = secondName;
            this.FirstName = firstName;
            this.Age = age;
            this.IdDepartment = idDepartment;
            this.Projects = projects;
            this.Total = salary * this.Projects;
        }
        #endregion

        #region Методы
        internal void EditEmployee()
        {

        }
        #endregion
    }
}
