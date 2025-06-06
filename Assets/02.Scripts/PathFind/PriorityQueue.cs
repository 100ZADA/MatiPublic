using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<KeyValuePair<T, float>> elements = new();

    public int Count => elements.Count;

    public void Enqueue(T item, float priority)
    {
        elements.Add(new KeyValuePair<T, float>(item, priority));
    }

    public T Dequeue()
    {
        int bestIndex = 0;
        float bestPriority = elements[0].Value;

        for (int i = 1; i < elements.Count; i++)
        {
            if (elements[i].Value < bestPriority)
            {
                bestPriority = elements[i].Value;
                bestIndex = i;
            }
        }

        T bestItem = elements[bestIndex].Key;
        elements.RemoveAt(bestIndex);
        return bestItem;
    }

    public bool Contains(T item)
    {
        foreach (var pair in elements)
        {
            if (EqualityComparer<T>.Default.Equals(pair.Key, item))
                return true;
        }
        return false;
    }
}
