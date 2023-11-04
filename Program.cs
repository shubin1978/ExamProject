using ProjectApp.BLL;
using ProjectApp.CLI;
using ProjectApp.DAL;
using ProjectApp.Model;
using Object = ProjectApp.Model.Object;

var jsonContext = new JsonContext("objects.json");
jsonContext.Log += CLI.LogToConsole;
var company = new Company(jsonContext);

bool exit = false;
do
{
 CompanyView.PrintMenu();
 var input = CLI.InputString("Введите пункт меню ");
 switch (input)
 {
  case "0":
   exit = true;
   break;
  
  case "1":
  {
   var objects = company.GetAllObjects();
   CompanyView.ShowObjects(objects);
  }
   break;
  
  case "2":
  {
   var position = CLI.InputString("Введите локацию для поиска");
   var listObjectsLocation = company.FindObjectByPlace(position);
   CompanyView.ShowObjects(listObjectsLocation);
  }
   break;

  case "3":
  {
   var title = CLI.InputString("Введите номер объекта для поиска");
   var objectTitle = company.FindObjectsByTitle(title);
   CompanyView.ShowObjects(objectTitle);
  }
   break;

  case "4":
  {
   var newObject = new Object();
   newObject.At = Convert.ToInt32(CLI.InputString("Введите номер терминала"));
   newObject.Title = CLI.InputString("Введите название и гаражный номер");
   newObject.Position = CLI.InputString("Введите местоположение объекта");
   newObject.Status = Status.Avtive;
   newObject.Equipment = new List<Unit>
   {
    new Unit(5555, "LLS5")
   };
   company.AddObject(newObject);
  }
   break;
 }
} while (!exit);


/*context.Objects = new List<Object>
{
 new()
 {
  At = 326001010,
  Title = "PC-400_#605",
  Position = "Quarry",
  Status = Status.Avtive,
  Equipment = new List<Unit>
  {
   new Unit(2222, "LLS4"),

   new Unit(2223, "LLS4")
  }
 }
};*/

/*var objects = company.GetAllObjects();
CompanyView.ShowObjects(objects);
var position = CLI.InputString("Введите локацию для поиска");
var listObjectsLocation = company.FindObjectByPlace(position);
CompanyView.ShowObjects(listObjectsLocation);
var title = CLI.InputString("Введите номер объекта для поиска");
var objectTitle = company.FindObjectsByTitle(title);
CompanyView.ShowObjects(objectTitle);*/

/*foreach (var item in objects)
{
 Console.WriteLine($"{item.At} {item.Title} --> {item.Position} : {item.Status}");
 Console.WriteLine("   EQUIPMENT :");
 foreach (var u in item.Equipment)
 {
  Console.WriteLine($"\t{u.Cathegory} # {u.Id}");
 }
}*/