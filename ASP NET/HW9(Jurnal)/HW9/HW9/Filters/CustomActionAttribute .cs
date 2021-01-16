using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HW9.Filters
{

    public class CustomActionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var action = actionName.Split(new char[] { ' ', '.' });

            try
            {
                using (StreamWriter myStream = new StreamWriter("test.txt", true))
                {
                    myStream.Write(action[action.Length-2] + ' ');
                }
            }
            catch(Exception e)
            {
                File.Create("test.txt");
            }
        }
 
        public void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                using (StreamWriter myStream = new StreamWriter("test.txt", true))
                {
                    myStream.Write(DateTime.Now);
                    myStream.Write('\n');
                }
            }
            catch (Exception e)
            {
                File.Create("test.txt");
            }
        }
    }
}
