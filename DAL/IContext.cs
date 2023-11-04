using Object = ProjectApp.Model.Object;

namespace ProjectApp.DAL;

public interface IContext
{
    public List<Object> Objects { get; set; }

    public void ImportObjects();
    public void ExportObjects();
}