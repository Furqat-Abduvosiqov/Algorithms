namespace LeetCodeProblems;

public class DuplicateFinder
{
    // Using HashSet - O(n) time, O(n) space
    public static List<int> FindDuplicates(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        
        var seen = new HashSet<int>();
        var duplicates = new HashSet<int>();
        
        foreach (int num in array)
        {
            if (seen.Contains(num))
            {
                duplicates.Add(num); // Only add once to avoid multiple entries
            }
            else
            {
                seen.Add(num);
            }
        }
        
        return duplicates.ToList();
    }
    
    // For array of chars
    public static List<char> FindDuplicateChars(char[] chars)
    {
        if (chars == null)
            throw new ArgumentNullException(nameof(chars));
        
        var seen = new HashSet<char>();
        var duplicates = new HashSet<char>();
        
        foreach (char c in chars)
        {
            if (seen.Contains(c))
            {
                duplicates.Add(c);
            }
            else
            {
                seen.Add(c);
            }
        }
        
        return duplicates.ToList();
    }
    
    // Using Dictionary to count occurrences
    public static Dictionary<int, int> CountOccurrences(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        
        var counts = new Dictionary<int, int>();
        
        foreach (int num in array)
        {
            if (counts.ContainsKey(num))
            {
                counts[num]++;
            }
            else
            {
                counts[num] = 1;
            }
        }
        
        return counts;
    }
    
    // LINQ approach - more concise but potentially less efficient
    public static List<int> FindDuplicatesLinq(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        
        return array.GroupBy(x => x)
                   .Where(g => g.Count() > 1)
                   .Select(g => g.Key)
                   .ToList();
    }
    
    // Find all duplicate elements with their counts
    public static Dictionary<int, int> FindDuplicatesWithCounts(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        
        return array.GroupBy(x => x)
                   .Where(g => g.Count() > 1)
                   .ToDictionary(g => g.Key, g => g.Count());
    }
    
    public static void Demonstrate()
    {
        Console.WriteLine("\n=== Duplicate Finder Demo ===");
        
        // Test with integers
        int[] numbers = { 1, 2, 3, 2, 4, 5, 3, 6, 1, 7, 8, 1 };
        Console.WriteLine($"Numbers array: [{string.Join(", ", numbers)}]");
        
        var duplicates = FindDuplicates(numbers);
        Console.WriteLine($"Duplicate numbers: [{string.Join(", ", duplicates)}]");
        
        var counts = CountOccurrences(numbers);
        Console.WriteLine("Number counts:");
        foreach (var kvp in counts.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"  {kvp.Key}: appears {kvp.Value} times");
        }
        
        var duplicatesWithCounts = FindDuplicatesWithCounts(numbers);
        Console.WriteLine("Duplicates with counts:");
        foreach (var kvp in duplicatesWithCounts)
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value} times");
        }
        
        // Test with characters
        char[] characters = { 'a', 'b', 'c', 'a', 'd', 'b', 'e', 'f', 'a' };
        Console.WriteLine($"\nCharacters array: [{string.Join(", ", characters)}]");
        
        var charDuplicates = FindDuplicateChars(characters);
        Console.WriteLine($"Duplicate characters: [{string.Join(", ", charDuplicates)}]");
        
        // LINQ approach
        var linqDuplicates = FindDuplicatesLinq(numbers);
        Console.WriteLine($"LINQ duplicates: [{string.Join(", ", linqDuplicates)}]");
    }
}