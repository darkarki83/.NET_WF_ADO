using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW1_WebA_.Helpers
{
    public static class CalcHelper
    {
        public static HtmlString Calculate(this IHtmlHelper html, int num1, int num2, string action)
        {

            double sum = 0;
            if(action == "+")
            {
                sum = num1 + num2;
            }
            else if (action == "-")
            {
                sum = num1 - num2;
            }
            else if (action == "*")
            {
                sum = num1 * num2;
            }
            else if (action == "/")
            {
                sum = (double)num1 / (double)num2;
            }
            return new HtmlString(sum.ToString());
        }

    }
}
