/// <summary>
/// A basic implementation of a FIFO Queue for Person objects
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    /// <summary>
    /// Get the number of people currently in the queue
    /// </summary>
    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the end of the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // Add to the end for FIFO behavior
    }

    /// <summary>
    /// Remove and return the person at the front of the queue
    /// </summary>
    public Person Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var person = _queue[0]; // Remove from the front
        _queue.RemoveAt(0);
        return person;
    }

    /// <summary>
    /// Check if the queue is empty
    /// </summary>
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    /// <summary>
    /// Safe string representation of the queue
    /// </summary>
    public override string ToString()
    {
        return $"PersonQueue (Count = {Length})";
    }
}

