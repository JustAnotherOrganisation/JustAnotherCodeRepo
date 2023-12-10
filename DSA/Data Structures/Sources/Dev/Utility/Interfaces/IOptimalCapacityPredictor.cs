namespace DataStructures.Utility;

/// <summary>
/// Given current capacity, current size and number of elements to be added/removed
/// this interface returns the new optimal capacity to be set.
/// </summary>
public interface IOptimalCapacityPredictor
{
    public int GetNewCapacity(int currentCapacity, int currentSize, int countOfElementsToBeAdded);
}
