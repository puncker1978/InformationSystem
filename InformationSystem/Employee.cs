// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;

namespace InformationSystem
{
    /// <summary>
    /// Класс описывает сотрудника
    /// </summary>
    public class Employee
    {
        #region Константы
        /// <summary>
        /// Ставка заработной платы труда на 1 проект
        /// </summary>
        private readonly int salary = 1000;
        #endregion

        #region Поля
        /// <summary>
        /// Уникальный идентификационный номер сотрудника
        /// </summary>
        private string id;

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
        private string idDepartment;

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
        internal string Id { get => id; set => id = value; }

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
        internal string IdDepartment { get => idDepartment; set => idDepartment = value; }

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
        /// firstName, age и projects. Поле total (итоговая заработная плата) расчитывается как произведение количества
        ///  проектов сотрудника projects на ставку salary.
        /// </summary>
        /// <param name="secondName">Фамилия сотрудника</param>
        /// <param name="firstName">Имя сотрудника</param>
        /// <param name="age">Возраст сотрудника</param>
        /// <param name="projects">Количество проектов, закрепленных за сотрудником</param>
        internal Employee(string secondName, string firstName, int age, int projects)
        {
            this.Id = Guid.NewGuid().ToString();
            this.SecondName = secondName;
            this.FirstName = firstName;
            this.Age = age;
            this.Projects = projects;
            this.Total = salary * this.Projects;
        }

        internal Employee(string id,
                          string secondName,
                          string firstName,
                          int age,
                          string idDepartment,
                          int projects,
                          int total)
        {
            this.Id = id;
            this.SecondName = secondName;
            this.FirstName = firstName;
            this.Age = age;
            this.IdDepartment = idDepartment;
            this.Projects = projects;
            this.Total = total;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод выводит сведения о сотруднике в консоль
        /// </summary>
        /// <returns>Сотрудник</returns>
        public override string ToString()
        {
            return $"№ Сотрудника\t{this.id}\n" +
                $"Фамилия\t{this.SecondName}\n" +
                $"Имя\t{this.FirstName}\n" +
                $"Возраст\t{this.Age}\n" +
                $"Количество проектов\t{this.Projects}\n" +
                $"Заработная плата\t{this.Total}\n" +
                $"№ Отдела\t{this.IdDepartment}";
        }

        /// <summary>
        /// Метод изменяет количество закрепленных за сотрудником
        /// проектов и заработную плату в соответствии с ноовым
        /// количеством проектов
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="newProjects">Новое количество проектов</param>
        internal void EditEmployee(int newProjects)
        {
            Projects = newProjects;
            Total = newProjects * salary;
        }
        #endregion
    }
}
