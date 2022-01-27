// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;

namespace InformationSystem
{
    internal class Program
    {
        #region Задание
        /// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
        /// В структуре присутствуют департаменты и сотрудники
        /// Каждый департамент может содержать не более 1_000_000 сотрудников.
        /// У каждого департамента есть поля: наименование, дата создания,
        /// количество сотрудников числящихся в нём 
        /// (можно добавить свои пожелания)
        /// 
        /// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
        /// уникальный номер, размер оплаты труда, количество закрепленным за ним.
        ///
        /// В данной информаиционной системе должна быть возможность 
        /// - импорта и экспорта всей информации в xml и json
        /// Добавление, удаление, редактирование сотрудников и департаментов
        /// 
        /// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
        /// по нескольким полям, например возрасту и оплате труда
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        /// 
        /// 
        /// Упорядочивание по одному полю возраст
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        /// 
        ///
        /// Упорядочивание по полям возраст и оплате труда
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        /// 
        /// 
        /// Упорядочивание по полям возраст и оплате труда в рамках одного департамента
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        #endregion

        //Статический метод вычисления номера пары неотрицательных
        //целых чисел (Канторовская нумерация пар)
        static int KantorPairs(int x, int y)
        {
            int n = (x + y) * (x + y + 1) / 2 + x;
            return n;
        }
        static void Main(string[] args)
        {
            #region Заполнение xml-файлов тестовыми данными
            {
                //Создали экземпляр класса Organization
                Organization organization = new Organization();

                //Создали экземпляр класа Random
                Random rnd = new Random();
                int i, j = 0;

                //Создадим, для примера, 20 сотрудников и
                //4 отдела. И распределим по 5 сотрудников в
                //каждый отел.
                for (i = 0; i < 4; i++)
                {
                    //Инициализация экземпляра класса Department
                    Department department = new Department($"Отдел {KantorPairs(i, j)}",
                        new DateTime(2021, rnd.Next(1, 12), rnd.Next(1, 28)));

                    //Добавляем инициализированный отдел в список всех отделов
                    organization.AddDepartmentToDepartments(department);

                    for (j = 0; j < 5; j++)
                    {
                        //Инициализация экземпляра класса Employee
                        Employee employee = new Employee($"Фамилия {rnd.Next(1, 10)}",
                            $"Имя {rnd.Next(1, 10)}", rnd.Next(18, 70), rnd.Next(1, 3));

                        //Добавляем сотрудника в список всех сотрудников
                        organization.AddEmployeeToEmployees(employee);

                        //Добавляем сотрудника в отдел
                        organization.AddEmployeeToDepartment(department, employee);
                    }
                }

                //Выведем всех сотрудников не экран
                Console.WriteLine(organization);
                Console.ReadKey();

                #region Сохраним тестовые данные о сотрудниках и отделах в xml-файлах
                Console.Clear();
                //Добавляем коллекцию сотрудников в xml-файл
                organization.AddEmployeesToXml();

                //Добавляем коллекцию отделов в xml-файл
                organization.AddDepartmentsToXml();
                #endregion
            }
            #endregion

            #region Выводим всю информацию об отделах и сотрудниках
            {
                Console.WriteLine("Отделы:");
                Organization organization = new Organization();
                organization.DepartmentsFromXml();//Читаем список отделов из xml-файла
                organization.ShowAllDepartments();//Выводим список всех отделов
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Сотрудники:");
                organization.EmployeesFromXml();//Читаем список сотрудников из xml-файла
                organization.ShowAllEmployees();//Выводим список всех сотрудников
                Console.ReadKey();
                Console.Clear();
            }
            #endregion

            #region Поиск сотрудников или отделов
            //Поиск отдела
            {
                Organization organization = new Organization();
                organization.DepartmentsFromXml();//Читаем список всех отделов из xml-файла
                Console.WriteLine("Поиск отдела");
                Console.Write("Введите название отдела: ");
                string name = Console.ReadLine();
                Department _department = organization.FindDepartment(name);
                if (_department != null)
                {
                    Console.WriteLine($"Результат поиска:\n{_department}");//Выводим на экран информацию о найденном отделе
                }
                else
                {
                    Console.WriteLine($"Отдел {name} не найден");
                }
                Console.ReadKey();
                Console.Clear();
            }

            //Поиск сотрудника
            {
                Organization organization = new Organization();
                organization.EmployeesFromXml();//Читаем список всех сотрудников из xml-файла
                Console.Write("Введите имя или фамилию сотрудника: ");
                string name = Console.ReadLine();
                Employee _employee = organization.FindEmployee(name);
                if (_employee != null)
                {
                    Console.WriteLine($"Результат поиска:\n{_employee}");//Выводим на экран информацию о найденном сотруднике
                }
                else
                {
                    Console.WriteLine($"Сотрудник с именем/фамилией {name} не найден");
                }
                Console.ReadKey();
                Console.Clear();
            }
            #endregion

            #region Редактирование сотрудников или отделов
            //Редактирование отдела. Будем менять название отдела.
            //Переименование отдела
            {
                Organization organization = new Organization();
                organization.DepartmentsFromXml();//Читаем список всех отделов из xml-файла
                Console.WriteLine("Поиск отдела для переименования");
                Console.Write("Введите название отдела для переименования: ");
                string oldDepartmentName = Console.ReadLine();
                if (organization.FindDepartment(oldDepartmentName) != null)
                {
                    Console.Write("Введите новое название отдела: ");
                    string newDepartmentName = Console.ReadLine();
                    organization.EditDepartment(oldDepartmentName, newDepartmentName);
                    Console.WriteLine("Отдел успешно переименован");
                }
                else
                {
                    Console.WriteLine($"Отдел с названием {oldDepartmentName} не найден");
                }
                Console.ReadKey();
                Console.Clear();
            }

            //Редактирование сотрудника. Будем менять количество закрепленных за ним проектов
            {
                Organization organization = new Organization();
                organization.EmployeesFromXml(); //Читаем список всех отделов из xml-файла
                Console.WriteLine("Поиск сотрудника для измения количества проектов");
                Console.Write("Введите фамилию или имя сотрудника: ");
                string name = Console.ReadLine();
                if (organization.FindEmployee(name) != null)
                {
                    Console.Write("Новое число проектов: ");
                    int projects = int.Parse(Console.ReadLine());
                    organization.EditEmployee(name, projects);
                    Console.WriteLine($"Количество проектов сотрудника {name} изменено");

                }
                else
                {
                    Console.WriteLine($"Сотрудник с фамилией или именем {name} не найден");
                }
                Console.ReadKey();
                Console.Clear();
            }

            #endregion

            //Удаление данных об отделе из xml-файла
            {
                Organization organization = new Organization();
                organization.DepartmentsFromXml();//Прочитали информацию обо всех отделах из xml-файла
                Console.WriteLine(organization);//Вывели информацию обо всех отделах из xml-файла на экран консоли
                Console.Write("Введите название отдела для удаления: ");
                string name = Console.ReadLine();
                if (organization.FindDepartment(name) != null)
                {
                    organization.DeleteDepartmentFromXml(name);//Удаляем отдел из xml-файла
                    Console.WriteLine($"Отдел с названием {name} удалён");

                }
                else
                {
                    Console.WriteLine($"Отдел с названием {name} не найден");
                }
                Console.ReadKey();
                Console.Clear();
            }

            ////Удаление сотрудника
            //{
            //    Console.WriteLine(organization);
            //    Console.Write("Введитте имя или фамилию сотрудника для удаления: ");
            //    string name = Console.ReadLine();
            //    organization.DeleteEmployee(name);
            //    Console.ReadKey();
            //    Console.Clear();
            //}

            ////Добавление нового отдела
            //{
            //    Console.WriteLine(organization);
            //    Console.Write("Введите название нового отдела: ");
            //    string name = Console.ReadLine();
            //    Department department = new Department(name, DateTime.Now);
            //    organization.AddDepartmentToDepartments(department);
            //    Console.WriteLine(organization);
            //    Console.ReadKey();
            //    Console.Clear();
            //}
            ////Добавление нового сотрудника
            //{
            //    Console.WriteLine(organization);
            //    Console.Write("Введите данные о новом сотруднике: ");

            //    Console.Write("Фамилия: ");
            //    string firstName = Console.ReadLine();

            //    Console.Write("Имя: ");
            //    string secondName = Console.ReadLine();

            //    Console.Write("Возраст: ");
            //    int age = int.Parse(Console.ReadLine());

            //    Console.Write("Количество проектов: ");
            //    int projects = int.Parse(Console.ReadLine());

            //    //Создадим экземпляр класса Employee
            //    Employee employee = new Employee(secondName,firstName,age,projects);

            //    //Добавим нового сотрудника к списку всех сотрудников
            //    organization.AddEmployeeToEmployees(employee);

            //    Console.Write("Введите название отдела для данного сотрудника: ");
            //    string name = Console.ReadLine();

            //    //Находим отдел в списке всех отделов
            //    Department department = organization.FindDepartment(name);

            //    //Добавляем сотрудника в новый отдел
            //    organization.AddEmployeeToDepartment(department, employee);

            //    //Выводим всю информацию на экран консоли
            //    Console.WriteLine(organization);
            //    Console.ReadKey();
            //    Console.Clear();
            //}
        }
    }
}
