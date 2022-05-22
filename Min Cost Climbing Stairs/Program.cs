using System;

namespace Min_Cost_Climbing_Stairs
{
  class Program
  {
    static void Main(string[] args)
    {
      var cost = new int[] { 10, 15, 20 };
      Solution s = new Solution();
      int result = s.MinCostClimbingStairs(cost);
      Console.WriteLine(result);
    }
  }

  public class Solution
  {
    // 1. we need to start calculating the min cost for one/two jump from the last index and memorize the min cost for that position.
    // 2. so that when we calculate for one last before and so on we have the min cost to reach top for the next index.
    // Example = { 10, 15, 20}
    // Index = 2
    // from last index 2, min cost to reach top is = 20
    // Index = 1
    // from index 1, when one jump min cost = 15 + mincost(index2) = 15 + 20 = 35
    // from index 1, when two jump min cost = 15 + 0(because will reach to the top) = 15 + 0 = 15
    // now take Min(onejump, twojump) = Min(35, 15) = 15, i.e - 15 rs cost from index 1
    // Index = 0
    // from index 0, when one jump min cost = 10 + mincost(index1) = 10 + 15 = 25
    // from index 0, when two jump min cost = 10 + 20(mincost of index2) = 10 + 20 = 30
    // now take Min(onejump, twojump) = Min(25, 30) = 15, i.e - 25 rs cost from index 0

    // Now as we have calculated all the min cost for each index, so we have two possibility as per the question , either take one step OR two step
    // So the answer is Min(index0, index1) = Min(25, 15) = 15.
    public int MinCostClimbingStairs(int[] cost)
    {
      int length = cost.Length;
      int lastIndex = length - 1;
      for (int i = lastIndex; i >= 0; i--)
      {
        int onestep = i + 1;
        int twostep = i + 2;
        int onestepcost;
        int twostepcost = int.MaxValue;
        // if we take one step did not reach at the end.
        if (onestep != length)
        {
          onestepcost = cost[i] + cost[onestep];
          if (twostep != length)
          {
            twostepcost = cost[i] + cost[twostep];
          }
          else
          {
            twostepcost = cost[i] + 0;
          }
        }
        else
        {
          // when reached the top by taking one step
          // so the cost would be that position cost.
          onestepcost = cost[i];
        }
        cost[i] = Math.Min(onestepcost, twostepcost);
      }
      int finalcost = Math.Min(cost[0], cost[1]);
      return finalcost;
    }
  }
}
