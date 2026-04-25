#nullable disable// Отключаем придирки компилятора к строкам
using System; //Использование системы

class Program//Основной класс
{
    static void Main(string[] args)//Main, основное рабочее пространство
    {
        Department itDept = new Department();//Создание департамента

        while(true)//Цикл while для работы программы
        {
        Console.ForegroundColor = ConsoleColor.Yellow;//Установка жёлтого цвета для программы
        Console.WriteLine("Кого добавим? 1 - разработчик, 2 - менеджер, 3 - список сотрудников, 4 - удалить.");//Управление    
        string choice = Console.ReadLine();//Считывание "хода"

        if (choice == "1")//Если выбрано 1
        {
            Developer dev = new Developer();//Создание нового разработчика
            Console.Write("Введите имя: ");//Ввод имени
            dev.Name = Console.ReadLine();//Считывание имени разработчика

            Console.Write("Введите возраст: ");//Ввод возраств
            dev.Age = int.Parse(Console.ReadLine()); //Превращение введённого в число

            Console.Write("Введите ЗП: ");//Ввод зарплаты
            dev.Salary = int.Parse(Console.ReadLine()); //Превращение введённого в число

            Console.Write("Введите Стек: ");//Ввод стека(frontend/backend/fullstack)
            dev.Stack = Console.ReadLine();//Считывание стека

            itDept.addEmployee(dev);//Добавление разработчика в itDept
        }
        else if (choice == "2")//Если выбрано 2
        {
            Manager man = new Manager();//Создание нового менеджера
            Console.Write("Введите имя: ");//Ввод имени
            man.Name = Console.ReadLine();//Считывание имени менеджера

            Console.Write("Введите возраст: ");//Ввод возраста
            man.Age = int.Parse(Console.ReadLine());//Превращение введённого в число

            Console.Write("Введите ЗП: ");//Ввод зарплаты
            man.Salary = int.Parse(Console.ReadLine());//Превращение введённого в число

            Console.Write("Введите KPI(0-100): ");//Ввод эффективности(KPI) менеджера
            man.KPI = int.Parse(Console.ReadLine());//Превращение введённого в число

            Console.Write("Введите Проект: ");//Ввод проекта, которым руководит менеджер
            man.Project = Console.ReadLine();//Считывание названия проекта

            itDept.addEmployee(man);//Добавление менеджера в itDept
        }
        else if (choice == "3")//Если выбрано 3
        {
        itDept.displayInfo();//Вывести на экран информацию о сотрудниках
        }
        else if (choice == "4")//Если выбрано 4
        {
            Console.Write("Введите имя сотрудника для удаления: ");//Ввод имени сотрудника для удаления
            string nameForDelete = Console.ReadLine();//Считывание
            itDept.deleteEmployee(nameForDelete);//Вызов функции Delete
        }
        Console.ResetColor();//Сброс цвета
        }
    } 
}

abstract class Employee//Класс Добавления
{
    public int Age;//Возраст
    public string Name;//Имя
    public int Salary;//Зарплата

    public virtual void ShowFullInfo()//Показать всю информацию
    {
        Console.Write($"Имя: {Name} | Возраст: {Age} | ЗП: {Salary}");//Характеристики сотрудников
    }
}

class Developer : Employee//Разработчик
{
    public string Skill;//Навыки
    public string Stack;//Стек в программировании

    public override void ShowFullInfo()//Показать всю информацию
    {
        base.ShowFullInfo();//Вызов показа общей информации
        Console.WriteLine($" | Стек: {Stack} (Разработчик)");//Показ стека разработчика
    }
}

class Manager : Employee//Менеджер
{
    public int KPI;//КПд(KPI)/Эффективность
    public string Project;//Проект, который ведёт менеджер

    public override void ShowFullInfo()//Показать всю инфу менеджера
    {
        base.ShowFullInfo();//Показать общую информацию
        Console.WriteLine($" | KPI: {KPI} | Проект: {Project} (Менеджер)");//Показать KPI и проект менеджера
    }
}

class Department//Департамент
{
    public Employee[] Employs = new Employee[10];//Создание массива

    public void addEmployee(Employee emp)//Функция добавления
    {
        for (int i = 0; i < Employs.Length; i++)//Цикл for, пока i < Employs.Length, то есть 10
        {
            if (Employs[i] == null)//Если Employs = null
            {
                Employs[i] = emp;//Создание общего индекса для добавленных сотрудников
                Console.ForegroundColor = ConsoleColor.Green;//Присвоение зелёного цвета для успешной процедуры
                Console.WriteLine("Добавлено!");//Вывод, что вся инфа добавлена
                Console.ResetColor();//Сброс цвета
                return;//Возврат в главное меню
            }
        }
    }

    public void deleteEmployee(string name)//Функция удаления
    {
        for (int i = 0; i < Employs.Length; i++)//Цикл for, пока i < Employs.Length, то есть 10
        {          
            if (Employs[i] != null && Employs[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))//Проверка того, что ячейка не пустая и имя совпадает
            {
                Console.ForegroundColor = ConsoleColor.Green;//Присвоение зелёного цвета для успешной процедуры
                Console.WriteLine($"Сотрудник {Employs[i].Name} удален из системы.");//Если сотрудник с введённым именем найден
                Employs[i] = null;//Очистка ячейки
                Console.ResetColor();//Сброс цвета
                return;//Выход из метода
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;//Присвоение красного цвета ошибке
        Console.WriteLine($"Ошибка: Сотрудник с именем '{name}' не найден.");//Если сотрудник не найден
        Console.ResetColor();//Сброс цвета
    }

    public void displayInfo()//Функция вывода
    {
        Console.WriteLine("\n======= СПИСОК СОТРУДНИКОВ =======");//Список
        int count = 1;//Переменная для номера сотрудника
        foreach (var emp in Employs)//Цикл foreach для вывода добавленных сотрудников
        {
            if (emp != null)//Условие, что emp неравно null
            {
                Console.Write($"{count}. ");//Номер для красоты
                emp.ShowFullInfo();//Показывает нижнюю версию метода
                count++;//Добавление индекса, чтобы синдексы сотрудников показывались поочереди
            }
        }
        
        if (count == 1) Console.WriteLine("В отделе пусто.");//Если сотрудников нет
        Console.WriteLine("==================================\n");//Для красоты
    }
}
