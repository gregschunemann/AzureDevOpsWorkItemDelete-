using System;

namespace ADOWorkItemDelete
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            const string URL = "<YourOrgURL>";  //example - https://dev.azure.com/myOrg
            const string PAT = "YourPAT"; //Personal Access Token with work items read/write access
            const string projectName = "YourProjectName";
            string val;
            int workItemStart;
            int workItemEnd;

            Console.Write("Enter the first work item number in the range: ");
            val = Console.ReadLine();
            workItemStart = Convert.ToInt32(val);

            Console.Write("Enter the last work item number in the range: ");
            val = Console.ReadLine();
            workItemEnd = Convert.ToInt32(val);


            for (int i = workItemStart; i <= workItemEnd; i++) 
            {
                try
                {
                    var responseMessage = WorkItemProcessor.Delete(i, URL, projectName, PAT).Result;
                    //Console.WriteLine("Response code: " + responseMessage.StatusCode);
                    Console.WriteLine("Work item successfully deleted.");
                }
                catch (AggregateException e)
                {
                    //Console.WriteLine($"Work item not found: {e}");
                    Console.WriteLine($"Work item not found: {i}");
                }
               
                //Console.WriteLine("Response code: " + responseMessage.StatusCode);
            }
        }
    }
}
