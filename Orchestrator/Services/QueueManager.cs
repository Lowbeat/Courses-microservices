using Orchestrator.Models;
using SharedModels;

namespace Orchestrator.Services;

public class QueueManager
{
    private readonly List<Queue> _queues = new()
    {
        new Queue { ProductTitle = "King Arthur's sword", Users = new List<User>{ new User{ Id = 1, Name = "John"}, new User{ Id = 2, Name = "Alice"} } },
        new Queue { ProductTitle = "Empress skin", Users = new List<User>{ new User{ Id = 3, Name = "Bob"}, new User{ Id = 4, Name = "Jane"} } }
    };

    public void ProcessProductEvent(ProductAvailabilityEvent availabilityEvent)
    {
        var queue = _queues.FirstOrDefault(q => q.ProductTitle == availabilityEvent.ProductTitle);
        if (queue != null)
        {
            var user = queue.Users.FirstOrDefault(u => u.Id == availabilityEvent.UserId);
            if (user != null)
            {
                Console.WriteLine();
                queue.Users.Remove(user);
                queue.Users.Add(user);
                Console.WriteLine($"{user.Name} got the {queue.ProductTitle}. Queue updated.");
                Console.WriteLine($"Current queue:\n{string.Join("\n", queue.Users.Select(x => "Id = '" + x.Id + "' Name = '" + x.Name + "'"))}");
            }
        }
    }

    public List<Queue> GetAllQueues()
    {
        return _queues;
    }
}
