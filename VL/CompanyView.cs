using System.Text.RegularExpressions;
using ProjectApp.Model;
using Object = ProjectApp.Model.Object;

namespace ProjectApp.CLI;

public static class CompanyView
{
    public static void ShowObject(Object? obj)
    {
        CLI.PrintInfo($"{obj.At} {obj.Title} : {obj.Position} -> {obj.Status}");
        foreach (var u in obj.Equipment)
        {
            CLI.PrintInfo($"{u.Cathegory }:{ u.Id}");
        }
    }

    public static void ShowObjects(List<Object?> objects)
    {
        foreach (var o in objects)
        {
            ShowObject(o);
        }
    }

    public static void PrintMenu()
    {
        CLI.PrintMenu("= M E N U = ");
        CLI.PrintMenu("1- Список всей техники");
        CLI.PrintMenu("2- Поиск объектов по локации");
        CLI.PrintMenu("3- Поиск объектов по номеру ");
        CLI.PrintMenu("4- Добавить объект");
        CLI.PrintMenu("5- Обновить статус");
        CLI.PrintMenu("6- Найти объект по номеру АТ");
        CLI.PrintMenu("0- Завершение работы ");
    }

    public static Object? NewObj(List<Object?> objects)
    {
        bool exit = true;
        var newObject = new Object();
        
        var regexp = @"^[0-9]{9}$";
        int number = Convert.ToInt32(Valid(regexp, "Введите номер АТ (9 зн.)"));
        
        bool cicle = objects.Exists(a => a.At == number);

        while (cicle)
        {
            var num = Convert.ToInt32(CLI.InputString("АТ с таким номером существует, введите заново")); 
            cicle = objects.Exists(a => a.At == num);
            number = num;  
        }

        newObject.At = number;
        newObject.Title = CLI.InputString("Введите название и гаражный номер");
        newObject.Position = CLI.InputString("Введите местоположение объекта");
        newObject.Status = Status.Avtive;
        newObject.Equipment = new List<Unit>();
        while (exit)
        {
            string yesNo = CLI.InputString("Добавить оборудование? Y / N");
            if (yesNo == "Y" || yesNo == "y")
            {
                var regexpUnit = @"^[0-9]{3}$";
                newObject.Equipment.Add(new Unit {
                    Cathegory = CLI.InputString("Введите категорию оборудования"),
                    Id = Convert.ToInt32(Valid(regexpUnit, "Введите номер оборудования (3 зн.)"))
                });
            }
            else
            {
                exit = false;
            }
        }
        return newObject;
    }
    
    public static string Valid(string regExp, string message)
    {
        bool exit = false;
        string str = null;
        do
        {
            var regexp = new Regex(regExp);
            str = CLI.InputString(message);
            exit = regexp.IsMatch(str);
        } while (!exit);

        return str;
    }
    
    public static int InputInt()
    {
        CLI.PrintInfo("Введите номер АТ");
        int number = 0;
        bool repeat = true;
        do
        {
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                repeat = false;
                return number;
            }
            catch (FormatException)
            {
                CLI.PrintError("Требуется вводить только цифры");
                CLI.PrintInfo("Повторите ввод:");
            }
            catch (OverflowException)
            {
                CLI.PrintError("Число слишком большое");
                CLI.PrintInfo("Повторите ввод:");
            }
            
        } while (repeat);

        return number;
    }
} 