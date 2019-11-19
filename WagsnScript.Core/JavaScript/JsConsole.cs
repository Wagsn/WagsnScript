using System;
using System.Collections.Generic;
using System.Text;

namespace WagsnScript.JavaScript
{
    public class JsConsole : JsObject
    {
        public void log(object[] args)
        {
            Console.WriteLine(args);
        }
        public void log(object arg)
        {
            Console.WriteLine(arg);
        }
    }
}
