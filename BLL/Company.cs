using System.Runtime.InteropServices.JavaScript;
using ProjectApp.DAL;
using ProjectApp.Model;
using Object = ProjectApp.Model.Object;

namespace ProjectApp.BLL;

public class Company
{
    private readonly IContext _context;

    public Company(IContext context)
    {
        _context = context;
        _context.ImportObjects();
    }

    #region Objects

    public List<Object> GetAllObjects() => _context.Objects;
    public List<Object> FindObjectByPlace(string pos) => _context.Objects.Where
        (o => o.Position.Contains(pos)).ToList();

    public List<Object> FindObjectsByTitle(string title) => (from obj in _context.Objects
        where obj.Title.Contains(title)
        select obj).ToList();

    public void AddObject(Object obj)
    {
        _context.Objects.Add(obj); 
        _context.ExportObjects();
    }

    public void UpdateStatus(int at, Status newStatus)
    {
        var obj = _context.Objects.Find(o => o.At == at);
        obj.Status = newStatus;
        _context.ExportObjects();
    }

    #endregion
}