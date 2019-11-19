using System;
using System.Collections.Generic;
using System.Text;

namespace WagsnScript.JavaScript
{
    /// <summary>
    /// 用于桥接JS对象的基类
    /// </summary>
    public class JsObject
    {
        public override string ToString()
        {
            return "[object Object]";
        }
    }
}
