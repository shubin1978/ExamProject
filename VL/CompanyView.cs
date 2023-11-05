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
        newObject.At = Convert.ToInt32(CLI.InputString("Введите номер терминала"));
        newObject.Title = CLI.InputString("Введите название и гаражный номер");
        newObject.Position = CLI.InputString("Введите местоположение объекта");
        newObject.Status = Status.Avtive;
        newObject.Equipment = new List<Unit>();
        while (exit)
        {
            string yesNo = CLI.InputString("Добавить оборудование? Y / N");
            if (yesNo == "Y" || yesNo == "y")
            {
                newObject.Equipment.Add(new Unit {
                    Cathegory = CLI.InputString("Введите категорию оборудования"),
                    Id = Convert.ToInt32(CLI.InputString("Введите номер"))
                });
            }
            else
            {
                exit = false;
            }
        }
        return newObject;
    }
} 