namespace LeetCode;

public class RemoveDuplicatesFromArray
{
    /*
       Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.

        Consider the number of unique elements in nums to be k. After removing duplicates, return the number of unique elements k.

        The first k elements of nums should contain the unique numbers in sorted order. The remaining elements beyond index k - 1 can be ignored.

        Custom Judge:

        The judge will test your solution with the following code:

        int[] nums = [...]; // Input array
        int[] expectedNums = [...]; // The expected answer with correct length

        int k = removeDuplicates(nums); // Calls your implementation

        assert k == expectedNums.length;
        for (int i = 0; i < k; i++) {
            assert nums[i] == expectedNums[i];
        }
        If all assertions pass, then your solution will be accepted.
     */
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
