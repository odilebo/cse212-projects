public class PriorityQueue<T>
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(T value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode); // Always add to the back
    }

    public T Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        // If multiple items have the same priority, remove the first one (FIFO)
        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // fixed loop condition
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
            // Do not change highPriorityIndex if equal; preserves FIFO
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // Actually remove the item from the queue
        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }

    // Internal class representing each queue item
    internal class PriorityItem
    {
        internal T Value { get; set; }
        internal int Priority { get; set; }

        internal PriorityItem(T value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        // DO NOT MODIFY THE CODE IN THIS METHOD
        // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }
}
