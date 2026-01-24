using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item and remove it
    // Expected Result: The single item is removed with its correct value
    // Defect(s) Found: N/A
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue<string>();
        priorityQueue.Enqueue("A", 1);  // Adding a single item
        var value = priorityQueue.Dequeue();  // Removing it
        Assert.AreEqual("A", value);   // Should return the same value we added
    }

    [TestMethod]
    // Scenario: Add multiple items with different priorities
    // Expected Result: Dequeue returns the item with the highest priority
    // Defect(s) Found: N/A
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue<string>();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);  // Highest priority
        priorityQueue.Enqueue("C", 2);

        var value = priorityQueue.Dequeue();
        Assert.AreEqual("B", value);    // B has the highest priority
    }

    [TestMethod]
    // Scenario: Multiple items with the same highest priority
    // Expected Result: The first item added with highest priority is dequeued first
    // Defect(s) Found: N/A
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue<string>();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);  // Same priority as A
        priorityQueue.Enqueue("C", 3);

        var value1 = priorityQueue.Dequeue();
        var value2 = priorityQueue.Dequeue();

        Assert.AreEqual("A", value1);   // A was added first, should come out first
        Assert.AreEqual("B", value2);   // B comes next
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Throws InvalidOperationException with proper message
    // Defect(s) Found: N/A
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue<string>();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);  // Must match exactly
    }

    [TestMethod]
    // Scenario: Multiple enqueue and dequeue sequence
    // Expected Result: Each Dequeue returns the correct highest-priority item in order
    // Defect(s) Found: N/A
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue<string>();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // B first of highest priority 3
        Assert.AreEqual("D", priorityQueue.Dequeue()); // D next of same priority 3
        Assert.AreEqual("C", priorityQueue.Dequeue()); // C with priority 2
        Assert.AreEqual("A", priorityQueue.Dequeue()); // A with priority 1
    }
}
