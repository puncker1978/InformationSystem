using System;
using System.Collections.Generic;
using System.Text;

namespace InformationSystem
{
    internal class Organization
    {
        #region Поля
        /// <summary>
        /// Уникальный идентификационный номер отдела
        /// </summary>
        private int idDepartment;

        /// <summary>
        /// Уникальный идентификационный номер сотрудника
        /// </summary>
        private int idEmployee;
        #endregion

        #region Свойства
        /// <summary>
        /// Уникальный идентификационный номер отдела
        /// </summary>
        internal int IdDepartment { get => idDepartment; set => idDepartment = value; }

        /// <summary>
        /// Уникальный идентификационный номер сотрудника
        /// </summary>
        internal int IdEmployee { get => idEmployee; set => idEmployee = value; }
        #endregion
    }
}
