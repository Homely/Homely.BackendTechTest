using System.Collections.Generic;

namespace BuggyMethod
{
    public static class BuggyClass
    {
        // Context: There are some problems with this method. (bugs, and code improvements)
        // Expected output: string value equalling "HOMELY IS AWESOME"
        // Tasks:
        //      - Identify/tell us the problems
        //      - Fix the problems
        //      - Prove you're fixed the problem
        //      - Do it in the best way you know how
        public static string BuggyMethod()
        {
            var list = new List<string> { "awesome", "is", "homely" };

            for (int i = 0; i < list.Count; i++)
            {
                list.Add(list[i].ToUpper());
            }

            var stringReturn = "";
            foreach (var word in list)
            {
                stringReturn += word;
            }

            return stringReturn;
        }
    }
}