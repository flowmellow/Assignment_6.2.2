/*
Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
You must write an algorithm that runs in O(n) time and without using the division operation.

Example 1:

Input: nums = [1,2,3,4]
Output: [24,12,8,6]
Example 2:

Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]
*/

using System.Security.Cryptography.X509Certificates;

namespace Assignment_6._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 }; // hard coding an array to pass into the method

            //int[] nums = { -1, 1, 0, -3, 3 }; // hard coding an array to pass into the method

            ProductOfArrayExceptSelf productOfArrayExceptSelf = new ProductOfArrayExceptSelf(); // instantiating the class

            int[] result = productOfArrayExceptSelf.ProductExceptSelf(nums); // passing in the nums array as an argument then assigning it to the array result

            foreach (int num in result) // printing each element in the result array.
            {
                Console.WriteLine(num);
            }
 
        }

        class ProductOfArrayExceptSelf // establish a class to pass in arguments to the method
        {
            public int[] ProductExceptSelf(int[] nums) // 
            {
                int[] result = new int[nums.Length]; // establishing a new array to pass in results of products from nums array
                result[0] = 1; // result[0] is set to 1 because there are no elements to the left of the first element. Assigns 1 to index 0; result {1, 0 , 0, 0} because you have to start with a value and identity principle applies.

                for (int i = 1; i < nums.Length; i++) // starting at index 1 so only 3 iterations not including 0 index in the calculation
                {
                    result[i] = result[i - 1] * nums[i - 1];
                    //   iteration1 is   1 = (result0)1 * 1 which is {1, 1 , 0, 0}
                    //   iteration2 is 2 = (it1)1 * 2 which is {1, 1 , 2, 0}
                    //  iteration3 is 6 = (it2)2 * 3 which is {1, 1 , 2, 6}
                }


                int rightSide = 1; // the rightside is set to 1 because there are no elements to the right of the last element and a value needs to be assigned, identity principle.
                for(int i = nums.Length - 1; i >= 0; i--) // This will be going to the beginning starting from the back for a total of 4 iterations
                {
                    // initial state is {1, 1 , 2, 6}
                    result[i] = result[i] * rightSide;
                    //iteration1 is 6 = 6 * 1 which will end with {1, 1 , 2, 6} rightSide value 1
                    //iteration2 is 8 = 2 * 4 which will end with {1, 1 , 8, 6} rightSide value 4
                    //iteration3 is 12 = 1 * 12  which will end with {1, 12 , 8, 6} rightSide value 12
                    //iteration4 is 24 = 1 * 24 which will end with {24, 12 , 8, 6} rightSide value 24
                    rightSide *= nums[i];
                    //iteration1 is 4 = 1 * 4  The initial end value result array is 6 because rightSide value set to 1 but will be 4 for next iteration calculation for result[i]
                    //iteration2 is 12 = 4 * 3
                    //iteration3 is 24 = 12 * 2
                    //iteration4 is 24 = 24 *1 
                }
                return result;
            }
        
        }


    }
}
