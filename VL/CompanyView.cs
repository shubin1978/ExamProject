using System.Text.RegularExpressions;
using ProjectApp.Model;
using Object = ProjectApp.Model.Object;

namespace ProjectApp.CLI;

public static class CompanyView
{
    public static void ShowObject(Object obj)
    {
        CLI.PrintInfo($"{obj.At} {obj.Title} : {obj.Position} -> {obj.Status}");
        foreach (var u in obj.Equipment)
        {
            CLI.PrintInfo($"{u.Cathegory }:{ u.Id}");
        }
    }

    public static void ShowObjects(List<Object> objects)
    {
        foreach (var o in objects)
        {
            ShowObject(o);
        }
    }

    public static void PrintMenu()
    {
        CLI.PrintInfo("= M E N U = ");
        CLI.PrintInfo("1- Список всей техники");
        CLI.PrintInfo("2- Поиск объектов по локации");
        CLI.PrintInfo("3- Поиск объектов по номеру ");
        CLI.PrintInfo("4- Добавить объект");
        CLI.PrintInfo("0- Завершение работы ");
    }

    public static Object NewObj()
    {
        bool exit = true;
        var newObject = new Object();
        
        var regexp = @"^[0-9]{9}$";
        newObject.At = Convert.ToInt32(Valid(regexp));
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
                    Id = Convert.ToInt32(Valid(regexpUnit))
                });
            }
            else
            {
                exit = false;
            }
        }
        return newObject;
    }
    
    public static string Valid(string regExp)
    {
        bool exit = false;
        string str = null;
        do
        {
            var regexp = new Regex(regExp);
            str = CLI.InputString("Введите номер:");
            exit = regexp.IsMatch(str);
        } while (!exit);

        return str;
    }
    public static bool Validation2 (string str, string regExp)
    {
        var regexp = new Regex(regExp);
        return regexp.IsMatch(str);
    }
    
} 