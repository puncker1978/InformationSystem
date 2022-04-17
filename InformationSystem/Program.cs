// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;

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
                        new DateTime(2021, rnd.Next(1, 12), rnd.Next(1, 28)).Date);

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

            #region Меню
            {
                Console.WriteLine("1 - создать отдел\n" +
                "2 - создать сотрудника\n" +
                "3 - редактировать отдел\n" +
                "4 - редактировать сотрудника\n" +
                "5 - удалить отдел и всех его сотрудников\n" +
                "6 - удалить сотрудника\n" +
                "7 - поиск сотрудника\n" +
                "8 - поиск отдела\n" +
                "9 - сортировка сотрудников по полю \"Возраст\"\n" +
                "10 - сортировка сотрудников по полям \"Возраст\" и \"Зарплата\"\n" +
                "11 - сортировка сотрудников по полям \"Отдел\" \"Возраст\" , \"Зарплата\"\n" +
                "0 - выход");
                string choise = Console.ReadLine();

                switch(choise)
                {
                    case "1": //Добавление нового отдела
                        {
                            {
                                Organization organization = new Organization();
                                Console.Write("Введите название нового отдела: ");
                                string name = Console.ReadLine();

                                //Создаём новый отдел
                                Department department = new Department(name, DateTime.Now);

                                //Добавляем вновь созданный отдел в xml-файл
                                organization.AddNewDepartmentToXml(department);
                                Console.WriteLine(organization);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case "2": //Добавление нового сотрудника
                        {
                            {
                                Organization organization = new Organization();
                                organization.Employees = organization.EmployeesFromXmlToCollection();
                                organization.Departments = organization.DepartmentsFromXmlToCollection();

                                Console.Write("Введите название отдела, в который хотите добавить сотрудника: ");
                                string departmentName = Console.ReadLine();

                                Department department = organization.FindDepartment(departmentName);

                                if (department != null)
                                {
                                    Console.WriteLine("Введите данные о новом сотруднике");

                                    Console.Write("Фамилия: ");
                                    string secondName = Console.ReadLine();

                                    Console.Write("Имя: ");
                                    string firstName = Console.ReadLine();

                                    Console.Write("Возраст: ");
                                    int age = Byte.Parse(Console.ReadLine());

                                    
                                    Console.Write("Количество проектов: ");
                                    int projects = Byte.Parse(Console.ReadLine());

                                    //Создаём нового сотрудника
                                    Employee employee = new Employee(secondName, firstName, age, projects);

                                    //Добавляем нового сотрудника в существующий отдел в xml-файл
                                    organization.AddNewEmployeeToXml(employee, departmentName);

                                    Console.WriteLine($"Сторудник:\n" +
                                        $"Id сотрудника: {employee.Id}\n" +
                                        $"Фамилия: {employee.SecondName}\n" +
                                        $"Имя: {employee.FirstName}\n" +
                                        $"Возраст: {employee.Age}\n" +
                                        $"Проекты: {employee.Projects}\n" +
                                        $"Добавлен в отдел:\n" +
                                        $"Id отдела: {department.Id}\n" +
                                        $"Отдел: {department.DepartmentName}\n" +
                                        $"Основан: {department.CreationDate}\n" +
                                        $"Контингент: {department.Contingent}");
                                }
                                else
                                {
                                    Console.WriteLine($"Отдел {departmentName} не существует");
                                }
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case "3": //Редактирование отдела. Будем менять название отдела. Переименование отдела
                        {
                            {
                                Organization organization = new Organization();
                                organization.DepartmentsFromXmlToCollection();//Читаем список всех отделов из xml-файла в коллекцию
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
                            break;
                        }
                    case "4": //Редактирование сотрудника. Будем менять количество закрепленных за ним проектов
                        {
                            {
                                Organization organization = new Organization();
                                organization.EmployeesFromXmlToCollection(); //Читаем список всех отделов из xml-файла
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
                            break;
                        }
                    case "5": //Удаление данных об отделе и всех его сотрудников из соответствующих xml-файлов
                        {
                            {
                                Organization organization = new Organization();
                                Console.Write("Введите название отдела, в который хотите удалить: ");
                                string departmentName = Console.ReadLine();
                                Guid idDepartment = organization.DeleteDepartmentFromXml(departmentName);
                                organization.DeleteDepartmentEmployees(idDepartment);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case "6": //Удаление сотрудника их xml-файла
                        {
                            {
                                Organization organization = new Organization();
                                Console.Write("Введите имя или фамилию сотрудника, которого хотите удалить: ");
                                string employeeName = Console.ReadLine();
                                organization.DeleteEmployeeFromXml(employeeName);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case "7": //Поиск сотрудника. Возвращается первый найденный сотрудник
                        {
                            {
                                Organization organization = new Organization();
                                organization.EmployeesFromXmlToCollection();//Читаем список всех сотрудников из xml-файла
                                Console.Write("Введите имя или фамилию сотрудника: ");
                                string name = Console.ReadLine();

                                Employee _employee = organization.FindEmployee(name);
                                if (_employee != null)
                                {
                                    //Выводим на экран информацию о найденном сотруднике
                                    Console.WriteLine($"Результат поиска:\n{_employee}");
                                }
                                else
                                {
                                    Console.WriteLine($"Сотрудник с именем/фамилией {name} не найден");
                                }
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case "8"://Поиск отдела. Т.к. Название отдела уникально, то нет необходимости возвращать список отделов.
                            //Если отдел найден, то он один и данные о нём выводятся на экран
                        {
                            {
                                Organization organization = new Organization();
                                organization.DepartmentsFromXmlToCollection();//Читаем список всех отделов из xml-файла
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
                            break;
                        }
                    case "9":
                        {
                            break;
                        }
                    case "10":
                        {
                            break;
                        }
                    case "11":
                        {
                            break;
                        }
                    case "0":
                        {
                            break;
                        }
                }
            }
            #endregion

            #region
            //#region Выводим всю информацию об отделах и сотрудниках
            //{
            //    Console.WriteLine("Отделы:");
            //    Organization organization = new Organization();
            //    organization.DepartmentsFromXmlToCollection();//Читаем список отделов из xml-файла
            //    organization.ShowAllDepartments();//Выводим список всех отделов
            //    Console.ReadKey();
            //    Console.Clear();

            //    Console.WriteLine("Сотрудники:");
            //    organization.EmployeesFromXmlToCollection();//Читаем список сотрудников из xml-файла
            //    organization.ShowAllEmployees();//Выводим список всех сотрудников
            //    Console.ReadKey();
            //    Console.Clear();
            //}
            //#endregion

            //#region Поиск сотрудников или отделов
            //{ //Поиск отдела. Т.к. Название отдела уникально, то нет необходимости возвращать список отделов.
            //  //Если отдел найден, то он один и данные о нём выводятся на экран
            //    {
            //        Organization organization = new Organization();
            //        organization.DepartmentsFromXmlToCollection();//Читаем список всех отделов из xml-файла
            //        Console.WriteLine("Поиск отдела");
            //        Console.Write("Введите название отдела: ");
            //        string name = Console.ReadLine();
            //        Department _department = organization.FindDepartment(name);
            //        if (_department != null)
            //        {
            //            Console.WriteLine($"Результат поиска:\n{_department}");//Выводим на экран информацию о найденном отделе
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Отдел {name} не найден");
            //        }
            //        Console.ReadKey();
            //        Console.Clear();
            //    }

            //    //Поиск сотрудника. Возвращается первый найденный сотрудник
            //    {
            //        Organization organization = new Organization();
            //        organization.EmployeesFromXmlToCollection();//Читаем список всех сотрудников из xml-файла
            //        Console.Write("Введите имя или фамилию сотрудника: ");
            //        string name = Console.ReadLine();

            //        Employee _employee = organization.FindEmployee(name);
            //        if (_employee != null)
            //        {
            //            //Выводим на экран информацию о найденном сотруднике
            //            Console.WriteLine($"Результат поиска:\n{_employee}");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Сотрудник с именем/фамилией {name} не найден");
            //        }
            //        Console.ReadKey();
            //        Console.Clear();
            //    }
            //}
            //#endregion

            //#region Редактирование сотрудников или отделов
            //{ //Редактирование отдела. Будем менять название отдела.
            //  //Переименование отдела
            //    {
            //        Organization organization = new Organization();
            //        organization.DepartmentsFromXmlToCollection();//Читаем список всех отделов из xml-файла в коллекцию
            //        Console.WriteLine("Поиск отдела для переименования");
            //        Console.Write("Введите название отдела для переименования: ");
            //        string oldDepartmentName = Console.ReadLine();
            //        if (organization.FindDepartment(oldDepartmentName) != null)
            //        {
            //            Console.Write("Введите новое название отдела: ");
            //            string newDepartmentName = Console.ReadLine();
            //            organization.EditDepartment(oldDepartmentName, newDepartmentName);
            //            Console.WriteLine("Отдел успешно переименован");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Отдел с названием {oldDepartmentName} не найден");
            //        }
            //        Console.ReadKey();
            //        Console.Clear();
            //    }

            //    //Редактирование сотрудника. Будем менять количество закрепленных за ним проектов
            //    {
            //        Organization organization = new Organization();
            //        organization.EmployeesFromXmlToCollection(); //Читаем список всех отделов из xml-файла
            //        Console.WriteLine("Поиск сотрудника для измения количества проектов");
            //        Console.Write("Введите фамилию или имя сотрудника: ");
            //        string name = Console.ReadLine();
            //        if (organization.FindEmployee(name) != null)
            //        {
            //            Console.Write("Новое число проектов: ");
            //            int projects = int.Parse(Console.ReadLine());
            //            organization.EditEmployee(name, projects);
            //            Console.WriteLine($"Количество проектов сотрудника {name} изменено");

            //        }
            //        else
            //        {
            //            Console.WriteLine($"Сотрудник с фамилией или именем {name} не найден");
            //        }
            //        Console.ReadKey();
            //        Console.Clear();
            //    }
            //}
            //#endregion

            //#region Добавлние сотрудников и отделов
            //{ //Добавление нового сотрудника
            //    {
            //        Organization organization = new Organization();
            //        Console.Write("Введите название отдела, в который хотите добавить сотрудника: ");
            //        string departmentName = Console.ReadLine();
            //        Console.WriteLine("Введите данные о новом сотруднике");

            //        Console.Write("Фамилия: ");
            //        string secondName = Console.ReadLine();

            //        Console.Write("Имя: ");
            //        string firstName = Console.ReadLine();

            //        Console.Write("Возраст: ");
            //        int age = Byte.Parse(Console.ReadLine());

            //        Console.Write("Количество проектов: ");
            //        int projects = Byte.Parse(Console.ReadLine());

            //        //Создаём нового сотрудника
            //        Employee employee = new Employee(secondName, firstName, age, projects);

            //        //Добавляем нового сотрудника в существующий отдел в xml-файл
            //        organization.AddNewEmployeeToXml(employee, departmentName);

            //        Console.ReadKey();
            //        Console.Clear();
            //    }

            //    //Добавление нового отдела
            //    {
            //        Organization organization = new Organization();
            //        Console.Write("Введите название нового отдела: ");
            //        string name = Console.ReadLine();

            //        //Создаём новый отдел
            //        Department department = new Department(name, DateTime.Now);

            //        //Добавляем вновь созданный отдел в xml-файл
            //        organization.AddNewDepartmentToXml(department);
            //        Console.WriteLine(organization);
            //        Console.ReadKey();
            //        Console.Clear();
            //    }
            //}
            //#endregion

            //#region Удаление сотрудников и отделов
            //{ //Удаление данных об отделе из xml-файла
            //    {
            //        Organization organization = new Organization();
            //        Console.Write("Введите название отдела, в который хотите удалить: ");
            //        string departmentName = Console.ReadLine();
            //        Guid idDepartment = organization.DeleteDepartmentFromXml(departmentName);
            //        organization.DeleteDepartmentEmployees(idDepartment);
            //        Console.ReadKey();
            //        Console.Clear();
            //    }

            //    //Удаление сотрудника их xml-файла
            //    {
            //        Organization organization = new Organization();
            //        Console.Write("Введите имя или фамилию сотрудника, которого хотите удалить: ");
            //        string employeeName = Console.ReadLine();
            //        organization.DeleteEmployeeFromXml(employeeName);
            //        Console.ReadKey();
            //        Console.Clear();
            //    }

            //}
            //#endregion
            #endregion
        }
    }
}
