using System.Text.Json.Serialization;

namespace ProjectApp.Model;

public record Profile
{
    public int At { get; set; }
    public string Title { get; set; }
    public string Position { get; set; }
    public Status Status { get; set; }
   
[JsonIgnore]
    public string FullInfo => $"{At}, {Title} --> [{Position}] : {Status} ";
}