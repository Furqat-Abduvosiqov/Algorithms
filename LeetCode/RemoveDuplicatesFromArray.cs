namespace LeetCode;

public class RemoveDuplicatesFromArray
{
    public int RemoveDuplicates(int[] nums) {
        
        if (nums.Length == 0) return 0;
        
        int writeIndex = 1;
        
        for (int readIndex = 1; readIndex < nums.Length; readIndex++) {
            if (nums[readIndex] != nums[readIndex - 1]) {
                nums[writeIndex] = nums[readIndex];
                writeIndex++;
            }
        }
        
        return writeIndex;
    }
}

public static class ExampleUsage {
    
    public static void Example(){
        RemoveDuplicatesFromArray solution = new RemoveDuplicatesFromArray();
        
        int[] nums = [0,0,1,1,1,2,2,3,3,4];
        
        int k = solution.RemoveDuplicates(nums);
        
        Console.WriteLine("Length of array after removing duplicates: " + k);
        Console.Write("Array after removing duplicates: ");
        
        for (int i = 0; i < k; i++) {
            Console.Write(nums[i] + " ");
        }
    }
}
