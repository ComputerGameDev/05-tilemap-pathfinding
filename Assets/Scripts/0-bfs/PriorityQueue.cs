using System.Collections.Generic;

public class PriorityQueue<T>
{
    private readonly List<(T Item, int Priority)> heap = new();

    public int Count => heap.Count;

    public void Enqueue(T item, int priority)
    {
        heap.Add((item, priority));
        int currentIndex = heap.Count - 1;

        // Heapify up
        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            if (heap[currentIndex].Priority >= heap[parentIndex].Priority)
                break;

            // Swap
            (heap[currentIndex], heap[parentIndex]) = (heap[parentIndex], heap[currentIndex]);
            currentIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (heap.Count == 0)
            throw new System.InvalidOperationException("The priority queue is empty.");

        T rootItem = heap[0].Item;
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);

        // Heapify down
        int currentIndex = 0;
        while (currentIndex < heap.Count)
        {
            int leftChildIndex = 2 * currentIndex + 1;
            int rightChildIndex = 2 * currentIndex + 2;
            int smallestIndex = currentIndex;

            if (leftChildIndex < heap.Count && heap[leftChildIndex].Priority < heap[smallestIndex].Priority)
                smallestIndex = leftChildIndex;
            if (rightChildIndex < heap.Count && heap[rightChildIndex].Priority < heap[smallestIndex].Priority)
                smallestIndex = rightChildIndex;

            if (smallestIndex == currentIndex)
                break;

            // Swap
            (heap[currentIndex], heap[smallestIndex]) = (heap[smallestIndex], heap[currentIndex]);
            currentIndex = smallestIndex;
        }

        return rootItem;
    }
}
