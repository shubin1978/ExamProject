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
   company.SortByAt();
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
   var newObject = CompanyView.NewObj(company.GetAllObjects());
   company.AddObject(newObject);
  }
   break;

  case "5":
  {
   var regexp = @"^[0-9]{9}$";
   int number = Convert.ToInt32(CompanyView.Valid(regexp, "Введите номер АТ (9 зн.)"));
   
   bool exitCicle = company.GetAllObjects().Exists(o => o.At == number);

   while (!exitCicle)
   {
    var num = Convert.ToInt32(CLI.InputString("АТ с таким номером не существует, введите заново")); 
    exitCicle = company.GetAllObjects().Exists(o => o.At == num);
    number = num;  
   }
   var regexp1 = @"^[0-2]{1}$";
   var newStatus = (Status)Convert.ToInt32(CompanyView.Valid(regexp1, "Введите статус: 0-Active," +
                                                                      " 1-Repair, 2-Conserve" ));
   company.UpdateStatus(number, newStatus);
  }
   break;

  case "6":
  {
   int numAt = CompanyView.InputInt();
   bool isNumAt = company.GetAllObjects().Exists(o => o.At == numAt);
   if (isNumAt)
   {
    CompanyView.ShowObject(company.FindObjectByAT(numAt));
   }
   else
   {
    CLI.PrintError("Объекта с таким АТ нет");
   }
   
  }
   break;
  
  default:
  {
   exit = true;
   break;
  }
 }
 
} while (!exit);
