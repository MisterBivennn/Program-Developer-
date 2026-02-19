using System;
using System.Buffers;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// Объявление класса, который является контейнером для кода
class Program
{
    // Точка входа в программу, с которой начинается выполнение
    static void Main(string[] args)
    {
        Developer Murad = new Developer();
        Murad.Age = 30;
        Murad.Name = "Расулов Гаджимурад Зайнутдинович";
        Murad.Salary = 250000;
        Murad.Skill = "Фулл Стек(бэкенд и фронтенд)";
        Murad.Stack = "C#, C++, Python, PHP, TypeScript";
        Murad.PerformDuties();

        Manager Denikin = new Manager();
        Denikin.Age = 25;
        Denikin.Name = "Деникин Антон Иванович";
        Denikin.Salary = 190000;
        Denikin.KPI = 70;
        Denikin.Project = "Вооружённые Силы Юга России, битва против Большевиков за судьбу России(провал...). Отказ сотрудничать с нацистами, когда нацистская Германия напала на СССР(успех, не предал Родину)";
        Denikin.PerformDuties();
    } 
}
abstract class Employee
{
    public int Age;
    public string Name;
    public int Salary;

}
class Developer : Employee
{
    public string Skill;

    public string Stack;

    public void PerformDuties()
    {
        Console.WriteLine($"Главный Разработчик: {Name}. Возраст: {Age}. Заработная плата: {Salary}. Его навыки: {Skill}. Его знания: {Stack}.");
    }
}
class Manager : Employee
{
    public int KPI;

    public string Project;

    public void PerformDuties()
    {
        Console.WriteLine($"Менеджер: {Name}. Возраст: {Age}. Заработная плата: {Salary}. Эффективность {KPI} / 100. Проекты: {Project}.");
    }
}
class Department
{
    public Employee[] Employs = new Employee[10];

    public void addEmployee()
    {
        
    }
    public void deleteEmployee()
    {
        
    }
    public void displayInfo()
    {
        
    }
}