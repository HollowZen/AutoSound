namespace AutoSound.Model.ModelDb;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SurName { get; set; } = null!;
    public string? SecondName { get; set; }
    public int PostId { get; set; }
    public virtual Post Post { get; set; } = null!;
    public int SecurityId { get; set; }
    public virtual Security Security { get; set; } = null!;
}
