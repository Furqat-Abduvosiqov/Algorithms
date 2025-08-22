namespace LeetCode;

public class ArrayDeletion
{
    // Method 1: Create new array without deleted elements
    public static int[] DeleteRange(int[] array, int startIndex, int endIndex)
    {
        CheckInput(array, startIndex, endIndex);
        
        // Calculate new size
        int elementsToDelete = endIndex - startIndex + 1;
        int newSize = array.Length - elementsToDelete;
        
        // Create result array
        int[] result = new int[newSize];
        
        // Copy elements before the range to delete
        for (int i = 0; i < startIndex; i++)
        {
            result[i] = array[i];
        }
        
        // Copy elements after the range to delete
        for (int i = endIndex + 1; i < array.Length; i++)
        {
            result[startIndex + (i - endIndex - 1)] = array[i];
        }
        
        return result;
    }
    
    // Method 2: Using LINQ (more readable but potentially slower)
    public static int[] DeleteRangeLinq(int[] array, int startIndex, int endIndex)
    {
        CheckInput(array, startIndex, endIndex);
        
        return array.Take(startIndex)
            .Concat(array.Skip(endIndex + 1))
            .ToArray();
    }
    
    // Method 3: In-place deletion with shifting (modifies original array)
    public static int[] DeleteRangeInPlace(int[] array, int startIndex, int endIndex)
    {
        CheckInput(array, startIndex, endIndex);

        int elementsToDelete = endIndex - startIndex + 1;
        
        // Shift elements to the left
        for (int i = endIndex + 1; i < array.Length; i++)
        {
            array[i - elementsToDelete] = array[i];
        }
        
        // Return array with new logical length
        int[] result = new int[array.Length - elementsToDelete];
        Array.Copy(array, result, result.Length);
        return result;
    }

    private static void CheckInput(int[] array, int startIndex, int endIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (startIndex < 0 || endIndex >= array.Length || startIndex > endIndex)
            throw new ArgumentException("Invalid range specified");
    }

    public static void Demonstrate()
    {
        Console.WriteLine("=== Array Deletion Demo ===");
        
        int[] original = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine($"Original array: [{string.Join(", ", original)}]");
        
        // Delete elements from index 2 to 5 (elements 3, 4, 5, 6)
        int[] result1 = DeleteRange(original, 2, 5);
        Console.WriteLine($"After deleting indices 2-5: [{string.Join(", ", result1)}]");
        
        // Reset original array for next demo
        original = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] result2 = DeleteRangeLinq(original, 2, 5);
        Console.WriteLine($"LINQ method result: [{string.Join(", ", result2)}]");
        
        // Reset original array for in-place demo
        original = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] result3 = DeleteRangeInPlace(original, 2, 5);
        Console.WriteLine($"In-place method result: [{string.Join(", ", result3)}]");
    }
}