namespace Orchestrator.Models;

public class Queue
{
    public string ProductTitle { get; set; }
    public List<User> Users { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
