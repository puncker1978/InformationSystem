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
                        Employee employee = new Employee($"Фамилия {KantorPairs(i, j)}",
                            $"Имя {KantorPairs(i, j)}", rnd.Next(18, 70), rnd.Next(1, 3));

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

            {
                Organization organization = new Organization();
                organization.DepartmentsFromXml();
                Console.WriteLine(organization.Departments);
                Console.ReadKey();
                Console.Clear();
                
                organization.EmployeesFromXml();
                Console.WriteLine(organization.Employees);
                Console.ReadKey();
            }


            //#region Поиск сотрудников или отделов
            ////Поиск отдела
            //{
            //    Console.WriteLine("Поиск отдела");
            //    Console.Write("Введите название отдела: ");
            //    string name = Console.ReadLine();
            //    Department _department = organization.FindDepartment(name);
            //    if (_department != null)
            //    {
            //        Console.WriteLine($"Результат поиска:\n{_department}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Отдел {name} не найден");
            //    }
            //    Console.ReadKey();
            //    Console.Clear();
            //}

            ////Поиск сотрудника
            //{
            //    Console.Write("Введите имя или фамилию сотрудника: ");
            //    string name = Console.ReadLine();
            //    Employee _employee = organization.FindEmployee(name);
            //    if (_employee != null)
            //    {
            //        Console.WriteLine($"Результат поиска:\n{_employee}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Сотрудник с именем/фамилией {name} не найден");
            //    }
            //    Console.ReadKey();
            //    Console.Clear();
            //}
            //#endregion

            //#region Редактирование сотрудников или отделов
            ////Редактирование отдела. Будем менять название отдела
            ////Метод для переименования отделов
            //{
            //    //Console.WriteLine(organization);

            //    //Console.Write("Введите название отдела, для которого хотите поменять название: ");
            //    //string name = Console.ReadLine();

            //    ////Находим отдел с соответствующим именем
            //    //Department _department = organization.FindDepartment(name);

            //    ////Выводим информацию об имеющемся отделе
            //    //if (_department != null)
            //    //{
            //    //    Console.WriteLine($"Информация об отделе:\n{_department}\n");
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine($"Отдел {name} не найден");
            //    //}

            //    //Console.Write("Введите новое название отдела: ");
            //    //string newDepartmentName = Console.ReadLine();
            //    ////Меняем информацию об отделе
            //    //_department.EditDepartment(newDepartmentName);

            //    //Console.WriteLine($"Изменённый отдел:\n{_department}");
            //    //Console.ReadKey();
            //    //Console.Clear();
            //    //Console.WriteLine(organization);
            //    //Console.ReadKey();
            //    //Console.Clear();
            //}

            ////Редактирование сотрудника. Будем менять количество закрепленных за ним проектов
            ////Метод переименования сотрудника
            //{
            //    //Console.WriteLine(organization);
            //    //Console.Write("Введите имя или фамилию сотрудника для которого будем менять" +
            //    //    "количество закреплённых за ним проектов: ");
            //    //string name = Console.ReadLine();

            //    ////Находим сотрудника с соответствующим именем или
            //    ////фамилией и выводим информацию об этом сотруднике
            //    //Employee _employee = organization.FindEmployee(name);

            //    //Console.Write("Введите новое количество проектов: ");
            //    //int newProjects = int.Parse(Console.ReadLine());
            //    ////Меняем информацию о сотруднике
            //    //_employee.EditEmployee(newProjects);

            //    //Console.WriteLine($"Обновлённая информация о сотруднике:\n{_employee}");
            //    //Console.ReadKey();
            //    //Console.Clear();
            //    //Console.WriteLine(organization);
            //    //Console.ReadKey();
            //    //Console.Clear();
            //}

            //#endregion

            ////Удаление отдела
            //{
            //    Console.WriteLine(organization);
            //    Console.Write("Введите название отдела для удаления: ");
            //    string name = Console.ReadLine();
            //    organization.DeleteDepartment(name);
            //    Console.WriteLine(organization);
            //    Console.ReadKey();
            //    Console.Clear();
            //}

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
