using DataStructures.Utility;

namespace DataStructures;

/// <summary>
/// Creates a dynamic array for storing objects of type T
/// </summary>
/// <typeparam name="T"></typeparam>
public class Array<T>(int n = 0, IOptimalCapacityPredictor? optimalCapacityPredictor = null)
{
    private T[] Values = new T[n];

    private int Capacity = n;

    private int Size = 0;

    private readonly IOptimalCapacityPredictor CapacityPredictor = optimalCapacityPredictor ?? new ExponentialCapacityPredictor();

    public void Insert(T item, int index)
    {
        int newCapacityNeeded = this.CapacityPredictor.GetNewCapacity(
            currentCapacity: this.Capacity,
            currentSize: this.Size,
            countOfElementsToBeAdded: 1);

        if (newCapacityNeeded == this.Capacity)
        {
            this.Size++;
            T elementToBeAdded = item;
            T currentElement;

            for (int i = index; i < this.Size; i++)
            {
                currentElement = Values[i];
                Values[i] = elementToBeAdded;
                elementToBeAdded = currentElement;
            }
        }
        else if (newCapacityNeeded > this.Capacity)
        {
            this.Size++;
            this.Capacity = newCapacityNeeded;
            T[] newValues = new T[this.Capacity];
            int currentIndex = 0;

            for (; currentIndex < index; currentIndex++)
            {
                newValues[currentIndex] = this.Values[currentIndex];
            }

            newValues[currentIndex++] = item;

            for (; currentIndex < this.Size; currentIndex++)
            {
                newValues[currentIndex] = this.Values[currentIndex-1];
            }

            this.Values = newValues;
        }
        else
        {
            throw new Exception(
                message: $"{nameof(this.CapacityPredictor)} has an issue," +
                $"new capacity cannot be smaller than original capacity in insertion");
        }
    }
}
