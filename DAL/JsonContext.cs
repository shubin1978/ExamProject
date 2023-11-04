using System.Runtime.InteropServices.JavaScript;
using System.Text.Encodings.Web;
using System.Text.Json;
using Object = ProjectApp.Model.Object;

namespace ProjectApp.DAL;

public class JsonContext : FileContext, IContext
{ 
    public List<Object> Objects { get; set; }
    public event Action<string> Log;
    private readonly JsonSerializerOptions _options;
    
    public JsonContext(string pathToObjects) : base(pathToObjects)
    //формируется автоматически при имплементации
    {
        Objects = new List<Object>();
        
        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }
    
    public void ImportObjects()
    {
        var objectJson = File.ReadAllText(PathToObjects);
        Log?.Invoke("Данные из файла считались");
        Objects = JsonSerializer.Deserialize<List<Object>>(objectJson);
        Log?.Invoke("Десериализация удалась");
    }

    public void ExportObjects()
    {
        var objectsJson = JsonSerializer.Serialize(Objects, _options);
        File.WriteAllText(PathToObjects,objectsJson);
        Log?.Invoke("Данные успешно записаны в файл");
    }
} 
