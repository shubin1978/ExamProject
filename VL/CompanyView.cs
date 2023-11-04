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
} 