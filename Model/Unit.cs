namespace ProjectApp.Model;

public record Unit
{
    public int Id { get; init; }
    public string Cathegory { get; init; }

    public Unit(int id, string cathegory)
    {
        Id = id;
        Cathegory = cathegory;
    }
}