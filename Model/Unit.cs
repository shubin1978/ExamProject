namespace ProjectApp.Model;

public record Unit
{
    public int Id { get; set; }
    public string Cathegory { get; set; }

    public Unit(int id, string cathegory)
    {
        Id = id;
        Cathegory = cathegory;
    }

    public Unit()
    {
        
    }
}
