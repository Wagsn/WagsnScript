using System;
using System.Collections.Generic;
using System.Text;

namespace WagsnScript.JavaScript
{
    /// <summary>
    /// 封装C#的Math函数
    /// </summary>
    public class JsMath : JsObject
    {
        public void Test()
        {
            //Math.
        }

        public double max(double a, double b)
        {
            return Math.Max(a, b);
        }
    }
}
