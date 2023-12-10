namespace DataStructures.Utility;

public class ExponentialCapacityPredictor(int exponent = 2): IOptimalCapacityPredictor
{
    private readonly int Exponent = exponent;

    public int GetNewCapacity(int currentCapacity, int currentSize, int countOfElementsToBeAdded)
    {
        int newCapacityNeeded = currentSize + countOfElementsToBeAdded;
        
        if (newCapacityNeeded > currentCapacity)
        {
            return Math.Max(currentCapacity * this.Exponent, newCapacityNeeded);
        }
        else if(newCapacityNeeded < (currentCapacity / this.Exponent))
        {
            return currentCapacity / this.Exponent;
        }

        return currentCapacity;
    }
}
