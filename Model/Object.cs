namespace ProjectApp.Model;

public record Object(): Profile
{
    public List<Unit>? Equipment { get; set; }
}