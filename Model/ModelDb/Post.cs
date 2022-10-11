using System.Collections.Generic;

namespace AutoSound.Model.ModelDb;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public List<Employee> Employees { get; set; } = null!;
}
