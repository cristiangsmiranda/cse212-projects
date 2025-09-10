using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Tests Dequeue order with different priorities and exception when empty
    // Expected Result: Elements are removed in the order B, C, A; exception at the end
    // Defect(s) Found: Fill in after running the tests
    public void TestPriorityQueue_EnqueueAndDequeue_1()
    {
        var pq = new PriorityQueue();
    
        pq.Enqueue("A", 1);   // Sends "A" with priority 1
        pq.Enqueue("B", 3);   // Sends "B" with priority 3
        pq.Enqueue("C", 2);   // Sends "C" with priority 2

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);

        result = pq.Dequeue();
        Assert.AreEqual("C", result);

        result = pq.Dequeue();
        Assert.AreEqual("A", result);

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_EnqueueAndDequeue_2()
    {
        var pq = new PriorityQueue();
    
        pq.Enqueue("D", 2);
        pq.Enqueue("E", 6);
        pq.Enqueue("F", 4);

        var result = pq.Dequeue();
        Assert.AreEqual("E", result);

        result = pq.Dequeue();
        Assert.AreEqual("F", result);

        result = pq.Dequeue();
        Assert.AreEqual("D", result);

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
}
